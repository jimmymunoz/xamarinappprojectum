﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SeniorAssistance.Model;
using SeniorAssistance.Database;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using System.Diagnostics.Contracts;

namespace SeniorAssistance
{
	public class CurrentAlertsMedicament
	{
		private static CurrentAlertsMedicament instance { get; set; }
		AlertDatabase database;
		ObservableCollection<Alert> ListAlerts { get; set; }
		ObservableCollection<Alert> ListAlertsValidated { get; set; }

		private CurrentAlertsMedicament()
		{
			database = new AlertDatabase();
			ListAlerts = new ObservableCollection<Alert>();
			ListAlertsValidated = new ObservableCollection<Alert>();
			updateListAlert();
		}

		public static CurrentAlertsMedicament getInstance() {
			if (instance == null)
			{
				instance = new CurrentAlertsMedicament();
			}
			return instance;
		}

		public void updateListAlert()
		{
			ListAlerts.Clear();
            var items = (from i in database.GetItems<Alert>()
						 select i);

            foreach (var item in items)
            {
                ListAlerts.Add(item);
            }
		}

		public Boolean validateAlertByTimeSpam(DateTime time) 
		{
			Boolean valid = false;
			foreach (var alert in ListAlerts) {
				string[] listhour = alert.Hour.Split(':');
				if (time.Hour.Equals(Int32.Parse(listhour[0])) && time.Minute.Equals(Int32.Parse(listhour[1])))
				{
					valid = true;
					setValidatedAlertsByTimeSpam(time);
					break;
				}
			}
			return valid;
		}

		public void setValidatedAlertsByTimeSpam(DateTime time)
		{
			ListAlertsValidated = new ObservableCollection<Alert>();
			foreach (var alert in ListAlerts)
			{
				string[] listhour = alert.Hour.Split(':');
				if (time.Hour.Equals( Int32.Parse(listhour[0]) ) && time.Minute.Equals( Int32.Parse(listhour[1]) ))
				{
					ListAlertsValidated.Add(alert);
					break;
				}
			}
		}

		public async static Task validateAndNotifyAlertsByTimeSpam(CancellationToken token, DateTime time)
		{
			await Task.Run(async () =>
			{
				if (instance.validateAlertByTimeSpam(time))
				{ 
					token.ThrowIfCancellationRequested();
					await Task.Delay(250);

					var message = new TickedMessage
					{
						Message = CurrentAlertsMedicament.getInstance().getValidatedAlerts()
					};

					Device.BeginInvokeOnMainThread(() =>
					{
						MessagingCenter.Send<TickedMessage>(message, "TickedMessage");
					});
				}
			}, token);

		}

		public static object validateAndNotifyAlertsByTimeSpam(DateTime time)
		{
			if (instance.validateAlertByTimeSpam(time))
			{
				var message = new TickedMessage
				{
					Message = CurrentAlertsMedicament.getInstance().getValidatedAlerts()
				};

				Device.BeginInvokeOnMainThread(() =>
				{
					MessagingCenter.Send<TickedMessage>(message, "TickedMessage");
				});
			}
			return "";
		}

		public String getActiveAlerts()
		{
			String result = "";
			foreach (var alert in ListAlerts)
			{
				result += alert.Hour + " - " + alert.Idmedicament + " ";
			}
			return result;
		}

		public String getValidatedAlerts() {
			String result = "";
			foreach (var alert in ListAlertsValidated)
			{
				result += alert.Hour + " - " + alert.Idmedicament + " ";
			}
			return result;
		}
	}
}