using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidApplication
{
    [Activity(Label = "Love Feng Baby")]
    [IntentFilter(new String[] { Intent.ActionView }, Categories = new String[] { Intent.CategoryDefault }, DataMimeType = "image/*")]
    public class ActivityImageView : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.layoutImageView);

            var imgView = FindViewById<ImageView>(Resource.Id.imgView);
            imgView.SetImageURI(this.Intent.Data);
        }
    }
}