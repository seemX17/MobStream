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
using Android.Views.Animations;

namespace WebView.Droid
{
    [Activity(Label = "activity_stream_loading", ScreenOrientation = ScreenOrientation.Portrait, Theme = "@android:style/Theme.NoTitleBar")]
    public class activity_stream_loading : Activity
    {
        ImageView ring1, ring2, ring3;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.splashScreenw2);
            ring1 = FindViewById<ImageView>(Resource.Id.ring1);
            ring2 = FindViewById<ImageView>(Resource.Id.ring2);
            ring3 = FindViewById<ImageView>(Resource.Id.ring3);

            changeColor.changeXMLDrawableColor(ring1.Background,this.GetColor(Resource.Color.ring1));
            changeColor.changeXMLDrawableColor(ring2.Background, this.GetColor(Resource.Color.ring2));
            changeColor.changeXMLDrawableColor(ring3.Background, this.GetColor(Resource.Color.ring3));


            Animation pulse = AnimationUtils.LoadAnimation(this, Resource.Animation.splash_fade_in);
            Animation pulse2 = AnimationUtils.LoadAnimation(this, Resource.Animation.splash_fade_in);
            Animation pulse3 = AnimationUtils.LoadAnimation(this, Resource.Animation.splash_fade_in);
            ring1.StartAnimation(pulse);
            ring2.StartAnimation(pulse2);
            ring3.StartAnimation(pulse3);

            ring1.Click += Ring1_Click;
            // Create your application here
        }

        private void Ring1_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}