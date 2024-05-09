using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace ControlPeformance
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void TransferOutClicked_Clicked(object sender, EventArgs e)
        {
            contentView.TranslationX = DeviceDisplay.Current.MainDisplayInfo.Width - 970;
        }

        private async void TransferTo0_Clicked(object sender, EventArgs e)
        {
            contentView.TranslationX = 0;
            grid1.IsVisible = false;
            busyIndicatorGrid.IsVisible = true;
            await Task.Delay(500);
            busyIndicatorGrid.IsVisible = false;
            grid1.IsVisible = true;
        }

       
    }
    public class CustomControl : GraphicsView, IDrawable
    {

        public CustomControl()
        {
            this.Drawable = this;
        }
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.SaveState();
            canvas.FillColor = Colors.Red;
            canvas.FillEllipse(10, 10, 100, 100);
            this.UpdateBaseClip();
            canvas.RestoreState();
        }

     

        internal void UpdateBaseClip()
        {
            var x = 0;
            var y = 0;
#if WINDOWS
                    if (!(Parent is Frame))
                           this.Clip = new RoundRectangleGeometry(new CornerRadius(8), new Rect(x, y, this.Width, this.Height));
#else
            this.Clip = new RoundRectangleGeometry(new CornerRadius(8), new Rect(x, y, this.Width, this.Height));
#endif
        }
    }

}
