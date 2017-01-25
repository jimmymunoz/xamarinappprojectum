using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SeniorAssistance.Model;
using SeniorAssistance.Database;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using System.Diagnostics.Contracts;
//using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

using System.Net.Http;

namespace SeniorAssistance
{
	public class CurrentAlertsMedicament
	{
		private static String urlServer = "http://46.101.40.23/smsenvoi/seniorasissms.php";
		private static CurrentAlertsMedicament instance { get; set; }
		HttpClient client;

		AlertDatabase databaseAlert;
        MedicamentDatabase databaseMedicament;
        MedicamentDatabase databaseMedicamentHistory;
        ObservableCollection<AlertMedicament> ListAlertMedicaments { get; set; }
		ObservableCollection<AlertMedicament> ListAlertsMedicamentValidated { get; set; }

		private CurrentAlertsMedicament()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;

			databaseAlert = new AlertDatabase();
            databaseMedicament = new MedicamentDatabase();
            databaseMedicamentHistory = new MedicamentDatabase();
            ListAlertMedicaments = new ObservableCollection<AlertMedicament>();
			ListAlertsMedicamentValidated = new ObservableCollection<AlertMedicament>();
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
            ListAlertMedicaments.Clear();
            var ListAlerts = (from i in databaseAlert.GetItems<Alert>() select i).Distinct().ToList();
            var ListMedicaments = (from j in databaseMedicament.GetItems<Medicament>() where j.Enabled = true && j.StartDate < DateTime.Now select j).Distinct().ToList();


            foreach (var alert in ListAlerts)
            {
                foreach (var medicament in ListMedicaments)
                {
                    int a = alert.Idmedicament;
                    int m = medicament.ID;
                    if (a.Equals(m))
                    {
                        AlertMedicament alertMedicament = new AlertMedicament();
                        alertMedicament.IdAlert = alert.ID;
                        alertMedicament.Hour = alert.Hour;
                        alertMedicament.Freq = alert.Freq;
                        alertMedicament.Idmedicament = medicament.ID;
                        alertMedicament.Name = medicament.Name;
                        alertMedicament.StartDate = medicament.StartDate;
                        alertMedicament.Enabled = medicament.Enabled;
                        ListAlertMedicaments.Add(alertMedicament);
                        break;
                    }
                }
            }
            
		}

		public Boolean validateAlertByTimeSpam(DateTime time) 
		{
			Boolean valid = false;
			foreach (var alert in ListAlertMedicaments) {
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
			ListAlertsMedicamentValidated = new ObservableCollection<AlertMedicament>();
			foreach (var alert in ListAlertMedicaments)
			{
				string[] listhour = alert.Hour.Split(':');
				if (time.Hour.Equals( Int32.Parse(listhour[0]) ) && time.Minute.Equals( Int32.Parse(listhour[1]) ))
				{
					ListAlertsMedicamentValidated.Add(alert);
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
                    CurrentAlertsMedicament.getInstance().createMedicamentHistoryByAlerts();
                    token.ThrowIfCancellationRequested();
					await Task.Delay(250);

					var message = new TickedMessage
					{
						Message = CurrentAlertsMedicament.getInstance().getValidatedAlerts()
					};
                    /*
					Device.BeginInvokeOnMainThread(() =>
					{
						MessagingCenter.Send<TickedMessage>(message, "TickedMessage");
					});
                    */
				}
			}, token);

		}

		public static object validateAndNotifyAlertsByTimeSpam(DateTime time)
		{
			if (instance.validateAlertByTimeSpam(time))
			{
                CurrentAlertsMedicament.getInstance().createMedicamentHistoryByAlerts();
                var message = new TickedMessage
				{
					Message = CurrentAlertsMedicament.getInstance().getValidatedAlerts()
				};
                /*
				Device.BeginInvokeOnMainThread(() =>
				{
					MessagingCenter.Send<TickedMessage>(message, "TickedMessage");
				});
                */
                }
                return "";
		}

		public String getActiveAlerts()
		{
			String result = "";
			foreach (var alert in ListAlertMedicaments)
			{
				result += alert.Hour + " - " + alert.Idmedicament + " ";
			}
			return result;
		}

		public String getValidatedAlerts() {
			String result = "";
			foreach (var alert in ListAlertsMedicamentValidated)
			{
				result += alert.Hour + " - " + alert.Idmedicament + " ";
			}
			return result;
		}

        public void createMedicamentHistoryByAlerts()
        {
            foreach (var alertMedicament in ListAlertsMedicamentValidated)
            {
                String message = "Please take the medicament [" + alertMedicament.Name + "] (" + alertMedicament.Hour + ")";
                MedicamentHistory medicamentHistory = new MedicamentHistory
                {
                    IdAlert = alertMedicament.IdAlert,
                    Message = message,
                    SendDate = DateTime.Now,
                    Taken = false,
                    ExpireDate = DateTime.Now.AddHours(1),
                    Notified = true
                };

                databaseMedicamentHistory.SaveItem(medicamentHistory);
                //TODO: Send noti
            }

        }

        public async Task sendSms(SMSMessage sms)
		{
			var uri = new Uri(string.Format(urlServer, ""));

			var postData = new List<KeyValuePair<string, string>>();
			postData.Add(new KeyValuePair<string, string>("smsto", sms.smsto));
			postData.Add(new KeyValuePair<string, string>("smsmsg", sms.smsmsg));
			postData.Add(new KeyValuePair<string, string>("smsappname", sms.smsappname));

			HttpContent content = new FormUrlEncodedContent(postData);
			HttpResponseMessage response = null;
			response = await client.PostAsync(uri, content);

			if (response.IsSuccessStatusCode)
				{
					var contentResponse = await response.Content.ReadAsStringAsync();
					Debug.WriteLine("SMS Sent: " + contentResponse);
					//var Items = JsonConvert.DeserializeObject<List<SMSMessage>>(contentResponse);
					//Debug.WriteLine("Response ");
				}
		   }
	}
}
