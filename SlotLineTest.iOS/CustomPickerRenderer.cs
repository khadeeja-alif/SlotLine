using System;
using SlotLineTest;
using SlotLineTest.iOS;
using Xamarin.Forms;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace SlotLineTest.iOS
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            var element = (CustomPicker)this.Element;
            if (element == null)
                return;

            if (element == null) return;

            e.NewElement.SizeChanged += (obj, args) =>
            {
                var picker = obj as Picker;
                if (picker == null)
                    return;

                if (this.Control != null && this.Element != null && !string.IsNullOrEmpty(element.Arrow))
                {
                    var downarrow = UIImage.FromBundle(element.Arrow);
                    Control.RightViewMode = UITextFieldViewMode.Always;
                    Control.RightView = new UIImageView(downarrow);
                    // Create borders (bottom only)
                    CALayer border = new CALayer();
                    float width = 1.0f;
                    border.BorderColor = new CoreGraphics.CGColor(red: 0.89f, green: 0.89f, blue: 0.89f, alpha: 1.0f);  // gray border color
                    border.Frame = new CGRect(x: 0, y: picker.Height - width, width: picker.Width, height: 1.0f);
                    border.BorderWidth = width;

                    Control.Layer.AddSublayer(border);

                    Control.Layer.MasksToBounds = true;
                    Control.BorderStyle = UITextBorderStyle.None;
                    Control.BackgroundColor = null; // white
                }
            };
        }
    }
}
