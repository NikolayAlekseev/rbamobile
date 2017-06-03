using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using PushNotification.Plugin;
using Rbauto.Android.Services;
using Xamarin.Forms;

namespace Rbauto.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static Context AppContext;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            AppContext = this.ApplicationContext;

            if (Device.RuntimePlatform == Device.Android)
            {
				CrossPushNotification.Initialize<CrossPushNotificationListener>("850599225142");
				StartPushService();
			}

            LoadApplication(new App());
        }

        public static void StartPushService()
        {
            AppContext.StartService(new Intent(AppContext, typeof(PushNotificationService)));

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {

                PendingIntent pintent = PendingIntent.GetService(AppContext, 0, new Intent(AppContext, typeof(PushNotificationService)), 0);
                AlarmManager alarm = (AlarmManager)AppContext.GetSystemService(Context.AlarmService);
                alarm.Cancel(pintent);
            }
        }

        public static void StopPushService()
        {
            AppContext.StopService(new Intent(AppContext, typeof(PushNotificationService)));
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                PendingIntent pintent = PendingIntent.GetService(AppContext, 0, new Intent(AppContext, typeof(PushNotificationService)), 0);
                AlarmManager alarm = (AlarmManager)AppContext.GetSystemService(Context.AlarmService);
                alarm.Cancel(pintent);
            }
        }
    }
}