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
    [Activity(Label = "My Activity", MainLauncher = true, Icon = "@drawable/icon")]
    //[IntentFilter(new String[] { Intent.ActionCallButton }, Categories = new String[] { Intent.CategoryDefault })]

    public class ActivityFirst : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here

            SetContentView(Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.MyButton).Click += (sender, args) =>
            {
                var intent = new Intent();

                //·¢ËÍ¶ÌÐÅ
                //intent.SetAction(Intent.ActionSendto).SetData(Android.Net.Uri.Parse("smsto:10086")).PutExtra("sms_body", "Hello Intent");

                //http request
                intent.SetAction(Intent.ActionView).SetData(Android.Net.Uri.Parse("http://www.cnblogs.com"));

                StartActivity(intent);
            };
        }
    }
}