using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using Android.Content.PM;
using static Android.Resource;
using Android.Views.Animations;
using Android.Content;
using Android.Animation;
using static Android.Views.Animations.Animation;
using System;
using Android.Runtime;

namespace WebView.Droid
{
    [Activity(Label = "WebView", Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Landscape, Theme = "@android:style/Theme.NoTitleBar")]
    public class MainActivity : Activity
    {
        Android.Webkit.WebView web_view;
        ImageView switchBtn;
        TextView chatBox;
        int flagSwitch = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            web_view = FindViewById<Android.Webkit.WebView>(Resource.Id.webview);
            switchBtn = FindViewById<ImageView>(Resource.Id.switchBtn);
            chatBox = FindViewById<TextView>(Resource.Id.chatBox);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.Settings.JavaScriptCanOpenWindowsAutomatically = true;
            web_view.Settings.SetPluginState(WebSettings.PluginState.On);
            web_view.Settings.MediaPlaybackRequiresUserGesture = false;
            web_view.LoadUrl("http://test.ninestack.com/webstream/html.html");
            #region initial animation
            //Scale-animation initial to set from full size to small view
            //ScaleAnimation scaleAnim = new ScaleAnimation(
            //    1f, 0.4f,
            //    1f, 0.4f,
            //    1999, 500);
            //scaleAnim.Duration = 0;
            //scaleAnim.RepeatCount = 0;
            //scaleAnim.Interpolator = new AccelerateDecelerateInterpolator();
            //scaleAnim.FillAfter = true;
            //scaleAnim.FillBefore = true;
            //scaleAnim.FillEnabled = true;
            //chatBox.StartAnimation(scaleAnim);
            #endregion
            switchBtn.Click += SwitchBtn_Click;

        }
        private void SwitchBtn_Click(object sender, System.EventArgs e)
        {
           
            //Scale-animation variables
            // var IncreseSizeAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.increaseSize);
            // var descreaseSizeAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.descreaseSizeAnimation);
            if (flagSwitch == 0)
            {
                //Scale-animation chatbox
                //chatBox.StartAnimation(IncreseSizeAnimation);
                //IncreseSizeAnimation.FillAfter = true;
                //web_view.StartAnimation(descreaseSizeAnimation);
                //descreaseSizeAnimation.FillAfter = true;
                //max chatbox
                RelativeLayout.LayoutParams paramCB = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MatchParent, RelativeLayout.LayoutParams.MatchParent);
                chatBox.LayoutParameters = paramCB;
                paramCB = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MatchParent, RelativeLayout.LayoutParams.MatchParent);
                chatBox.LayoutParameters = paramCB;


                //min webview
                RelativeLayout.LayoutParams paramVd = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MatchParent, RelativeLayout.LayoutParams.MatchParent);
                web_view.LayoutParameters = paramVd;
                paramVd.Height = 400;
                paramVd.Width = 700;
                web_view.LayoutParameters = paramVd;
                web_view.BringToFront();
                paramVd.AddRule(LayoutRules.AlignParentRight);
                paramVd.AddRule(LayoutRules.AlignParentBottom);
                paramVd.SetMargins(0, 0, 5, 5);
                flagSwitch = 1;
                switchBtn.BringToFront();

            }

            else
            {
                //scale-Animation chatBox
                //chatBox.StartAnimation(descreaseSizeAnimation);
                //descreaseSizeAnimation.FillAfter = true;
                //web_view.StartAnimation(IncreseSizeAnimation);
                //IncreseSizeAnimation.FillAfter = true;
                //flagSwitch = 0; 

                //max webview
                RelativeLayout.LayoutParams paramCB = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MatchParent, RelativeLayout.LayoutParams.MatchParent);
                web_view.LayoutParameters = paramCB;
                paramCB = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MatchParent, RelativeLayout.LayoutParams.MatchParent);
                web_view.LayoutParameters = paramCB;

                AlphaAnimation alpha = new AlphaAnimation(0.0f, 1f);
                alpha.Duration = (1000);
                alpha.FillAfter = (true);
                web_view.StartAnimation(alpha);

                //min chatbx
                RelativeLayout.LayoutParams paramVd = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MatchParent, RelativeLayout.LayoutParams.MatchParent);
                chatBox.LayoutParameters = paramVd;
                paramVd.Height = 400;
                paramVd.Width = 700;
                chatBox.LayoutParameters = paramVd;
                chatBox.BringToFront();
                paramVd.AddRule(LayoutRules.AlignParentRight);
                paramVd.AddRule(LayoutRules.AlignParentBottom);
                paramVd.SetMargins(0, 0, 5, 5);
                flagSwitch = 0;
                switchBtn.BringToFront();
            }

        }

        //public class HelloWebViewClient : WebViewClient
        //{
        //    public override void OnLoadResource(Android.Webkit.WebView view, string url)
        //    {
        //        view.LoadUrl("javascript:(function() { document.getElementsByTagName('my-player')[0].play(); })()");
        //    }
        //    public override bool ShouldOverrideUrlLoading(Android.Webkit.WebView view, string url)
        //    {
        //        view.LoadUrl(url);
        //        return false;
        //    }
        //}


    }

    //call using "scaleAnim.SetAnimationListener(new animationListener(chatBox));"

    //public class animationListener : Java.Lang.Object, IAnimationListener
    //{
    //    private TextView chatBox;

    //    public animationListener(TextView chatBox)
    //    {
    //        this.chatBox = chatBox;
    //    }

    //    public void OnAnimationEnd(Android.Views.Animations.Animation animation)
    //    {
    //        RelativeLayout.LayoutParams paramVd = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MatchParent, RelativeLayout.LayoutParams.MatchParent);
    //        chatBox.LayoutParameters = paramVd;
    //        paramVd.AddRule(LayoutRules.AlignParentRight);
    //        paramVd.AddRule(LayoutRules.AlignParentBottom);
    //    }

    //    public void OnAnimationRepeat(Android.Views.Animations.Animation animation)
    //    {
    //        //hrow new NotImplementedException();
    //    }

    //    public void OnAnimationStart(Android.Views.Animations.Animation animation)
    //    {
    //        ///throw new NotImplementedException();
    //    }
    //}
}

