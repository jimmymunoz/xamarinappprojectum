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
		}

		protected override void OnStart()
		{
            LoadAlertAlarm();
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

    }
}
