using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Text;
using Microsoft.Win32;
using PowerAudioPlayer.Controllers;
using PowerAudioPlayer.Controllers.Utils;
using PowerAudioPlayer.UI;

namespace PowerAudioPlayer
{
    internal static class Program
    {
        public static readonly CultureInfo defaultCultureInfo = CultureInfo.CreateSpecificCulture("zh-CN");
        public static ResourceManager languageResourceManager = new ResourceManager("PowerAudioPlayer.Language.Strings", typeof(Program).Assembly);

        /// <summary>
        ///  程序的入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
#pragma warning disable WFO5001
#if !DEBUG
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
#endif
            ApplicationConfiguration.Initialize();
            Application.SetColorMode(SystemColorMode.System);
            CultureInfo.DefaultThreadCurrentUICulture = defaultCultureInfo;
            Process? instance = RunningInstance();
            if (instance == null)
            {
                SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
                Player.Init();
                Application.Run(new PlayerForm());
                Player.UnInit();
                SystemEvents.UserPreferenceChanged -= SystemEvents_UserPreferenceChanged;
            }
            else
            {
                HandleRunningInstance(instance);
            }
        }

        private static void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.Color)
            {
                Application.SetColorMode(SystemColorMode.System);
                if (MiscUtils.IsDarkMode())
                {
                    foreach(Form form in Application.OpenForms)
                    {
                        MiscUtils.EnableDarkModeForWindowTitle(form.Handle, true);
                    }
                }
                else
                {
                    foreach (Form win in Application.OpenForms)
                    {
                        MiscUtils.EnableDarkModeForWindowTitle(win.Handle, false);
                    }
                }
            }
        }

        public static Process? RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            Process[] array = processes;
            foreach (Process process in array)
            {
                if (process.Id != current.Id && process.ProcessName == current.ProcessName)
                {
                    return process;
                }
            }
            return null;
        }

        public static void HandleRunningInstance(Process instance)
        {
            NativeAPI.ShowWindowAsync(instance.MainWindowHandle, 1);
            NativeAPI.SetForegroundWindow(instance.MainWindowHandle);
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                string data = Environment.CommandLine;
                NativeAPI.COPYDATASTRUCT cds;
                cds.dwData = IntPtr.Zero;
                cds.cbData = Encoding.Default.GetBytes(data).Length + 1;
                cds.lpData = data;
                NativeAPI.SendMessage(instance.MainWindowHandle, NativeAPI.WM_COPYDATA, 0, ref cds);
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ExceptionForm form = new ExceptionForm();
            form.exception = (Exception)e.ExceptionObject;
            form.ShowDialog();
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ExceptionForm form = new ExceptionForm();
            form.exception = e.Exception;
            form.ShowDialog();
        }
    }
}