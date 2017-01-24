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
            ContactDatabase.Root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
          	
			var intent = new Intent(this, typeof(StartRunMedicamentAlertTaskService));
			//StartService(intent);
			/*
			MessagingCenter.Subscribe<StartRunMedicamentAlertTaskMessage>(this, "StartRunMedicamentAlert", message =>
			{
				Console.WriteLine("New Message StartRunMedicamentAlertTaskService Android!");
				var intent = new Intent(this, typeof(StartRunMedicamentAlertTaskService));
				StartService(intent);
			});
			*/


            LoadApplication(new App());
        }
        
        

    }
}

