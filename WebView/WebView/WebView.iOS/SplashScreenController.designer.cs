// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WebView.iOS
{
    [Register ("SplashScreenController")]
    partial class SplashScreenController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WebView.iOS.BackgroundGradientView1 background { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WebView.iOS.CircularView logo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WebView.iOS.CircularView one { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WebView.iOS.CircularView three { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WebView.iOS.CircularView two { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (background != null) {
                background.Dispose ();
                background = null;
            }

            if (logo != null) {
                logo.Dispose ();
                logo = null;
            }

            if (one != null) {
                one.Dispose ();
                one = null;
            }

            if (three != null) {
                three.Dispose ();
                three = null;
            }

            if (two != null) {
                two.Dispose ();
                two = null;
            }
        }
    }
}