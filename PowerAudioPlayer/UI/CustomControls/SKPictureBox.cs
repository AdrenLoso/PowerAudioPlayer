using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.ComponentModel;

namespace PowerAudioPlayer.UI.CustomControls
{
    public enum SKPictureBoxSizeMode
    {
        Normal,
        StretchImage,
        AutoSize,
        CenterImage,
        Zoom
    }

    public class SKPictureBox : SKGLControl
    {
        private Image? _image;
        private SKPictureBoxSizeMode _sizeMode = SKPictureBoxSizeMode.Normal;
        private BorderStyle _borderStyle = BorderStyle.None;
        private Color _backColor = SystemColors.Control;

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image? Image
        {
            get => _image;
            set
            {
                _image = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public SKPictureBoxSizeMode SizeMode
        {
            get => _sizeMode;
            set
            {
                _sizeMode = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new BorderStyle BorderStyle
        {
            get => _borderStyle;
            set
            {
                _borderStyle = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Color BackColor
        {
            get => _backColor;
            set
            {
                _backColor = value;
                Invalidate();
            }
        }

        protected override void OnPaintSurface(SKPaintGLSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);
            var canvas = e.Surface.Canvas;
            canvas.Clear(SKColors.White);
            canvas.DrawRect(0, 0, Width, Height, new SKPaint { Color = new SKColor(_backColor.R, _backColor.G, _backColor.B, _backColor.A) });

            if (_image != null)
            {
                SKBitmap bitmap = ToSKBitmap(_image);
                SKRect destRect = GetImageRect(bitmap);
                canvas.DrawBitmap(bitmap, destRect);
            }

            if (_borderStyle != BorderStyle.None)
            {
                DrawBorder(canvas);
            }
        }

        private SKRect GetImageRect(SKBitmap bitmap)
        {
            if (_image == null)
                return SKRect.Empty;

            switch (_sizeMode)
            {
                case SKPictureBoxSizeMode.StretchImage:
                    return new SKRect(0, 0, Width, Height);
                case SKPictureBoxSizeMode.AutoSize:
                    Size = new Size(bitmap.Width, bitmap.Height);
                    return new SKRect(0, 0, bitmap.Width, bitmap.Height);
                case SKPictureBoxSizeMode.CenterImage:
                    return new SKRect((Width - bitmap.Width) / 2, (Height - bitmap.Height) / 2, (Width + bitmap.Width) / 2, (Height + bitmap.Height) / 2);
                case SKPictureBoxSizeMode.Zoom:
                    float ratio = Math.Min((float)Width / bitmap.Width, (float)Height / bitmap.Height);
                    float width = bitmap.Width * ratio;
                    float height = bitmap.Height * ratio;
                    return new SKRect((Width - width) / 2, (Height - height) / 2, (Width + width) / 2, (Height + height) / 2);
                case SKPictureBoxSizeMode.Normal:
                default:
                    return new SKRect(0, 0, bitmap.Width, bitmap.Height);
            }
        }

        private void DrawBorder(SKCanvas canvas)
        {
            var paint = new SKPaint
            {
                Color = SKColors.Black,
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 1
            };

            switch (_borderStyle)
            {
                case BorderStyle.FixedSingle:
                    canvas.DrawRect(new SKRect(0, 0, Width - 1, Height - 1), paint);
                    break;
                case BorderStyle.Fixed3D:
                    paint.Color = SKColors.Gray;
                    canvas.DrawRect(new SKRect(0, 0, Width - 1, Height - 1), paint);
                    break;
            }
        }

        private static SKBitmap ToSKBitmap(Image image)
        {
            var bitmap = new Bitmap(image);
            return Extensions.ToSKBitmap(bitmap);
        }
    }
}
