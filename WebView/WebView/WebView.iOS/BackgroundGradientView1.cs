using CoreAnimation;
using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace WebView.iOS
{
    public partial class BackgroundGradientView1 : UIView
    {
        public CAGradientLayer gradientLayer;

        public BackgroundGradientView1 (IntPtr handle) : base (handle)
        {
    
        }

        public override void Draw(CGRect rect)
        {
            gradientLayer = new CAGradientLayer();
            var colorBottom  = UIColor.FromRGB(0, 138, 175).CGColor;
            var colorTop = UIColor.FromRGB(0, 59, 106).CGColor;
            gradientLayer.Colors = new CGColor[] { colorTop, colorBottom };
            gradientLayer.Locations = new NSNumber[] { 0.3, 1.0 };
            gradientLayer.Frame = this.Bounds;
            this.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}