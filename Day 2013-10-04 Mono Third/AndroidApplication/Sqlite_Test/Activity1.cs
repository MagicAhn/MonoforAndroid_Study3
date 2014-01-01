using System;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.OS;
//using Java.Lang;

namespace Sqlite_Test
{
    [Activity(Label = "Sqlite_Test", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            FindViewById<Button>(Resource.Id.MyButton).Click += (sender, args) =>
            {
                ////SQLiteDatabase = SqlConnection
                //using (SQLiteDatabase db = SQLiteDatabase.OpenOrCreateDatabase("/sdcard/sqlite_test.db", null))
                //{
                //    //ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1);
                //    var adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1);

                //    db.ExecSQL("Create Table IF NOT EXISTS T_Person(Id integer primary key autoincrement,Name text,Age integer)");
                //    db.ExecSQL("insert into T_Person(Name,Age) values(?,?)", new Java.Lang.Object[]
                //    {
                //        "AhnLoveFeng",23
                //    });

                //    //ICursor = DataReader
                //    using (ICursor cursor = db.RawQuery("select * from T_Person", null))
                //    {
                //        //ICursor.MoveToNext() = DataReader.Read()
                //        while (cursor.MoveToNext())
                //        {
                //            adapter.Add(String.Format("{2}   Name:{0}     Age:{1}", cursor.GetString(cursor.GetColumnIndex("Name")), cursor.GetInt(cursor.GetColumnIndex("Age")), cursor.GetInt(cursor.GetColumnIndex("Id"))));
                //        }
                //    }

                //    FindViewById<ListView>(Resource.Id.listView).Adapter = adapter;
                //}

                using (MyDatabase db = new MyDatabase(this))
                {
                    db.InsertEnity("Feng Love Ahn", 23);

                    ArrayAdapter<String> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1);

                    using (ICursor cursor = db.GetAllList())
                    {
                        while (cursor.MoveToNext())
                        {
                            adapter.Add(String.Format("{2}   Name:{0}     Age:{1}", cursor.GetString(cursor.GetColumnIndex("Name")), cursor.GetInt(cursor.GetColumnIndex("Age")), cursor.GetInt(cursor.GetColumnIndex("Id"))));
                        }
                    }

                    FindViewById<ListView>(Resource.Id.listView).Adapter = adapter;
                }
            };

            using (
                var cursor = this.ContentResolver.Query(Android.Net.Uri.Parse("content://sms/inbox"), null, null, null,
                    null))
            {
                //while(cursor.MoveToNext())
                //{
                //    for (int i = 0; i < cursor.ColumnCount; i++)
                //    {

                //    }
                //}
                while (cursor.MoveToNext())
                {
                    for (int i = 0; i < cursor.ColumnCount; i++)
                    {
                        Log.Debug("", String.Format("{0} = {1}", cursor.GetColumnName(i), cursor.GetString(i)));
                    }
                }
            }
        }
    }
}

