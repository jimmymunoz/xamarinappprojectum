﻿
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

		public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
		{
			Console.WriteLine("OnStartCommand Android!");

			_cts = new CancellationTokenSource();
			CurrentAlertsMedicament.validateAndNotifyAlertsByTimeSpam(_cts.Token, DateTime.Now).Wait();


			Task.Run(() =>
			{
				try
				{
					//INVOKE THE SHARED CODE

					var timer = new System.Threading.Timer(
						//(e) => Console.WriteLine("Time Android! " + DateTime.Now),
						(e) => CurrentAlertsMedicament.validateAndNotifyAlertsByTimeSpam(_cts.Token, DateTime.Now).Wait(),
						null,
						0, (int)TimeSpan.FromMinutes(1).TotalMilliseconds);

					/*
					while (timer != null)
					{
						Console.WriteLine("Time Android! " + DateTime.Now);
						//MainPage.Title = "New " + DateTime.Now;
					}
					*/

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