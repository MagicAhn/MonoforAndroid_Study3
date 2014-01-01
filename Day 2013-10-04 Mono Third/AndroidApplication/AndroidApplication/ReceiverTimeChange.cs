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


    //[BroadcastReceiver(Enabled = true, Label = "ʱ�����")]
    //[IntentFilter(new string[] { "android.intent.action.TIME_SET" })]
    //public class ReceiverTimeChange : BroadcastReceiver
    //{
    //    //��ΪIntentFilter��Ϣ��д��AndroidManifest.xml�еģ�����apk��װ�����ж���ɨ��AndroidManifest.xml�е�
    //    //��Ϣ���ѡ��ĸ�Action����BroadcastReceiver����Ӧʲô����Action��ע�ᵽ����ϵͳ��
    //    //������������һ��Intent���߹㲥�ĵ�ʱ�򣬲���ϵͳ��ʵ�����������ж�Ӧ��Activity����BroadcastReceiver

    //    public override void OnReceive(Context context, Intent intent)
    //    {
    //        Toast.MakeText(context, "ʱ��ı���!", ToastLength.Long).Show();
    //    }
    //}
}