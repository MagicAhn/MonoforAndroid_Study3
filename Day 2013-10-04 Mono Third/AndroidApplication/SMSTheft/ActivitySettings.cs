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

namespace SMSTheft
{
    [Activity(Label = "My Activity")]
    public class ActivitySettings : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.layoutSettings);

            var editTextToPhone = FindViewById<EditText>(Resource.Id.editTextToPhone);

            //var preference = this.GetPreferences(FileCreationMode.WorldReadable);
            var preference = GetSharedPreferences("setting", FileCreationMode.WorldReadable);
            String toPhone = preference.GetString("ToPhone", "");
            editTextToPhone.Text = toPhone;

            //FindViewById<EditText>(Resource.Id.editTextToPhone).Text =
            //    this.GetPreferences(FileCreationMode.WorldReadable).GetString("ToPhone", "");

            editTextToPhone.TextChanged += (sender, args) =>
            {
                //var preference2 = GetPreferences(FileCreationMode.WorldReadable);
                var preference2 = GetSharedPreferences("setting", FileCreationMode.WorldReadable);
                var editor = preference2.Edit();
                editor.PutString("ToPhone", editTextToPhone.Text);
                editor.Commit();

                //GetSharedPreferences("setting", FileCreationMode.WorldWriteable)
                //    .Edit()
                //    .PutString("ToPhone", editTextToPhone.Text)
                //    .Commit();
            };
        }
    }
}