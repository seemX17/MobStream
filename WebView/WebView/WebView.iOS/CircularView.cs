using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace WebView.iOS
{
    public partial class CircularView : UIView
    {
        public CircularView (IntPtr handle) : base (handle)
        {
           
        }

        public override void Draw(CGRect rect)
        {
            this.Layer.CornerRadius = Bounds.Height / 2;
            this.Layer.MasksToBounds = true;
        }
    }
}