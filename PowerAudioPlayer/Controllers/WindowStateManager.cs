using Newtonsoft.Json;

namespace PowerAudioPlayer.Controllers
{
    public class WindowState
    {
        public Size Size { get; set; }

        public Point Location { get; set; }

        public WindowState() { }

        public WindowState(Size size, Point location)
        {
            Size = size;
            Location = location;
        }

        public WindowState(int width, int height, int x = 30, int y = 30)
        {
            Size = new Size(width, height);
            Location = new Point(x, y);
        }
    }

    public class WindowStateManager
    {
        private readonly Form _form;
        private readonly string _windowName;

        public WindowStateManager(Form form, string windowName)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form));
            _windowName = windowName ?? throw new ArgumentNullException(nameof(windowName));
        }

        public WindowStateManager(Form form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form));
            _windowName = form.Name;
        }

        public void SaveState()
        {
            Dictionary<string, WindowState> states = new Dictionary<string, WindowState>();
            try
            {
                states = JsonConvert.DeserializeObject<Dictionary<string, WindowState>>(Settings.Default.WindowsState) ?? [];
                if (states.TryGetValue(_windowName, out WindowState? value))
                {
                    value.Size = _form.Size;
                    value.Location = _form.Location;
                }
                else
                {
                    states.Add(_windowName, new WindowState(_form.Size, _form.Location));
                }
            }
            catch
            {
                states.Add(_windowName, new WindowState(_form.Size, _form.Location));
            }
            Settings.Default.WindowsState = JsonConvert.SerializeObject(states);
        }

        public void LoadState()
        {
            try
            {
                var states = JsonConvert.DeserializeObject<Dictionary<string, WindowState>>(Settings.Default.WindowsState);
                if (states != null && states.ContainsKey(_windowName))
                {
                    var state = states[_windowName];
                    _form.Size = state.Size;
                    _form.Location = state.Location;
                }
            }
            catch
            {
            }
        }
    }
}