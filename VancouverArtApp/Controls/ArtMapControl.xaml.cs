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
         

            map.MapServiceToken = "abcdef-abcdefghijklmno";

            CenterOnCity();
            //ReplaceMapTiles();
        }

        public void CenterOnCity()
        {
            map.Center = new Geopoint(new BasicGeoposition { Latitude = 49.285d, Longitude = -123.11d });
            map.ZoomLevel = 13.5d;
        }

        public void CenterOn(Geoposition pos)
        {
            if (_mapIcon == null)
            {
                _mapIcon = new MapIcon
                {
                    Title = "You are here",
                    //Image = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/redpin.jpg")),
                    NormalizedAnchorPoint = new Point(0.5d, 1d),
                    CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible
                };
                map.MapElements.Add(_mapIcon);
            }
            map.Center = _mapIcon.Location = new Geopoint(new BasicGeoposition { Latitude = pos.Coordinate.Latitude, Longitude = pos.Coordinate.Longitude });
            //map.ZoomLevel = 13.5d;

        }


        private void ReplaceMapTiles()
        {
            var httpsource = new HttpMapTileDataSource("http://api.tiles.mapbox.com/v4/mapbox.light/{zoomlevel}/{x}/{y}.png?access_token=pk.eyJ1Ijoic29tZWd1eW5hbWVkZGF2ZSIsImEiOiIxZTZwa0RnIn0.-T20f-wDGabHoGeYEHn49Q");
            var ts = new MapTileSource(httpsource);
            ts.Layer = MapTileLayer.BackgroundReplacement;
            map.TileSources.Add(ts);
            map.Style = MapStyle.None;
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


        private MapIcon _mapIcon = null;

        public void UpdatePosition(double latitude, double longitude)
        {
            if (_mapIcon == null)
            {
                _mapIcon = new MapIcon
                {
                    Title = "You are here",
                    //Image = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/redpin.jpg")),
                    NormalizedAnchorPoint = new Point(0.5d, 1d),
                    CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible
                };
                map.MapElements.Add(_mapIcon);
            }
            _mapIcon.Location = new Geopoint(new BasicGeoposition { Latitude = latitude, Longitude = longitude });
        }

        private void OnClicked(object sender, TappedRoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(DetailPage), ((art_items)((Grid)sender).DataContext).Id);
        }
    }
}
