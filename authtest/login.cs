using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
// btw before you look at this keep in mind i'm just testing for my self (DONT USE THIS FOR PAID PROJECTS YOU WILL GET CRACKED IN HALF A MILISECOND)
// You are allowed to take specific parts of this code for paid projects, I really don't care.
namespace authtest
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        // List of exe names to close when in auth page.
        string[] pog = {
"Fiddler Everywhere",
"ollydbg",
"tcpview",
"autoruns",
"autorunsc",
"filemon",
"procmon",
"idag",
"hookshark",
"peid",
"lordpe",
"regmon",
"idaq",
"idaq64",
"ImmunityDebugger",
"Wireshark",
"dumpcap",
"HookExplorer",
"ImportREC",
"PETools",
"LordPE",
"SysInspector",
"proc_analyzer",
"sysAnalyzer",
"sniff_hit",
"joeboxcontrol",
"joeboxserver",
"ida",
"HTTPDebuggerSvc",
"ResourceHacker",
"ProcessHacker",
"cheatengine-x86_64-SSE4-AVX2",
"cheatengine-i386",
"cheatengine-x86_64" };
        private void button1_Click(object sender, EventArgs e)
        {
            // shitty method of encrypting password and username information when sending to the server
            string authkey = Encode(textBox1.Text + textBox2.Text);
          
            Console.WriteLine(authkey); // key you send under base64 | do what I did in reverse but in your backend. just do base64 decoding via js

            if (textBox1.Text == "") 
            {
                MessageBox.Show("Please put a Username");
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please put a Password");
            }
       
            // Do your backend connection code here.
            // not going to add here just because almost all backends are different.
           


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        // uh oh guys my stackoverflow code skid NO!O!<>!>
        public static string Encode(string text)
        {
            var Bytes = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(Bytes);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;
        static bool settingsReturn, refreshReturn;

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 100% janky ignore my cshart but it workie
            for (int i = 0; i < 34; i++)
            {

                foreach (Process p in Process.GetProcessesByName(pog[i]))
                {
                    p.CloseMainWindow();
                }
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            // once again another stackoverflow code steal moment!1
            AllocConsole();
            // simplest hwid system wouldn't recomend using this
            string HWID;
            HWID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            HWID = Encode(HWID);
            MessageBox.Show(HWID);
            // I also recommend that you uh dont do this. Make a way so someone cant just run an autoresponder on it. Making it just copy is an easy way for someone to make an autoresponder. Possibly change the hwid serversided so somone cant just make a pastebin
            Clipboard.SetText(HWID);
            // This disables any type of proxys used for programs like fiddler and maybe some normal fiddler api autoresponders using that method.
            // This does not disable programs that use services. I still recommend using SSL Pinning.
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true); // grabs register
            registry.SetValue("ProxyEnable", 0); // Sets the value to disable proxy settings
            settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0); // Refreshes settings if it changed
            refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0); // refreshes settings
            // SSL Pinning --> https://stackoverflow.com/questions/46777017/c-sharp-net-pinning-certificates-authorities-i-am-doing-it-correctly
            // SSL Pinning checks if it responds with your unique ssl meaning you cant use autoresponders on it. 
            // After that All you really need is good obfuscation and you should be fine.
            // Make a few auth checks within your code so it checks if you bypassed altogether and closes. For example look right below here
            bool tyui = false;
            // Set tyui to true during auth sequence
            /*
            if(tyui == false) 
            {
                Environment.Exit(1);
            }
            */
            // Than you could put that enviroment exit code in your main forms so nobody can Form1.Show to bypass using some dnspy shit.

        }
    }
}