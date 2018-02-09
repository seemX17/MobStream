using CoreGraphics;
using Foundation;
using System;

using UIKit;

namespace WebView.iOS
{
    public partial class ViewController : UIViewController
    {
        private int  flag = 0;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var url = "http://test.ninestack.com/webstream/html.html";
            webView.ScrollView.Bounces = false;
            webView.MultipleTouchEnabled = false;
            webView.AllowsInlineMediaPlayback = true;
            webView.MediaPlaybackRequiresUserAction = false;
            chatBox.Layer.ZPosition = 4;
            webView.LoadRequest(new NSUrlRequest(new NSUrl(url), NSUrlRequestCachePolicy.ReloadIgnoringLocalAndRemoteCacheData, 15));
            switchScreen.TouchUpInside += switchScreen_Touch;
        }

        private void switchScreen_Touch(object sender, EventArgs e)
        {
            
            if(flag == 0)
            {
                //webView.Frame = new CGRect(400, 200, 240, 128);
                //chatBox.Frame = View.Bounds;
                //chatBox.SendSubviewToBack(this.View);
                webView.Frame = new CGRect(400, 100, 240, 128);
                webView.Center = chatBox.Center;
                webView.Layer.ZPosition = 5;
                chatBox.Frame = View.Bounds;
                flag = 1;
            }
            else
            {
                //webView.Frame = View.Bounds;
                //chatBox.Frame = new CGRect(400, 200, 240, 128);
                chatBox.Frame = new  CGRect(400, 100, 240, 128);
                chatBox.Center = webView.Center;
                //chatBox.Layer.ZPosition = 6;
                webView.Layer.ZPosition = 3;
                webView.Frame = View.Bounds;
                FadeAnimation(webView, isIn: false, duration: 1, onFinished: null);
                flag = 0;
            }
        }

        private void FadeAnimation(UIWebView webView, bool isIn, double duration = 0.3, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            webView.Alpha = isIn ? maxAlpha : minAlpha;
            webView.Transform = CGAffineTransform.MakeIdentity();
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut, () => {
            webView.Alpha = isIn ? minAlpha : maxAlpha; }, onFinished);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

        public override bool ShouldAutorotate()
        {
            return false;
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            return UIInterfaceOrientationMask.Landscape;
        }
    }
}
