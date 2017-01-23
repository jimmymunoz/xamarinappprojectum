using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SeniorAssistance.Database;
using SimpleService;
using Xamarin.Forms;
using SeniorAssistance.Service;
using SeniorAssistance;

namespace SeniorAssistance.Droid
{
    [Activity(Label = "SeniorAssistance.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity CurrentActivity { get; private set; }
        protected override void OnCreate(Bundle bundle)
        {
            /*
            CurrentActivity = this;
            try
            {
                SimpleService.CheckDevice(this);
                SimpleService.CheckManifest(this);
                SimpleService.Register(this, PushHandlerBroadcastReceiver.SENDER_IDS);
            }*/
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            ContactDatabase.Root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
           /* var intent = new Intent(this, typeof(SimpleStartedService));
            StartService(intent);*

            WireUpLongRunningTask();*/
            LoadApplication(new App());
        }
        void WireUpLongRunningTask()
        {
            MessagingCenter.Subscribe<StartLongRunningTaskMessage>(this, "StartLongRunningTaskMessage", message =>
            {
                var intent = new Intent(this, typeof(SimpleStartedService));
                StartService(intent);
            });

        }

    }
}

