using CoreAnimation;
using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace WebView.iOS
{
    public partial class SplashScreenController : UIViewController
    {
        public CAGradientLayer gradientLayer;


        public SplashScreenController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            startLoading();
        }

        private void startLoading()
        {
            this.one.Transform = CGAffineTransform.MakeScale(0, 0);
            this.two.Transform = CGAffineTransform.MakeScale(0, 0);
            this.three.Transform = CGAffineTransform.MakeScale(0, 0);
        
            UIView.AnimateNotify(0.8, 0, 0.7f, 1, UIViewAnimationOptions.CurveEaseOut,
                () =>
                {
                    one.Transform = CGAffineTransform.MakeIdentity();
                },
                (f) =>
                {
                    UIView.AnimateNotify(0.8, 0, 0.7f, 1, UIViewAnimationOptions.CurveEaseOut, () =>
                    {
                        two.Transform = CGAffineTransform.MakeIdentity();
                    },
                    (f1) =>
                    {
                        UIView.AnimateNotify(0.8, 0, 0.7f, 1, UIViewAnimationOptions.CurveEaseOut, () => 
                        {
                            three.Transform = CGAffineTransform.MakeIdentity();
                        },
                        (f3) =>
                        {
                            startLoading();
                        });
                    });
                }
         );

        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            return UIInterfaceOrientationMask.Portrait;
        }
    }
}

       

