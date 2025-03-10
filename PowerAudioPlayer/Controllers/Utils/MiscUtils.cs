﻿using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using File = System.IO.File;

namespace PowerAudioPlayer.Controllers.Utils
{
    public static class MiscUtils
    {
        //public delegate bool SearchFileCallback(string file);
        //public static IEnumerable<string> SearchFiles(string directoryPath, string[] fileExtensions, bool searchSubdirectories, SearchFileCallback? callback = null, bool ignoreInaccessible = true)
        //{
        //    if (!Directory.Exists(directoryPath))
        //    {
        //        throw new DirectoryNotFoundException(directoryPath);
        //    }

        //    var options = searchSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        //    var matchingFiles = new ConcurrentBag<string>();

        //    try
        //    {
        //        Parallel.ForEach(fileExtensions, (extension, ParallelLoopState) =>
        //        {
        //            try
        //            {
        //                var files = Directory.EnumerateFiles(directoryPath, "*" + extension, options);
        //                foreach (var file in files)
        //                {
        //                    matchingFiles.Add(file);
        //                    if (callback != null)
        //                    {
        //                        if (!callback.Invoke(file))
        //                        {
        //                            ParallelLoopState.Stop();
        //                            return;
        //                        }
        //                    }
        //                }
        //            }
        //            catch (UnauthorizedAccessException) when (ignoreInaccessible)
        //            {
        //            }
        //        });
        //        return matchingFiles;
        //    }
        //    catch (UnauthorizedAccessException) when (ignoreInaccessible)
        //    {
        //        return [];
        //    }
        //}

        public static bool IsSubDirectoryOf(string potentialSubdirectory, string directory)
        {
            potentialSubdirectory = Path.GetFullPath(potentialSubdirectory);
            directory = Path.GetFullPath(directory);
            if (potentialSubdirectory.Length < directory.Length)
            {
                return false;
            }
            if (!directory.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                directory += Path.DirectorySeparatorChar;
            }
            return potentialSubdirectory.StartsWith(directory, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsDesignMode()
        {
            bool returnFlag = false;
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                returnFlag = true;
            else if (Process.GetCurrentProcess().ProcessName == "DesignToolsServer" || Process.GetCurrentProcess().ProcessName == "devenv")
                returnFlag = true;
            return returnFlag;
        }

        public static bool IsUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return false;
            if (Regex.IsMatch(url, @"^[A-Za-z]+://"))
                return true;
            else
                return false;
        }

        public static long GetFileSize(string sFullName)
        {
            long lSize = 0;
            if (File.Exists(sFullName))
                lSize = new FileInfo(sFullName).Length;
            return lSize;
        }

        public static string FormatFileSize(long factSize)
        {
            string size;
            double sizeInBytes = factSize;
            if (sizeInBytes < 1024)
                size = sizeInBytes.ToString("F0") + " Byte"; // 小于1KB，直接使用字节  
            else if (sizeInBytes < 1048576) // 1MB  
                size = (sizeInBytes / 1024.0).ToString("F2") + " KiB"; // 转换为KB  
            else if (sizeInBytes < 1073741824) // 1GB  
                size = (sizeInBytes / (1024.0 * 1024.0)).ToString("F2") + " MiB"; // 转换为MB  
            else if (sizeInBytes < 1099511627776) // 1TB  
                size = (sizeInBytes / (1024.0 * 1024.0 * 1024.0)).ToString("F2") + " GiB"; // 转换为GB  
            else
                size = (sizeInBytes / (1024.0 * 1024.0 * 1024.0 * 1024.0)).ToString("F2") + " TiB"; // 转换为TB  
            return size;
        }

        public static Color GetSystemThemeColor()
        {
            using (RegistryKey? dwm = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\DWM", false))
            {
                if (dwm != null && dwm.GetValueNames().Contains("AccentColor"))
                {
                    int accentColor = Convert.ToInt32(dwm.GetValue("AccentColor"));
                    return Color.FromArgb(
                        (byte)(accentColor >> 24 & 0xFF),
                        (byte)(accentColor & 0xFF),
                        (byte)(accentColor >> 8 & 0xFF),
                        (byte)(accentColor >> 16 & 0xFF)
                        );
                }
            }
            return Color.Orange;
        }

        public static bool IsDarkMode()
        {
            const string registryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            const string registryValueName = "AppsUseLightTheme";
            object? registryValueObject = Registry.CurrentUser.OpenSubKey(registryKeyPath)?.GetValue(registryValueName);
            if (registryValueObject is null)
                return false;
            return (int)registryValueObject <= 0;
        }

        public static bool EnableDarkModeForWindowTitle(nint hWnd, bool enable)
        {
            int darkMode = enable ? 1 : 0;
            int hResult = NativeAPI.DwmSetWindowAttribute(hWnd, NativeAPI.DWMWA_USE_IMMERSIVE_DARK_MODE, ref darkMode, sizeof(int));
            return hResult > 0;
        }

        public static string Windows1254ToGB2312(string input)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] bytes = Encoding.GetEncoding(1254).GetBytes(input);
            return Encoding.GetEncoding(936).GetString(bytes, 0, bytes.Length);
        }

        public static Color ChangeColorLight(Color color, float correctionFactor)
        {
            float red = color.R;
            float green = color.G;
            float blue = color.B;
            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            if (red < 0) red = 0;
            if (red > 255) red = 255;
            if (green < 0) green = 0;
            if (green > 255) green = 255;
            if (blue < 0) blue = 0;
            if (blue > 255) blue = 255;
            return Color.FromArgb(color.A, (byte)(int)red, (byte)(int)green, (byte)(int)blue);
        }

        public static Color GetForColorByBackgroundColor(Color backgroundColor)
        {
            int brightness = (int)(backgroundColor.R * 0.299 + backgroundColor.G * 0.587 + backgroundColor.B * 0.114);
            if (brightness > 128)
                return Color.Black;
            else
                return Color.White;
        }

        unsafe public static void ExploreFile(string filePath)
        {
            if (!File.Exists(filePath) && !Directory.Exists(filePath))
                return;
            if (Directory.Exists(filePath))
                Process.Start(@"explorer.exe", "/select,\"" + filePath + "\"");
            else
            {
                nint pidlList = NativeAPI.ILCreateFromPath(filePath);
                if (pidlList != nint.Zero)
                {
                    try
                    {
                        Marshal.ThrowExceptionForHR(NativeAPI.SHOpenFolderAndSelectItems(pidlList, 0, nint.Zero, 0));
                    }
                    finally
                    {
                        NativeAPI.ILFree(pidlList);
                    }
                }
            }
        }

        public static byte[] ImageToBytes(Image image)
        {
            if (image == null)
                return [];
            MemoryStream ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }

        public static Image? ByteToImage(byte[]? myByte)
        {
            if (myByte == null)
                return null;
            MemoryStream ms = new MemoryStream(myByte);
            Image _Image = Image.FromStream(ms);
            return _Image;
        }

        public static string RunCommandExeAndReturnOutput(string filename, string arguments)
        {
            Process process = new Process();
            process.StartInfo.FileName = filename;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }

        public static string[] SegmentCommandLine(string args)
        {
            var nch = args.Length;
            var argv = new string[nch];
            var psrc = args;
            bool inquote;
            bool copychar;
            int numslash;
            int pNumArgs = 0;
            inquote = false;
            var currentIndex = 0;
            for (; ; )
            {
                if (currentIndex != psrc.Length)
                {
                    while (currentIndex != psrc.Length && (psrc[currentIndex] == ' ' || psrc[currentIndex] == '\t'))
                    {
                        currentIndex++;
                    }
                }
                if (currentIndex == psrc.Length)
                    break;
                var result = string.Empty;
                for (; ; )
                {
                    copychar = true;
                    numslash = 0;
                    while (currentIndex != psrc.Length && psrc[currentIndex] == '\\')
                    {
                        currentIndex++;
                        ++numslash;
                    }
                    if (currentIndex != psrc.Length && psrc[currentIndex] == '"')
                    {
                        if (numslash % 2 == 0)
                        {
                            if (inquote && psrc.Length != currentIndex + 1 && psrc[currentIndex + 1] == '"')
                            {
                                currentIndex++;
                            }
                            else
                            {
                                copychar = false;
                                inquote = !inquote;
                            }
                        }
                        numslash /= 2;
                    }
                    while (numslash != 0)
                    {
                        numslash--;
                        result += '\\';
                    }
                    if (currentIndex == psrc.Length || !inquote && (psrc[currentIndex] == ' ' || psrc[currentIndex] == '\t'))
                        break;
                    if (copychar)
                    {
                        result += psrc[currentIndex];
                    }
                    currentIndex++;
                }
                argv[pNumArgs] = result;
                pNumArgs++;
            }
            return argv.TakeWhile(n => n != null).ToArray();
        }

        public static string GetProgramLocalAppDataPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Assembly.GetExecutingAssembly().GetName().Name ?? string.Empty);
        }

        public static string GetProgramExecuableFilePath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static void AddShieldToButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.System;
            NativeAPI.SendMessage(btn.Handle, NativeAPI.BCM_SETSHIELD, 0, 255);
        }

        public static void DeleteShieldFromButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.System;
            NativeAPI.SendMessage(btn.Handle, NativeAPI.BCM_SETSHIELD, 0, 0);
        }


        public static void CreateShortcut(string lnkFilePath, string targetPath, string workDir, string args = "")
        {
            var shellType = Type.GetTypeFromProgID("WScript.Shell");
            if (shellType != null)
            {
                dynamic? shell = Activator.CreateInstance(shellType);
                if (shell != null)
                {
                    var shortcut = shell.CreateShortcut(lnkFilePath);
                    shortcut.TargetPath = targetPath;
                    shortcut.Arguments = args;
                    shortcut.WorkingDirectory = workDir;
                    shortcut.Save();
                }
            }
        }

        public static int FFTIndex2Frequency(int index, int length, int samplerate)
        {
            return (int)Math.Round(index * (double)samplerate / length);
        }

        public static int FFTFrequency2Index(int frequency, int length, int samplerate)
        {
            int num = (int)Math.Round(length * (double)frequency / samplerate);
            if (num > length / 2 - 1)
            {
                num = length / 2 - 1;
            }

            return num;
        }

        public static string GetCurrentUserFullName()
        {
            uint size = 1024;
            StringBuilder sb = new StringBuilder((int)size);
            if (NativeAPI.GetUserNameEx((int)NativeAPI.EXTENDED_NAME_FORMAT.NameDisplay, sb, ref size) != 0)
            {
                return sb.ToString();
            }
            else
            {
                return Environment.UserName;
            }
        }

        public static string GetCurrentUserAvatarPath()
        {
            var path = Environment.ExpandEnvironmentVariables("%LocalAppData%\\Microsoft\\Windows\\AccountPicture\\UserImage.jpg");
            if (!File.Exists(path))
                return string.Empty;
            else
                return path;
        }

        public static bool IsRunAsAdministrator()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void CreateDirectoryRecursively(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                return;
            }
            string? dirPath = Path.GetDirectoryName(fileFullPath);
            if (dirPath != null && !Directory.Exists(dirPath))
            {
                CreateDirectoryRecursively(dirPath);
            }

            if (dirPath != null)
            {
                Directory.CreateDirectory(dirPath);
            }
        }
    }
}