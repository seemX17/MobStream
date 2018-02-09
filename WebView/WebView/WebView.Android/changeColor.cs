using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WebView.Droid
{
    class changeColor
    {
        public static void changeXMLDrawableColor(Drawable background,  int Color)
        {
            background.Mutate();
            if (background is ShapeDrawable)
            {
                var bgShape = (ShapeDrawable)background;
                
            }
            else if(background is GradientDrawable)
            {
                GradientDrawable bggrad = (GradientDrawable)background;
                bggrad.SetColor(Color);
            }
            else if(background is ColorDrawable)
            {
                ColorDrawable bgcolor = (ColorDrawable)background;

            }

        }
    }
}