using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System.Timers;

namespace WebView.Droid
{
    [Activity(Label = "webView", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, Theme = "@android:style/Theme.NoTitleBar")]
    public class SplashScreen1 : Activity
    {
        ProgressBar progressBar;
        Timer _timer;
        int _countSeconds;
        object _lock = new object();


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.splashScreen);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            progressBar.Max = 84;
            progressBar.Progress = 0;
            _timer = new  System.Timers.Timer();
            _countSeconds = 100;
            _timer.Enabled = true;
            _timer.Interval = 1000;
            _timer.Elapsed += OnTimeEvent;
            // Create your application here
        }

        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            _countSeconds -= 10;

            RunOnUiThread(() =>
            {
                progressBar.IncrementProgressBy(10);
                CheckProgress(progressBar.Progress);
            });
        }

        private void CheckProgress(int progress)
        {
            lock (_lock)
            {
                if (progress >= 84)
                {
                    Toast.MakeText(this, "Navigate to next", ToastLength.Long).Show();
                    _timer.Dispose();
                    StartActivity(typeof(activity_stream_loading));        // Navigate to another activity
                }
            }
        }
    }
}