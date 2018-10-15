using System;
using SlotLineTest;
using SlotLineTest.Droid;
using Xamarin.Forms;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace SlotLineTest.Droid
{
    public class CustomPickerRenderer : PickerRenderer
    {
        CustomPicker element;

        public CustomPickerRenderer(Context context) : base(context)
        {
        }


        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            element = (CustomPicker)this.Element;

            if (Control != null && this.Element != null && !string.IsNullOrEmpty(element.Arrow))
                Control.Background = AddPickerStyles(element.Arrow);

        }

        public LayerDrawable AddPickerStyles(string imagePath)
        {
            var line = Context.GetDrawable(Resource.Drawable.arrow);
            Drawable[] layers = { line, GetDrawable(imagePath) };
            LayerDrawable layerDrawable = new LayerDrawable(layers);
            layerDrawable.SetLayerInset(0, 0, 0, 0, 0);

            return layerDrawable;
        }

        private BitmapDrawable GetDrawable(string imagePath)
        {
            int resID = Resources.GetIdentifier(imagePath, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            var result = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, 70, 70, true));
            result.Gravity = Android.Views.GravityFlags.Right;

            return result;
        }
    }
}
