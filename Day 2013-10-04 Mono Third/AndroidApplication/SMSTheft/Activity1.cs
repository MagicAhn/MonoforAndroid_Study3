using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SMSTheft
{
    [Activity(Label = "SMSTheft", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        //int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            //FindViewById<Button>(Resource.Id.MyButton1).Click += (sender, args) =>
            //{
            //    //ISharedPreferences preference = this.GetPreferences(FileCreationMode.WorldWriteable);
            //    //ISharedPreferencesEditor editor = preference.Edit();
            //    //editor.PutString("Name", "Ahn Love Feng");
            //    //editor.Commit();

            //    //var preference = this.GetPreferences(FileCreationMode.WorldWriteable);
            //    //var editor = preference.Edit();
            //    //editor.PutString("Name","Ahn Love Feng");
            //    //editor.Commit();
            //};

            FindViewById<Button>(Resource.Id.MyButton1).Click += (sender, args) => this.GetPreferences(FileCreationMode.WorldWriteable).Edit().PutString("Name", "Ahn Love Feng").Commit();

            //FindViewById<Button>(Resource.Id.MyButton2).Click += (sender1, args1) =>
            //{
            //    var preference = this.GetPreferences(FileCreationMode.WorldReadable);
            //    var name = preference.GetString("Name", "Feng Love Ahn too");
            //    Toast.MakeText(this, name, ToastLength.Long).Show();
            //};

            FindViewById<Button>(Resource.Id.MyButton2).Click += (sender1, args1) => Toast.MakeText(this, this.GetPreferences(FileCreationMode.WorldReadable).GetString("Name", "Feng Love Ahn too"), ToastLength.Long).Show();

            var editTextIop = FindViewById<EditText>(Resource.Id.editTextIOP);
            editTextIop.TextChanged += (sender, args) =>
            {
                if (editTextIop.Text.Equals("1024"))
                {
                    var intent = new Intent(this, typeof(ActivitySettings));
                    StartActivity(intent);
                    Finish();
                }
            };
        }
    }
}

