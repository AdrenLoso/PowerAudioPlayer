using Newtonsoft.Json;
using PowerAudioPlayer.Model;
using System.IO;

namespace PowerAudioPlayer.Controllers.Helper
{
    internal static class PlaylistHelper
    {
        public static readonly string DefaultPlaylistDir = Path.Combine(Player.GetExactDataFilePath(), "Playlist");

        private static List<Playlist> _playlists = new List<Playlist>();
        public static List<Playlist> Playlists
        {
            get => _playlists;
            set => _playlists = value;
        }

        public static int Count => _playlists.Count;

        public static int ActivePlaylistIndex => _playlists.FindIndex(x => x.IsActive);

        public static Playlist ActivePlaylist
        {
            get => _playlists[ActivePlaylistIndex];
            set => _playlists[ActivePlaylistIndex] = value;
        }

        public static void LoadPlaylists()
        {
            var cmd = Environment.GetCommandLineArgs();
            cmd[0] = string.Empty;
            Directory.CreateDirectory(DefaultPlaylistDir);
            var files = Utils.SearchFiles(DefaultPlaylistDir, ["*.json"], false);
            foreach (var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);
                var lastIndex = LoadPlaylist(file);
                if (name == "active")
                {
                    var activePlaylist = Playlists[lastIndex];
                    activePlaylist.IsActive = true;
                    activePlaylist.Name = Player.GetString("ActivePlaylist");
                    if (cmd.Length > 1)
                    {
                        activePlaylist.Items.Clear();
                        foreach (var f in cmd)
                        {
                            if (!string.IsNullOrEmpty(f))
                                activePlaylist.Items.Add(PlaylistItem.FormFile(f));
                        }
                    }
                }
            }
            if (_playlists.Count == 0 || _playlists.FindLast(x => x.IsActive) == null)
            {
                _playlists.Add(new Playlist { Name = Player.GetString("ActivePlaylist"), IsActive = true });
            }
        }

        public static void SavePlaylists()
        {
            Directory.CreateDirectory(DefaultPlaylistDir);
            foreach (var playlist in _playlists)
            {
                var fileName = playlist.IsActive ? "active.json" : $"{playlist.Name}.json";
                SavePlaylist(Path.Combine(DefaultPlaylistDir, fileName), _playlists.IndexOf(playlist));
            }
        }

        public static int LoadPlaylist(string file)
        {
            var json = File.ReadAllText(file);
            var items = JsonConvert.DeserializeObject<List<PlaylistItem>>(json) ?? new List<PlaylistItem>();
            var name = Path.GetFileNameWithoutExtension(file);
            if (NameExists(name))
                name += _playlists.Count(f => f.Name.Equals(name)).ToString();
            var playlist = new Playlist { Name = name, Items = items };
            _playlists.Add(playlist);
            return _playlists.Count - 1;
        }

        public static void ReplacePlaylist(string file, int index = 0)
        {
            var json = File.ReadAllText(file);
            var items = JsonConvert.DeserializeObject<List<PlaylistItem>>(json) ?? new List<PlaylistItem>();
            _playlists[index].Items = items;
        }

        public static void SavePlaylist(string file, int index = 0)
        {
            var json = JsonConvert.SerializeObject(Playlists[index].Items);
            File.WriteAllText(file, json);
        }

        public static bool FileExistsInAnyList(string file)
        {
            return Playlists.Any(list => list.Items.Exists(o => o.File.Equals(file)));
        }

        public static bool IsOutOfRange(int index)
        {
            return index < 0 || index >= _playlists.Count;
        }

        public static bool CheckName(string name)
        {
            return !NameExists(name) && !name.Equals("active", StringComparison.CurrentCultureIgnoreCase) && name.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;
        }

        public static bool Rename(string newName, int index = 0)
        {
            if (CheckName(newName) && index != 0)
            {
                try
                {
                    File.Move(Path.Combine(DefaultPlaylistDir, $"{_playlists[index].Name}.json"), Path.Combine(DefaultPlaylistDir, $"{newName}.json"));
                }
                catch
                {
                }
                _playlists[index].Name = newName;
                return true;
            }
            return false;
        }

        public static int Add(Playlist list)
        {
            if (CheckName(list.Name))
            {
                _playlists.Add(list);
                try
                {
                    File.WriteAllText(Path.Combine(DefaultPlaylistDir, $"{list.Name}.json"), string.Empty);
                    return _playlists.Count - 1;
                }
                catch
                {
                    return -1;
                }
            }
            return -1;
        }

        public static bool Remove(Playlist list)
        {
            try
            {
                _playlists.Remove(list);
                File.Delete(Path.Combine(DefaultPlaylistDir, $"{list.Name}.json"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Remove(int index)
        {
            if (index != 0)
            {
                return Remove(_playlists[index]);
            }
            return false;
        }

        public static bool NameExists(string name)
        {
            return _playlists.Exists(o => o.Name == name);
        }

        public static void CopyToActivePlaylist(int from)
        {
            if (from == ActivePlaylistIndex || Playlists[from].Items.SequenceEqual(ActivePlaylist.Items))
                return;
            ActivePlaylist.Items = _playlists[from].Items;
        }

        public static void CopyToActivePlaylist(List<PlaylistItem> fromItems)
        {
            if (fromItems.SequenceEqual(ActivePlaylist.Items))
                return;
            ActivePlaylist.Items = fromItems;
        }

        public static void CopyToPlaylist(int from, int to)
        {
            if (Playlists[from].Items.SequenceEqual(Playlists[to].Items))
                return;
            _playlists[to].Items = _playlists[from].Items;
        }

        public static void CopyToPlaylist(List<PlaylistItem> fromItems, int to)
        {
            if (fromItems.SequenceEqual(Playlists[to].Items))
                return;
            _playlists[to].Items = fromItems;
        }
    }
}