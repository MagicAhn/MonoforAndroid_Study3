using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Sqlite_Test
{
    class MyDatabase : SQLiteOpenHelper
    {
        public MyDatabase(Context context)
            : base(context, "Sqlite_testV2", null, 2)
        {

        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL("Create Table IF NOT EXISTS T_Person(Id integer primary key autoincrement,Name text,Age integer)");
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            //根据数据库的旧版本号 oldVersion,新版本号 newVersion来执行升级逻辑
        }

        public void InsertEnity(String name, Int32 age)
        {
            WritableDatabase.ExecSQL("Insert into T_Person(Name,Age) values(?,?)", new Java.Lang.Object[] { name, age });
        }

        public ICursor GetAllList()
        {
            return WritableDatabase.RawQuery("select * from T_Person",null);
        }
    }
}