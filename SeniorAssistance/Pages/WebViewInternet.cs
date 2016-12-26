
using System;
using Xamarin.Forms;

namespace SeniorAssistance.Pages

{
    class WebViewInternet : ContentPage
    {
        public WebViewInternet(string UrlView)
        {
            
                Label header = new Label
                {
                    Text = "Internet",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center
                };

                WebView webView = new WebView
                {
                    Source = new UrlWebViewSource
                    {
                        Url = UrlView,
                    },
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                // Accomodate iPhone status bar.
                this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

                // Build the page.
                this.Content = new StackLayout
                {
                    Children =
                {
                    header,
                    webView
                }
                };
            }
        }
    }
