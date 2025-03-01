using MemoryPack;
using PowerAudioPlayer.Controllers.Utils;
using PowerAudioPlayer.Model;
using System.IO;

namespace PowerAudioPlayer.Controllers.Helper
{
    internal class MediaLibraryHelper
    {
        private static Dictionary<string, AudioInfo> _library = new Dictionary<string, AudioInfo>();
        public static string defaultFile = Path.Combine(Player.GetExactDataFilePath(), "MediaLibrary.dat");

        public static int Count
        {
            get => _library.Count;
        }

        public static Dictionary<string, AudioInfo> Library
        {
            get => _library;
            set => _library = value;
        }

        public static int TotalLength
        {
            get => _library.Values.Where(x => x.Length > 0).ToList().Sum(x => x.Length);
        }

        public static long Size
        {
            get => MiscUtils.GetFileSize(defaultFile);
        }

        public static void SaveMediaLibrary(string file = "")
        {
            if (string.IsNullOrEmpty(file))
                file = defaultFile;
            using FileStream fs = new FileStream(file, FileMode.Create);
            fs.Write(MemoryPackSerializer.Serialize(_library));
        }

        public static void LoadMediaLibrary(string file = "")
        {
            if (string.IsNullOrEmpty(file))
                file = defaultFile;
            using FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            int length = (int)fs.Length;
            byte[] buffer = new byte[length];
            try
            {
                fs.ReadExactly(buffer);
                _library = MemoryPackSerializer.Deserialize<Dictionary<string, AudioInfo>>(buffer) ?? [];
            }
            catch
            {
                _library = new Dictionary<string, AudioInfo>();
            }
        }

        public static void ClearMediaLibrary()
        {
            _library.Clear();
        }

        public static int CleanUpMediaLibrary()
        {
            int removeCount = 0;
            var keysToRemove = _library.Keys
                .Where(key => !File.Exists(key) || !IsInMediaLibraryDirectories(key))
                .ToList();
            foreach (var key in keysToRemove)
            {
                Remove(key);
                removeCount++;
            }
            return removeCount;
        }

        public static bool IsInMediaLibraryDirectories(string file)
        {
            string? path = Path.GetDirectoryName(file);
            if (path == null) return false;
            return Settings.Default.MediaLibraryDirectories
                .Any(d => MiscUtils.IsSubDirectoryOf(path, d.Directory));
        }

        public static bool Add(string file, AudioInfo audioInfo)
        {
            try
            {
                _library.Add(file, audioInfo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Add(string file)
        {
            try
            {
                _library.Add(file, AudioInfoHelper.GetAudioInfo(file));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Remove(string file)
        {
            return _library.Remove(file);
        }

        public static void UpdateMediaLibrary()
        {
            var supportedFiles = Player.Core.GetAllSupportedFileArray();
            var mediaLibraryDirectories = Settings.Default.MediaLibraryDirectories;
            Parallel.ForEach(mediaLibraryDirectories, dir =>
            {
                FileSearcher.SearchFiles(dir.Directory, supportedFiles, true, file =>
                {
                    Add(file);
                    return true;
                });
            });
            if (Settings.Default.MediaLibraryAutoRemove)
                CleanUpMediaLibrary();
        }

        public static string[] GetKeyWordList(ViewType type)
        {
            string[] list = [];
            switch (type)
            {
                case ViewType.Artist:
                    list = _library.Values.ToArray().Select(x => Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(x.Tag.Artist)).Distinct().ToArray();
                    break;
                case ViewType.Album:
                    list = _library.Values.ToArray().Select(x => x.Tag.Album).Distinct().ToArray();
                    break;
                case ViewType.Genre:
                    list = _library.Values.ToArray().Select(x => x.Tag.Genre).Distinct().ToArray();
                    break;
                case ViewType.FileType:
                    list = _library.Values.ToArray().Select(x => Path.GetExtension(x.File).ToLower()).Distinct().ToArray();
                    break;
                case ViewType.Folder:
                    list = _library.Values.ToArray().Select(x => Path.GetDirectoryName(x.File) ?? string.Empty).Distinct().ToArray();
                    break;
            }
            return list;
        }

        public static Dictionary<string, AudioInfo> GetView(ViewType type, string keyWord)
        {
            Dictionary<string, AudioInfo> dic = new Dictionary<string, AudioInfo>();
            switch (type)
            {
                case ViewType.Artist:
                    dic = _library.Where(x => x.Value.Tag.Artist.Equals(keyWord, StringComparison.OrdinalIgnoreCase)).ToDictionary(x => x.Key, x => x.Value);
                    break;
                case ViewType.Album:
                    dic = _library.Where(x => x.Value.Tag.Album.Equals(keyWord)).ToDictionary(x => x.Key, x => x.Value);
                    break;
                case ViewType.Genre:
                    dic = _library.Where(x => x.Value.Tag.Genre.Equals(keyWord)).ToDictionary(x => x.Key, x => x.Value);
                    break;
                case ViewType.FileType:
                    dic = _library.Where(x => Path.GetExtension(x.Value.File).Equals(keyWord)).ToDictionary(x => x.Key, x => x.Value);
                    break;
                case ViewType.Folder:
                    dic = _library.Where(x => (Path.GetDirectoryName(x.Value.File) ?? string.Empty).Equals(keyWord, StringComparison.OrdinalIgnoreCase)).ToDictionary(x => x.Key, x => x.Value);
                    break;
            }
            return dic;
        }
    }
}