#Senior Assistance Xamarin
=======
@jimmymunoz @ekebal (2016 - 2017)

Senior Assistance est une application d’assistance aux personnes âgées en utilisant réalisé avec Xamarin a fin de l'utiliser sur des multi-plateforme (Android - IOS). 

##Technologies:

* Xamarin (Android - IOS)
	- Layout Responsive
	- 80% du code dans le code partagée multiplateforme
	- 20% du code specifique pour Android et IOS
	- Service specifique par plataforme - integration avec MessageCenter
	- Système de notifications
	- BD SqlLite
	- Integration Google Maps
	- Web Service Envois SMS


###Digrame de classes:
##Models :
![uml.png](images/uml.png?raw=true "uml.png")

##DB :
![uml-db.png](images/uml-db.png?raw=true "uml-db.png")

##Screenshots:

###Home
![home](images/screenshot-home.jpg?raw=true "home")
###Internet
![internet](images/screenshot-internet.jpg?raw=true "internet")
###Configuration
![configuration](images/screenshot-configuration.jpg?raw=true "configuration")
###Contact list
![contact-list](images/screenshot-contact-list.jpg?raw=true "contact-list")
###Profile:
![screenshot-profile](images/screenshot-profile.jpg?raw=true "screenshot-profile")
###Edit profile
![edit-profile](images/screenshot-edit-profile.jpg?raw=true "edit-profile")
###Add contact
![add-contact](images/screenshot-add-contact.jpg?raw=true "add-contact")
###Add medicament
![add_medicament](images/screenshot-add_medicament.jpg?raw=true "add_medicament")
###Alarm frequence
![alarm-frequence](images/screenshot-alarm-frequence.jpg?raw=true "alarm-frequence")
###Alarm list
![alarm-list](images/screenshot-alarm-list.jpg?raw=true "alarm-list")
###Alarm medicament
![alarm-medicament](images/screenshot-alarm-medicament.jpg?raw=true "alarm-medicament")
###Gps-hospitals
![gps-hospitals](images/screenshot-gps-hospitals.jpg?raw=true "gps-hospitals")
###Medecament sms
![medecament-sms](images/screenshot-medecament-sms.jpg?raw=true "medecament-sms")
###Medicament history
![medicament-history-untaken](images/screenshot-medicament-history-untaken.jpg?raw=true "medicament-history-untaken")
###Medicament list
![medicament-list](images/screenshot-medicament-list.jpg?raw=true "medicament-list")
###Notification medicament
![notification-medicament](images/screenshot-notification-medicament.jpg?raw=true "notification-medicament")
###Bank list
![bank-list](images/screenshot-bank-list.jpg?raw=true "bank-list")
###Bank view
![bank-view](images/screenshot-bank-view.jpg?raw=true "bank-view")



###Examples code

Medicaments Page (Shared):
```c#
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SeniorAssistance.Database;
using SeniorAssistance.Model;
using Xamarin.Forms;
using SeniorAssistance;

namespace SeniorAssistance
{
	public partial class MedicamentsPage : ContentPage
	{
        MedicamentDatabase database;

        ObservableCollection<Medicament> ListMedicaments { get; set; }

        public MedicamentsPage()
		{
            database = new MedicamentDatabase();
            InitializeComponent();            
            ListMedicaments = new ObservableCollection<Medicament>();
            MedicamentsView.ItemsSource = ListMedicaments;
            
			btnAdd.Clicked += (sender, e) =>
			{
				Navigation.PushAsync(new MedicamentsFormPage());
			};
            MedicamentsView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    var medicament = e.SelectedItem as Medicament;
                    var secondPage = new MedicamentsFormPage();
                    secondPage.BindingContext = medicament;
                    Navigation.PushAsync(secondPage);
                }
            };
            RefreshList();
        }

        protected override void OnAppearing()
        {
            
            base.OnAppearing();
            System.Diagnostics.Debug.WriteLine("*****Here*****");
            
        }

        private void RefreshList()
        {
            ListMedicaments.Clear();
            var items = (from i in database.GetItems<Medicament>()
                         select i);

            foreach (var item in items)
            {
                ListMedicaments.Add(item);
            }
        }
    }
}
```

Main Activity (Android):
```c#
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
          	
			MessagingCenter.Subscribe<StartRunMedicamentAlertTaskMessage>(this, "StartRunMedicamentAlert", message =>
			{
				Console.WriteLine("New Message StartRunMedicamentAlertTaskService Android!");
				var intent = new Intent(this, typeof(StartRunMedicamentAlertTaskService));
				StartService(intent);
			});
			MessagingCenter.Subscribe<SendNotification>(this, "SendNotification", message =>
			{
				Console.WriteLine("SendNotification");
				Notification(message);
			});

            LoadApplication(new App());
			
        }
        
		public void Notification(SendNotification message)
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
                .SetContentTitle(message.Titre)
			    .SetContentText(message.Text)
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
```