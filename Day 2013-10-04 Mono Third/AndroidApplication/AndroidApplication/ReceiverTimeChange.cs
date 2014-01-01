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
    [BroadcastReceiver(Enabled = true, Label = "TimeReceiver")]
    [IntentFilter(new String[]
    {
        "android.intent.action.TIME_SET"
    })]

    class ReceiverTimeChange : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "Time has changed", ToastLength.Short).Show();
        }
    }


    //[BroadcastReceiver(Enabled = true, Label = "时间监听")]
    //[IntentFilter(new string[] { "android.intent.action.TIME_SET" })]
    //public class ReceiverTimeChange : BroadcastReceiver
    //{
    //    //因为IntentFilter信息是写到AndroidManifest.xml中的，所以apk安装过程中都会扫描AndroidManifest.xml中的
    //    //信息，把“哪个Action或者BroadcastReceiver会响应什么样的Action”注册到操作系统中
    //    //当发出这样的一个Intent或者广播的的时候，操作系统会实例化并且运行对应的Activity或者BroadcastReceiver

    //    public override void OnReceive(Context context, Intent intent)
    //    {
    //        Toast.MakeText(context, "时间改变啦!", ToastLength.Long).Show();
    //    }
    //}
}