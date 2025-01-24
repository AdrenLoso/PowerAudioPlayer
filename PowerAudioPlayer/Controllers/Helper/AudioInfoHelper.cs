using PowerAudioPlayer.Model;
using System.IO;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Tags;

namespace PowerAudioPlayer.Controllers.Helper
{
    internal static class AudioInfoHelper
    {
        public static AudioInfo GetAudioInfo(string file)
        {
            int stream = LoadStream(file);
            TAG_INFO bassTagInfo = GetTagInfo(stream, file);
            FreeStream(stream);
            return bassTagInfo != null ? BassTagInfo2AudioInfo(bassTagInfo, file) : new AudioInfo();
        }

        public static AudioInfo GetAudioInfo(int stream)
        {
            string filename = Bass.BASS_ChannelGetInfo(stream).filename;
            TAG_INFO bassTagInfo = GetTagInfo(stream, filename);
            return bassTagInfo != null ? BassTagInfo2AudioInfo(bassTagInfo, filename) : new AudioInfo();
        }

        public static Image? GetAudioPicture(string file)
        {
            int stream = Bass.BASS_StreamCreateFile(file, 0, 0, BASSFlag.BASS_STREAM_PRESCAN | BASSFlag.BASS_STREAM_DECODE);
            TAG_INFO bassTagInfo = GetTagInfo(stream, file);
            FreeStream(stream);
            return bassTagInfo?.PictureCount > 0 ? Utils.ByteToImage(bassTagInfo.PictureGet(0).Data) : null;
        }

        private static int LoadStream(string file)
        {
            int stream = Bass.BASS_MusicLoad(file, 0, 0, BASSFlag.BASS_MUSIC_PRESCAN | BASSFlag.BASS_MUSIC_NOSAMPLE, 48400);
            if (stream == 0)
            {
                stream = Bass.BASS_StreamCreateFile(file, 0, 0, BASSFlag.BASS_STREAM_PRESCAN | BASSFlag.BASS_STREAM_DECODE);
            }
            return stream;
        }

        private static TAG_INFO GetTagInfo(int stream, string file)
        {
            TAG_INFO bassTagInfo = new TAG_INFO();
            if (Utils.IsUrl(file))
            {
                BassTags.BASS_TAG_GetFromURL(stream, bassTagInfo);
            }
            else
            {
                BassTags.BASS_TAG_GetFromFile(stream, bassTagInfo);
            }
            return bassTagInfo;
        }

        private static void FreeStream(int stream)
        {
            Bass.BASS_StreamFree(stream);
            Bass.BASS_MusicFree(stream);
        }

        public static AudioInfo BassTagInfo2AudioInfo(TAG_INFO bassTagInfo, string filename)
        {
            uint.TryParse(bassTagInfo.year, out uint year);
            uint.TryParse(bassTagInfo.disc, out uint disc);
            uint.TryParse(bassTagInfo.track, out uint track);
            AudioInfo audioInfo = new AudioInfo(filename, (int)bassTagInfo.duration, GetAudioTypeByCType(bassTagInfo.channelinfo.ctype));
            audioInfo.Tag.Track = track;
            audioInfo.Tag.Year = year;
            audioInfo.Tag.Disc = disc;
            audioInfo.Tag.Genre = bassTagInfo.genre;
            audioInfo.Tag.Title = ConvertToGB2312IfNeeded(bassTagInfo.title, bassTagInfo.channelinfo.ctype);
            audioInfo.Tag.Album = ConvertToGB2312IfNeeded(bassTagInfo.album, bassTagInfo.channelinfo.ctype);
            audioInfo.Tag.Artist = ConvertToGB2312IfNeeded(bassTagInfo.artist, bassTagInfo.channelinfo.ctype);
            audioInfo.Tag.Comment = ConvertToGB2312IfNeeded(bassTagInfo.comment, bassTagInfo.channelinfo.ctype);
            audioInfo.Tag.Copyright = ConvertToGB2312IfNeeded(bassTagInfo.copyright, bassTagInfo.channelinfo.ctype);
            return audioInfo;
        }

        private static string ConvertToGB2312IfNeeded(string text, BASSChannelType ctype)
        {
            return ctype != BASSChannelType.BASS_CTYPE_STREAM_MIDI ? text : Utils.Windows1254ToGB2312(text);
        }

        public static AudioType GetAudioTypeByCType(BASSChannelType? type)
        {
            return type switch
            {
                BASSChannelType.BASS_CTYPE_STREAM_OGG => AudioType.OGG,
                BASSChannelType.BASS_CTYPE_STREAM_MP1 => AudioType.MP1,
                BASSChannelType.BASS_CTYPE_STREAM_MP2 => AudioType.MP2,
                BASSChannelType.BASS_CTYPE_STREAM_MP3 => AudioType.MP3,
                BASSChannelType.BASS_CTYPE_STREAM_MP4 => AudioType.MP4,
                BASSChannelType.BASS_CTYPE_MUSIC_IT => AudioType.IT,
                BASSChannelType.BASS_CTYPE_MUSIC_MOD => AudioType.MOD,
                BASSChannelType.BASS_CTYPE_MUSIC_MO3 => AudioType.MO3,
                BASSChannelType.BASS_CTYPE_MUSIC_MTM => AudioType.MTM,
                BASSChannelType.BASS_CTYPE_MUSIC_S3M => AudioType.S3M,
                BASSChannelType.BASS_CTYPE_MUSIC_XM => AudioType.XM,
                BASSChannelType.BASS_CTYPE_STREAM_AAC => AudioType.AAC,
                BASSChannelType.BASS_CTYPE_STREAM_AC3 => AudioType.AC3,
                BASSChannelType.BASS_CTYPE_STREAM_ADX => AudioType.ADX,
                BASSChannelType.BASS_CTYPE_STREAM_AIX => AudioType.AIX,
                BASSChannelType.BASS_CTYPE_STREAM_CD => AudioType.CDA,
                BASSChannelType.BASS_CTYPE_STREAM_OFR => AudioType.OFR,
                BASSChannelType.BASS_CTYPE_STREAM_APE => AudioType.APE,
                BASSChannelType.BASS_CTYPE_STREAM_MPC => AudioType.MPC,
                BASSChannelType.BASS_CTYPE_STREAM_SPX => AudioType.SPX,
                BASSChannelType.BASS_CTYPE_STREAM_ALAC => AudioType.ALAC,
                BASSChannelType.BASS_CTYPE_STREAM_TTA => AudioType.TTA,
                BASSChannelType.BASS_CTYPE_STREAM_OPUS => AudioType.OPUS,
                BASSChannelType.BASS_CTYPE_STREAM_MIDI => AudioType.MIDI,
                BASSChannelType.BASS_CTYPE_STREAM_WMA | BASSChannelType.BASS_CTYPE_STREAM_WMA_MP3 => AudioType.WMA,
                BASSChannelType.BASS_CTYPE_STREAM_FLAC | BASSChannelType.BASS_CTYPE_STREAM_FLAC_OGG => AudioType.FLAC,
                BASSChannelType.BASS_CTYPE_STREAM_WAV | BASSChannelType.BASS_CTYPE_STREAM_WAV_PCM | BASSChannelType.BASS_CTYPE_STREAM_WAV_FLOAT => AudioType.WAV,
                BASSChannelType.BASS_CTYPE_STREAM_WV | BASSChannelType.BASS_CTYPE_STREAM_WV_H | BASSChannelType.BASS_CTYPE_STREAM_WV_L | BASSChannelType.BASS_CTYPE_STREAM_WV_LH => AudioType.WV,
                _ => AudioType.Other,
            };
        }

        public static string AudioTypeToString(AudioType type)
        {
            return type switch
            {
                AudioType.OGG => "OGG",
                AudioType.AIFF => "AIFF",
                AudioType.MP1 => "MP1",
                AudioType.MP2 => "MP2",
                AudioType.MP3 => "MP3",
                AudioType.MP4 => "MP4",
                AudioType.IT => "IT",
                AudioType.MOD => "MOD",
                AudioType.MO3 => "MO3",
                AudioType.MTM => "MTM",
                AudioType.S3M => "S3M",
                AudioType.XM => "XM",
                AudioType.AAC => "AAC",
                AudioType.AC3 => "AC3",
                AudioType.ADX => "ADX",
                AudioType.AIX => "AIX",
                AudioType.CDA => "CDA",
                AudioType.OFR => "OFR",
                AudioType.APE => "APE",
                AudioType.MPC => "MPC",
                AudioType.SPX => "SPX",
                AudioType.ALAC => "ALAC",
                AudioType.TTA => "TTA",
                AudioType.OPUS => "OPUS",
                AudioType.MIDI => "MIDI",
                AudioType.WMA => "WMA",
                AudioType.FLAC => "FLAC",
                AudioType.WAV => "WAV",
                AudioType.WV => "WV",
                AudioType.Other => "Other",
                _ => "Other,"
            };
        }

        public static AudioType StringToAudioType(string typeStr)
        {
            return typeStr.ToUpper() switch
            {
                "OGG" => AudioType.OGG,
                "AIFF" => AudioType.AIFF,
                "MP1" => AudioType.MP1,
                "MP2" => AudioType.MP2,
                "MP3" => AudioType.MP3,
                "MP4" => AudioType.MP4,
                "IT" => AudioType.IT,
                "MOD" => AudioType.MOD,
                "MO3" => AudioType.MO3,
                "MTM" => AudioType.MTM,
                "S3M" => AudioType.S3M,
                "XM" => AudioType.XM,
                "AAC" => AudioType.AAC,
                "AC3" => AudioType.AC3,
                "ADX" => AudioType.ADX,
                "AIX" => AudioType.AIX,
                "CDA" => AudioType.CDA,
                "OFR" => AudioType.OFR,
                "APE" => AudioType.APE,
                "MPC" => AudioType.MPC,
                "SPX" => AudioType.SPX,
                "ALAC" => AudioType.ALAC,
                "TTA" => AudioType.TTA,
                "OPUS" => AudioType.OPUS,
                "MIDI" => AudioType.MIDI,
                "MID" => AudioType.MIDI,
                "WMA" => AudioType.WMA,
                "FLAC" => AudioType.FLAC,
                "WAV" => AudioType.WAV,
                "WV" => AudioType.WV,
                _ => AudioType.Other
            };
        }

        public static string ChannelNumberToString(int chans)
        {
            return chans switch
            {
                1 => "Mono",
                2 => "Stereo",
                3 => "2.1",
                4 => "2.2",
                5 => "4.1",
                6 => "5.1",
                7 => "5.2",
                8 => "7.1",
                _ => chans.ToString(),
            };
        }

        public static string GetDisplayTitle(AudioInfo info, string format = "%ARTIST% - %TITLE%")
        {
            if (string.IsNullOrWhiteSpace(info.Tag.Title) && string.IsNullOrWhiteSpace(info.Tag.Artist))
            {
                return Path.GetFileName(info.File);
            }
            string displayTitle = format;
            displayTitle = displayTitle.Replace("%FILE%", Path.GetFileName(info.File));
            displayTitle = displayTitle.Replace("%TITLE%", string.IsNullOrWhiteSpace(info.Tag.Title) ? Player.GetString("UnknowTitle") : info.Tag.Title);
            displayTitle = displayTitle.Replace("%ALBUM%", string.IsNullOrWhiteSpace(info.Tag.Album) ? Player.GetString("UnknowAlbum") : info.Tag.Album);
            displayTitle = displayTitle.Replace("%ARTIST%", string.IsNullOrWhiteSpace(info.Tag.Artist) ? Player.GetString("UnknowArtist") : info.Tag.Artist);
            displayTitle = displayTitle.Replace("%GENRE%", string.IsNullOrWhiteSpace(info.Tag.Genre) ? Player.GetString("UnknowGenre") : info.Tag.Genre);
            return displayTitle;
        }
    }
}