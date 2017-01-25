using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SeniorAssistance.Database;
using Xamarin.Forms;

using SeniorAssistance;

namespace SeniorAssistance.Droid
{
    [Activity(Label = "SeniorAssistance.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
       
        protected override void OnCreate(Bundle bundle)
        {
            Xamarin.FormsMaps.Init(this, bundle);

			Console.WriteLine("OnCreate Main Android!");
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
			base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            MedicamentHistoryDatabase.Root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
          	
			var intent = new Intent(this, typeof(StartRunMedicamentAlertTaskService));
			StartService(intent);
			/*
			MessagingCenter.Subscribe<StartRunMedicamentAlertTaskMessage>(this, "StartRunMedicamentAlert", message =>
			{
				Console.WriteLine("New Message StartRunMedicamentAlertTaskService Android!");
				var intent = new Intent(this, typeof(StartRunMedicamentAlertTaskService));
				StartService(intent);
			});
			*/


            LoadApplication(new App());
			Notification();
        }
        
		public void Notification()
		{
            // Setup an intent for SecondActivity:
            Intent secondIntent = new Intent(this, typeof(MainActivity));

            // Pass some information to SecondActivity:
            secondIntent.PutExtra("message", "Greetings from MainActivity!");

            // Create a task stack builder to manage the back stack:
            TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);

            // Add all parents of SecondActivity to the stack: 
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(MainActivity)));

            // Push the intent that starts SecondActivity onto the stack:
            stackBuilder.AddNextIntent(secondIntent);

            // Obtain the PendingIntent for launching the task constructed by
            // stackbuilder. The pending intent can be used only once (one shot):
            const int pendingIntentId = 0;
            PendingIntent pendingIntent =
                stackBuilder.GetPendingIntent(pendingIntentId, PendingIntentFlags.OneShot);

            Notification.Builder builder = new Notification.Builder(this)
            .SetContentIntent(pendingIntent)
            .SetContentTitle("C'est un test de notification ")
			.SetContentText("Teste notification coté android!")
			.SetDefaults(NotificationDefaults.Sound)
			.SetSmallIcon(Resource.Drawable.alarm);

			// Build the notification:
			Notification notification = builder.Build();

			// Get the notification manager:
			NotificationManager notificationManager =
				GetSystemService(Context.NotificationService) as NotificationManager;

			// Publish the notification:
			const int notificationId = 0;
			notificationManager.Notify(notificationId, notification);
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;
		}
        

    }
}

