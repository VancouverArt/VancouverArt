using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VancouverArtApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailPage : Page
    {
        public DetailPage()
        {
            this.InitializeComponent();
            this.Loaded += DetailPage_Loaded;
        }

        private void DetailPage_Loaded(object sender, RoutedEventArgs e)
        {
            var bla = this.DataContext;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string id = e.Parameter as string;
            
           //TODO: Set DataContext to art_item corresponding with ID == id
    
        }

        private void OnBackClicked(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        async private void OnDirectionsClicked(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            //string uriToLaunch = @"bingmaps:?cp=40.726966~-74.006076&lvl=10";

            art_items art = this.DataContext as art_items;


            string uriToLaunch = String.Format("ms-drive-to:?cp=49.285~-123.11&lvl=15&destination.latitude={0}&destination.longitude={1}&destination.name={2}"
                , art.Latitude, art.Longitude, art.Title);
            var uri = new Uri(uriToLaunch);

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
            if (success)
            {
                // URI launched
            }
            else
            {
                // URI launch failed
            }

        }
    }
}
