using PowerAudioPlayer.Model;

namespace PowerAudioPlayer.Controllers.Helper
{
    public static class ItemConvertHelper
    {
        public static List<PlaylistItem> ConvertPlayHistoryItemListToPlaylistItemList(List<PlayHistoryItem> playHistoryItems)
        {
            return playHistoryItems.Select(ConvertPlayHistoryItemToPlaylistItem).ToList();
        }

        public static PlaylistItem ConvertPlayHistoryItemToPlaylistItem(PlayHistoryItem playHistoryItem)
        {
            return new PlaylistItem(playHistoryItem.File, playHistoryItem.DisplayTitle, playHistoryItem.Length);
        }

        public static List<PlaylistItem> ConvertMediaLibraryItemListToPlaylistItemList(Dictionary<string, AudioInfo> mediaLibraryItems)
        {
            return mediaLibraryItems.Values.Select(ConvertAudioInfoToPlaylistItem).ToList();
        }

        public static List<PlaylistItem> ConvertAudioInfoListToPlaylistItemList(List<AudioInfo> audioInfoList)
        {
            return audioInfoList.Select(ConvertAudioInfoToPlaylistItem).ToList();
        }

        private static PlaylistItem ConvertAudioInfoToPlaylistItem(AudioInfo audioInfo)
        {
            return new PlaylistItem(audioInfo.File, AudioInfoHelper.GetDisplayTitle(audioInfo), audioInfo.Length);
        }
    }
}