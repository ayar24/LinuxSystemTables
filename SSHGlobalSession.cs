using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using static System.Windows.Forms.AxHost;

namespace LinuxSystemTables
{
    public partial class SSHGlobalSession : Component
    {
        public enum State
        {
            Disconnected,
            Connecting,
            Connected,
            Pending
        }
        public class MachineInfo { 
            public MachineInfo() { }
            public MachineInfo(string machineName) { }
            public string MachineName { get; set; }
            public string OSVersion { get; set; }
            public string TotalRAM { get; set; }
            public string CPUType { get; set; }
            public string KernelVersion { get; set; }

        }

        public SSHGlobalSession()
        {
            InitializeComponent();
        }

        public event EventHandler Disconnected;
        public event EventHandler Connected;
        public event EventHandler FailedToConnect;
        public SSHGlobalSession(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public string DoCommand(string command)
        {
            string res = "";
            if (m_state == State.Connected && m_client != null && m_client.IsConnected)
            {
                res = ExecuteCommand(m_client, command);
            }
            return res;
        }
        private string ExecuteCommand(SshClient client, string command)
        {
            using (var cmd = client.CreateCommand(command))
            {
                var result = cmd.Execute();
                return result;
            }
        }
        public bool Disconnect()
        {
            if (m_client != null)
            {
                m_client.Disconnect();
                m_client = null;
            }

            if (this.Disconnected != null)
                this.Disconnected(this, new EventArgs()); ;

            return true;
        }
            public bool ConnectToSSH(string host, string username, string password, int port = 22)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) =>
            {
                // Always return true to ignore certificate validation errors
                return true;
            };
            
            if (m_state != State.Disconnected)
                return false;

            bool res = false;
            if (m_client == null)
            {
                m_client = new SshClient(host, port, username, password);
            }
         
            try
            {
                m_client.ConnectionInfo.Timeout = TimeSpan.FromMilliseconds(2000);
                
                m_state = State.Connecting;
                m_client.Connect();

                if (m_client.IsConnected)
                {
                    // Execute commands to get system information
                    string osVersionCommand = "cat /etc/os-release | grep PRETTY_NAME | awk -F '\"' '{print $2}'";
                    string kernelVersionCommand = "uname -r";
                    string totalRamCommand = "free -m | awk '/Mem:/ {print $2}'";
                    string cpuInfoCommand = "lscpu | grep 'Model name' | awk -F ':' '{print $2}'";

                    string osVersion = ExecuteCommand(m_client, osVersionCommand);
                    string kernelVersion = ExecuteCommand(m_client, kernelVersionCommand);
                    string totalRam = ExecuteCommand(m_client, totalRamCommand);
                    string cpuInfo = ExecuteCommand(m_client, cpuInfoCommand);

                    cpuInfo = cpuInfo.TrimStart();
                    totalRam = totalRam.Replace("\n", "");

                    Console.WriteLine("OS Version: " + osVersion);
                    Console.WriteLine("Kernel Version: " + kernelVersion);
                    Console.WriteLine("Total RAM (MB): " + totalRam);
                    Console.WriteLine("CPU: " + cpuInfo);

                    this.m_machineInfo = new MachineInfo();
                    this.m_machineInfo.OSVersion = osVersion;
                    this.m_machineInfo.KernelVersion = kernelVersion;
                    this.m_machineInfo.TotalRAM = totalRam + " MB";
                    this.m_machineInfo.CPUType = cpuInfo;
                    
                    m_state = State.Connected;

                    if (this.Connected!=null)
                        this.Connected(this, new EventArgs());

                    res = true;
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                if (this.FailedToConnect != null)
                    this.FailedToConnect(this, new EventArgs());
            }
            finally
            {
                // gClient.Disconnect();
            }
            
            return res;
        }

        private MachineInfo m_machineInfo;
        private State m_state = State.Disconnected;
        //private Queue<string> commandQueue;
        private SshClient m_client = null;

    }
}
