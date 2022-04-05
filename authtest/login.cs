using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;

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

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
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
            // 100% janky ignore my shiity cshart but it workie
            for (int i = 0; i < 35; i++)
            {

                foreach (Process p in Process.GetProcessesByName(pog[i]))
                {
                    p.CloseMainWindow();
                }
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            AllocConsole();
            // og hwid systems wouldn't recomend using this
            string HWID;
            HWID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            HWID = Encode(HWID);
            MessageBox.Show(HWID);
            // I also recommend that you uh dont do this. Make a way so someone cant just run an autoresponder on it. Making it just copy is an easy way. Possibly change the hwid serversided so somone cant just make a pastebin
            Clipboard.SetText(HWID);
            // This disables any type of proxys used for programs like fiddler and maybe some normal selfcoded autoresponders using that method.
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            registry.SetValue("ProxyEnable", 0);
            settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
        }
    }
}