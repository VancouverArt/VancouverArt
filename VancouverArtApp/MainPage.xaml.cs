using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using VancouverArtApp.ViewModel;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VancouverArtApp
{
    public static class User
    {
        public static double Latitude;
        public static double Longitude;
    }



    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainViewModel _viewModel;
        //private MobileServiceCollection<art_items, art_items> items;
        private IMobileServiceTable<art_items> artItemsTable = App.MobileService.GetTable<art_items>();

        private Geolocator _locator;

        object mapHeader;
        object listHeader;
        public MainPage()
        {
            this.InitializeComponent();
            _viewModel = DataContext as MainViewModel;

            Loaded += MainPage_Loaded;

            // AddArtItemsData();

            mapHeader = mapPivot.Header;
            listHeader = overviewPivot.Header;

            InitGeolocation();
        }


        private void InitGeolocation()
        {
            _locator = new Geolocator();
            _locator.DesiredAccuracy = PositionAccuracy.High;
            _locator.DesiredAccuracyInMeters = 0;
            _locator.MovementThreshold = 1;
            _locator.ReportInterval = 100;
            _locator.PositionChanged += Locator_PositionChanged;
        }

        private void Locator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            var _ = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                artMapControl.UpdatePosition(args.Position.Coordinate.Point.Position.Latitude, args.Position.Coordinate.Point.Position.Longitude);
            });
        }


        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load.Execute(null);
        }


        private async void AddArtItemsData()
        {
            await artItemsTable.InsertAsync(new art_items { Title = "The Drop", Artist = "Inges Idee", Latitude = 49.289426, Longitude = -123.114158, ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/8c/The_Drop_full_frame_2010.jpg/360px-The_Drop_full_frame_2010.jpg", Tags = "sculpture", Description = "This 20m tall piece is covered with Styrofoam and blue polyurethane. The sculpture is an homage to the power of nature and represents the relationship and outlook towards the water surrounding us." });
            await artItemsTable.InsertAsync(new art_items { Title = "Digital Orca", Artist = "Douglas Coupland", Latitude = 49.289798, Longitude = -123.116801, ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/e/e9/Digital_Orca_Vancouver.jpg/640px-Digital_Orca_Vancouver.jpg", Tags = "sculpture", Description = "Made using a steel armature with aluminum cladding, black and white cubes comprise the orca’s body, making a familiar symbol of the West Coast become something unexpected and new." });
            await artItemsTable.InsertAsync(new art_items { Title = "Monument for East Vancouver", Artist = "Ken Lum", Latitude = 49.269882, Longitude = -123.077683, ImageUrl = "http://timmurphy.wpengine.netdna-cdn.com/wp-content/uploads/2011/07/East-Van-Cross.jpg", Tags = "sculpture", Description = "This 20m tall work lit by LED lights uses a decades-old graffiti motif to pay tribute to the artist's home neighbourhood." });
            await artItemsTable.InsertAsync(new art_items { Title = "Olympic Cauldron", Artist = "", Latitude = 49.289386, Longitude = -123.117669, ImageUrl = "http://photos.wikimapia.org/p/00/02/95/96/19_full.jpg", Tags = "monument", Description = "The 2010 Olympic Cauldron at Jack Poole Plaza is a Vancouver landmark." });
            await artItemsTable.InsertAsync(new art_items { Title = "Trans Am Totem", Artist = "Marcus Bowcott", Latitude = 49.276170, Longitude = -123.102344, ImageUrl = "http://www.vancouverbiennale.com/wp-content/uploads/2015/03/16818492059_45ccf7eaf0_k-798x558.jpg", Tags = "sculpture", Description = "The 10m high sculpture is composed of five scrap cars stacked upon an old growth cedar tree. The artwork considers our consumer “out with the old, in with the new” culture in relation to the site, its history and Vancouver’s evolving identity." });
            await artItemsTable.InsertAsync(new art_items { Title = "Aerodynamic Forms in Space", Artist = "Rodney Graham", Latitude = 49.294663, Longitude = -123.136324, ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Public_art.jpg/512px-Public_art.jpg", Tags = "sculpture", Description = "A 35 foot abstract stainless steel form that replicates a balsa wood toy glider set; abstractly assembled as a modern sculpture." });
            await artItemsTable.InsertAsync(new art_items { Title = "Inukshuk", Artist = "Alvin Kanak", Latitude = 49.284311, Longitude = -123.143734, ImageUrl = "http://images.nationalgeographic.com/wpf/media-live/photos/000/127/cache/vancouver-english-bay-inukshuk_12792_600x450.jpg", Tags = "sculpture", Description = "Built of stacked granite blocks in a human form, Inukshuks are symbols of welcome in the north. This one weighs 31,500 kg and stands 6m high." });
            await artItemsTable.InsertAsync(new art_items { Title = "A-maze-ing Laughter", Artist = "Yue Minjun", Latitude = 49.287609, Longitude = -123.141986, ImageUrl = "http://2.bp.blogspot.com/-VicreWCUqZc/UXhcDWZ2fuI/AAAAAAAADps/jOCTJqONiAw/s640/InstallationArt_Vancouver.jpg", Tags = "sculpture", Description = "Fourteen cast bronze statues depicting the artist's iconic laughing image, with gaping grins and closed eyes in a state of hysterical laughter." });
            await artItemsTable.InsertAsync(new art_items { Title = "Harry Jerome", Artist = "", Latitude = 49.298216, Longitude = -123.119104, ImageUrl = "http://farm5.staticflickr.com/4083/5046042332_1a7947e583_z.jpg", Tags = "monument", Description = "Monument to world record sprinter Harry Jerome." });
            await artItemsTable.InsertAsync(new art_items { Title = "Girl In a Wetsuit", Artist = "Elek Imredy", Latitude = 49.302621, Longitude = -123.125935, ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/7/7f/Girl_in_a_Wetsuit.jpg/607px-Girl_in_a_Wetsuit.jpg", Tags = "sculpture", Description = "Although some mistake it as a replica of Copenhagen's The Little Mermaid, the bronze sculpture depicts a friend of the artist in a wetsuit with flippers and a mask." });
            await artItemsTable.InsertAsync(new art_items { Title = "Centennial Rocket", Artist = "Local 280", Latitude = 49.266027, Longitude = -123.115383, ImageUrl = "http://media-cache-ak0.pinimg.com/736x/69/40/4f/69404f753ca8659efe59f8671b3fb0ce.jpg", Tags = "sculpture", Description = "Centennial Rocket is a reproduction of a sculpture originally built in 1936. It symbolizes the role played by craftsmanship and transportation in the growth of Vancouver." });
            await artItemsTable.InsertAsync(new art_items { Title = "Light Shed", Artist = "Liz Magor", Latitude = 49.291394, Longitude = -123.123339, ImageUrl = "http://farm3.staticflickr.com/2891/10963864026_3940252dcf_z.jpg", Tags = "sculpture", Description = "Based on old boat sheds that used to line the shoreline, the artist cast a ½ scale model in aluminum and coated it with luminescent paint." });
            await artItemsTable.InsertAsync(new art_items { Title = "Spring", Artist = "Alan Chung Hung", Latitude = 49.282093, Longitude = -123.122040, ImageUrl = "http://www.citycaucus.com/images/giant-spring.jpg", Tags = "sculpture", Description = "A large red steel coil which appears to be a spring holding the upper level of Robson Square." });


        }

        private async Task InsertArtItem(art_items artItem)
        {
            // This code inserts a new ArtItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await artItemsTable.InsertAsync(artItem);
            //items.Add(artItem);

            //await SyncAsync(); // offline sync
        }

        private void VisualStateGroup_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            SetStatelayout();

           
        }

        private void SetStatelayout()
        {
            if (VisualStateGroup.CurrentState == Small)
            {
                mapPivot.Header = mapHeader;
                overviewPivot.Header = listHeader;
            }
            else
            {
                mapPivot.Header = null;
                overviewPivot.Header = null;
            }
        }

        private void OnHomeClicked(object sender, RoutedEventArgs e)
        {
            artMapControl.CenterOnCity();
        }

        private CancellationTokenSource _cts = null;

        async private void OnLocationClicked(object sender, RoutedEventArgs e)
        {
            // Request permission to access location 
            var accessStatus = await Geolocator.RequestAccessAsync();
            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                // Get cancellation token 
                _cts = new CancellationTokenSource();
                CancellationToken token = _cts.Token;

                // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used. 
                Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 0 };

                // Carry out the operation 
                Geoposition pos = await geolocator.GetGeopositionAsync().AsTask(token);

                User.Latitude = pos.Coordinate.Latitude;
                User.Longitude = pos.Coordinate.Longitude;
              

                artMapControl.CenterOn(pos);
            }
        }
    }
}
