using SkiaSharp;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace PowerAudioPlayer.UI.CustomControls
{
    public enum LyricsAlignment
    {
        Left,
        Center
    }

    public partial class LyricsView : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<LyricsLine> LyricsLines { get; private set; } = new List<LyricsLine>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LineIndex { get; private set; } = 0;

        private int _lineMargin = 20;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LineMargin
        {
            get => _lineMargin;
            set
            {
                _lineMargin = value;
                surface.Invalidate();
            }
        }

        private LyricsAlignment _alignment = LyricsAlignment.Left;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LyricsAlignment Alignment
        {
            get => _alignment;
            set
            {
                _alignment = value;
                surface.Invalidate();
            }
        }

        private Color _highlightColor = Color.Red;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color HighlightColor
        {
            get => _highlightColor;
            set
            {
                _highlightColor = value;
                surface.Invalidate();
            }
        }

        public class LyricsLine
        {
            public string Text { get; set; } = string.Empty;
            public double Time { get; set; } = 0;
        }

        public LyricsView()
        {
            InitializeComponent();
        }

        public void ClearLyrics()
        {
            LyricsLines.Clear();
            surface.Invalidate();
        }

        public void LoadLyrics(string lrcText)
        {
            ClearLyrics();
            foreach (string str in lrcText.Split('\n'))
            {
                if (str.Length > 0 && str.Contains(":"))
                {
                    TimeSpan time = GetTime(str);
                    string lrc = str.Split(']')[1];
                    LyricsLines.Add(new LyricsLine
                    {
                        Text = lrc,
                        Time = time.TotalMilliseconds
                    });
                }
            }
        }

        public void RollTo(double time)
        {
            for (int i = 0; i < LyricsLines.Count; i++)
            {
                if (time >= LyricsLines[i].Time && (i + 1 < LyricsLines.Count && time < LyricsLines[i + 1].Time))
                {
                    LineIndex = i;
                    break;
                }
                if (time >= LyricsLines[LyricsLines.Count - 1].Time)
                {
                    LineIndex = LyricsLines.Count - 1;
                    break;
                }
            }
            surface.Invalidate();
        }

        public string GetCurrentLineText()
        {
            return LyricsLines.Count > 0 ? LyricsLines[LineIndex].Text : string.Empty;
        }

        public TimeSpan GetTime(string str)
        {
            Regex reg = new Regex(@"\[(?<time>.*)\]", RegexOptions.IgnoreCase);
            string timestr = reg.Match(str).Groups["time"].Value;
            int m = Convert.ToInt32(timestr.Split(':')[0]);
            int s = 0, f = 0;
            if (timestr.Split(':')[1].Contains('.'))
            {
                s = Convert.ToInt32(timestr.Split(':')[1].Split('.')[0]);
                f = Convert.ToInt32(timestr.Split(':')[1].Split('.')[1]);
            }
            else
            {
                s = Convert.ToInt32(timestr.Split(':')[1]);
            }
            return new TimeSpan(0, 0, m, s, f);
        }

        private void surface_PaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintGLSurfaceEventArgs e)
        {
            //SKCanvas? canvas = e.Surface.Canvas;
            //canvas.Clear();
            //canvas.DrawRect(0, 0, Width, Height, new SKPaint { Color = new SKColor(BackColor.R, BackColor.G, BackColor.B, BackColor.A) });

            //if (LyricsLines.Count > 0)
            //{
            //    SKFont font = new SKFont(SKTypeface.FromFamilyName(Font.FontFamily.Name), GetScaledFontSize(Font.Size * 1.3f));
            //    SKPaint paintNormal = new SKPaint { Color = new SKColor(ForeColor.R, ForeColor.G, ForeColor.B, ForeColor.A) };
            //    SKPaint paintHighlight = new SKPaint { Color = new SKColor(_highlightColor.R, _highlightColor.G, _highlightColor.B, _highlightColor.A) };

            //    font.MeasureText(LyricsLines[LineIndex].Text, out SKRect rect, paintHighlight);
            //    int midY = (int)(Height / 2 - rect.Height / 2);
            //    canvas.DrawText(LyricsLines[LineIndex].Text, 10, midY, font, paintHighlight);

            //    DrawRemainingLines(canvas, font, paintNormal, midY, 1);
            //    DrawRemainingLines(canvas, font, paintNormal, midY, -1);
            //}
            SKCanvas? canvas = e.Surface.Canvas;
            canvas.Clear();
            canvas.DrawRect(0, 0, Width, Height, new SKPaint { Color = new SKColor(BackColor.R, BackColor.G, BackColor.B, BackColor.A) });

            if (LyricsLines.Count > 0)
            {
                SKFont font = new SKFont(SKTypeface.FromFamilyName(Font.FontFamily.Name), GetScaledFontSize(Font.Size * 1.3f));
                SKPaint paintNormal = new SKPaint { Color = new SKColor(ForeColor.R, ForeColor.G, ForeColor.B, ForeColor.A) };
                SKPaint paintHighlight = new SKPaint { Color = new SKColor(_highlightColor.R, _highlightColor.G, _highlightColor.B, _highlightColor.A) };

                font.MeasureText(LyricsLines[LineIndex].Text, out SKRect rect, paintHighlight);
                int midY = (int)(Height / 2 - rect.Height / 2);

                // 根据对齐方式调整 x 坐标
                float x = 10; // 默认居左
                if (_alignment == LyricsAlignment.Center)
                {
                    x = (Width - rect.Width) / 2; // 居中
                }

                canvas.DrawText(LyricsLines[LineIndex].Text, x, midY, font, paintHighlight);

                DrawRemainingLines(canvas, font, paintNormal, midY, 1);
                DrawRemainingLines(canvas, font, paintNormal, midY, -1);
            }
        }

        private void DrawRemainingLines(SKCanvas canvas, SKFont font, SKPaint paint, int startY, int direction)
        {
            //int counter = LineIndex;
            //for (int i = startY + direction * GetScaledLineMargin(_lineMargin); i >= 0 && i <= Height; i += direction * GetScaledLineMargin(_lineMargin))
            //{
            //    counter += direction;
            //    if (counter < 0 || counter >= LyricsLines.Count) break;
            //    canvas.DrawText(LyricsLines[counter].Text, 10, i, font, paint);
            //}
            int counter = LineIndex;
            for (int i = startY + direction * GetScaledLineMargin(_lineMargin); i >= 0 && i <= Height; i += direction * GetScaledLineMargin(_lineMargin))
            {
                counter += direction;
                if (counter < 0 || counter >= LyricsLines.Count) break;

                // 根据对齐方式调整 x 坐标
                float x = 10; // 默认居左
                if (_alignment == LyricsAlignment.Center)
                {
                    font.MeasureText(LyricsLines[counter].Text, out SKRect rect, paint);
                    x = (Width - rect.Width) / 2; // 居中
                }

                canvas.DrawText(LyricsLines[counter].Text, x, i, font, paint);
            }
        }

        private void LyricsView_SizeChanged(object sender, EventArgs e)
        {
            surface.Invalidate();
        }

        private void tsmiCopyCurrentLine_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(LyricsLines[LineIndex].Text);
            }
            catch
            {
            }
        }

        private void tsmiCopyAlline_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var line in LyricsLines)
            {
                sb.AppendLine(line.Text);
            }
            Clipboard.SetDataObject(sb.ToString());
        }

        private float GetScaledFontSize(float originalFontSize)
        {
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                float dpiX = g.DpiX;
                float scaleFactor = dpiX / 96.0f;
                return originalFontSize * scaleFactor;
            }
        }

        private int GetScaledLineMargin(int originalLineMargin)
        {
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                float dpiX = g.DpiX;
                float scaleFactor = dpiX / 96.0f;
                return (int)(originalLineMargin * scaleFactor);
            }
        }
    }
}
