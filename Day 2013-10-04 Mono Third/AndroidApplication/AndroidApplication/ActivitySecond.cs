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
    [Activity(Label = "Ahn Intent Test")]
    [IntentFilter(new String[] { Intent.ActionSendto }, Categories = new String[] { Intent.CategoryDefault }, DataScheme = "sms")]
    [IntentFilter(new String[] { Intent.ActionView }, Categories = new String[] { Intent.CategoryDefault }, DataScheme = "http")]
    [IntentFilter(new String[] { Intent.ActionView }, Categories = new String[] { Intent.CategoryDefault }, DataScheme = "ftp")]
    public class ActivitySecond : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.layout1);

            if (this.Intent.Action.Equals(Intent.ActionSendto))
            {
                FindViewById<EditText>(Resource.Id.editText).Text = this.Intent.GetStringExtra("sms_body");
            }
            else if (this.Intent.Action.Equals(Intent.ActionView))
            {
                FindViewById<EditText>(Resource.Id.editText).Text = this.Intent.Data.ToString();
            }
        }
    }
}