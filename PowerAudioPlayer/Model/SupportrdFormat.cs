namespace PowerAudioPlayer.Model
{
    public class SupportrdFormat
    {
        public string Name { get; set; } = "";

        public string Extensions { get; set; } = "";

        public SupportrdFormat(string name, string extension)
        {
            Name = name;
            Extensions = extension;
        }

        public SupportrdFormat()
        {
        }
    }
}
