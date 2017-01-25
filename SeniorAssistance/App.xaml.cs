using System;
using SeniorAssistance.Database;
using Xamarin.Forms;

namespace SeniorAssistance
{
	public partial class App : Application
	{
		
		public App()
		{
			InitializeComponent();

			//MainPage = new SeniorAssistancePage();
			MainPage = new NavigationPage(new HomeLayoutPage());
			//Start Services
			//var message = new StartRunMedicamentAlertTaskMessage();
			//MessagingCenter.Send(message, "StartRunMedicamentAlertTaskMessage");

			HandleReceivedMessages();
		}

		public static void callback(){
			
		}


		protected override void OnStart()
		{
			LoadAlertAlarm();
			CurrentAlertsMedicament.getInstance().updateListAlert();
			var now = DateTime.Now;
			CurrentAlertsMedicament.getInstance().validateAlertByTimeSpam(now);
			//var answer = MainPage.DisplayAlert("Exit", "Now : " + now.Hour + " " + " " + now.Minute + " " + CurrentAlertsMedicament.getInstance().getValidatedAlerts(), "Yes", "No");

			//var answer = MainPage.DisplayAlert("Exit", CurrentAlertsMedicament.getInstance().getActiveAlerts(), "Yes", "No");
			// Handle when your app starts
		}


		protected override void OnSleep()
		{

			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
        public void LoadAlertAlarm()
        {

        }

		void HandleReceivedMessages()
		{
			//Impresion des notifications
			MessagingCenter.Subscribe<TickedMessage>(this, "TickedMessage", message =>
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					MainPage.DisplayAlert("Exit",message.Message, "Yes", "No");
				});
			});
		}

    }
}
