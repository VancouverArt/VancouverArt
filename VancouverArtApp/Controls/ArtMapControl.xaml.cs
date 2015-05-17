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
using Windows.Devices.Geolocation;
using VancouverArtApp.ViewModel;
using Windows.UI.Xaml.Controls.Maps;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VancouverArtApp.Controls
{

    public sealed partial class ArtMapControl : UserControl
    {
        private MainViewModel _viewModel;

        public ArtMapControl()
        {
            this.InitializeComponent();

            DataContextChanged += ArtMapControl_DataContextChanged;
         

            //map.MapServiceToken = "abcdef-abcdefghijklmno";
            map.Center = new Geopoint(new BasicGeoposition {Latitude = 49.285d, Longitude = -123.11d });
            map.ZoomLevel = 13.5d;
        }

        private void ArtMapControl_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            _viewModel = DataContext as MainViewModel;
            //_viewModel.DataLoaded += _viewModel_DataLoaded;
        }

        private void _viewModel_DataLoaded(object sender, EventArgs e)
        {
            foreach (var art in _viewModel.Art)
            {
                MapIcon icon = new MapIcon
                {
                    Location = new Geopoint(new BasicGeoposition { Latitude = art.Latitude, Longitude = art.Longitude }),
                    Title = art.Title,
                    //Image = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/redpin.jpg")),
                    NormalizedAnchorPoint = new Point(0.5d, 1d),
                    CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible,
                    
                };
                map.MapElements.Add(icon);
            }
        }

        private void OnClicked(object sender, TappedRoutedEventArgs e)
        {

            //TODO: call _viewModel to launch DetailPage
            (Window.Current.Content as Frame).Navigate(typeof(DetailPage));
        }
    }
}
