// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WebView.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView chatBox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView containerWeb { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton switchScreen { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIWebView webView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (chatBox != null) {
                chatBox.Dispose ();
                chatBox = null;
            }

            if (containerWeb != null) {
                containerWeb.Dispose ();
                containerWeb = null;
            }

            if (switchScreen != null) {
                switchScreen.Dispose ();
                switchScreen = null;
            }

            if (webView != null) {
                webView.Dispose ();
                webView = null;
            }
        }
    }
}