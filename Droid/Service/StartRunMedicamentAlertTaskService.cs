
using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;

namespace SeniorAssistance.Droid
{
	[Service]
	public class StartRunMedicamentAlertTaskService : Service
	{

		CancellationTokenSource _cts;

		public StartRunMedicamentAlertTaskService()
		{
		}

		public override IBinder OnBind(Intent intent)
		{
			return null;
		}

        private void callShared(){
            Console.WriteLine("***************Time Android! " + DateTime.Now);
            CurrentAlertsMedicament.validateAndNotifyAlertsByTimeSpam(_cts.Token, DateTime.Now);
            Console.WriteLine("***************After call Time Android! " + DateTime.Now);
        }

		public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
		{
			Console.WriteLine("OnStartCommand Android!");

			_cts = new CancellationTokenSource();
			
			Task.Run(() =>
			{
				try
				{
                    //INVOKE THE SHARED CODE
                    var timer = new System.Threading.Timer(
						(e) => callShared(),
						null,
						0, (int)TimeSpan.FromMinutes(1).TotalMilliseconds);
                    
                   //var counter = new TaskCounter()
                   //counter.RunCounter(_cts.Token).Wait();
                }
				catch (Android.Accounts.OperationCanceledException)
				{
				}

			}, _cts.Token);

			return StartCommandResult.Sticky;
		}

		public override void OnDestroy()
		{
			if (_cts != null)
			{
				_cts.Token.ThrowIfCancellationRequested();

				_cts.Cancel();
			}
			base.OnDestroy();
		}
	}
}
