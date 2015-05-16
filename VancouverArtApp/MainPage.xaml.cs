using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainViewModel _viewModel;
        //private MobileServiceCollection<art_items, art_items> items;
        private IMobileServiceTable<art_items> artItemsTable = App.MobileService.GetTable<art_items>();


        public MainPage()
        {
            this.InitializeComponent();
            _viewModel = DataContext as MainViewModel;

            Loaded += MainPage_Loaded;
           // AddArtItemsData();

   
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load.Execute(null);
        }

        private async void AddArtItemsData()
        {
            var item1 = new art_items { Title = "The Drop", Artist= "Inges Idee", Latitude= 49.289426, Longitude=-123.114158, ImageUrl= "http://1drv.ms/1d7VwT7", Tags="sculpture", Description= "The 20m tall piece is covered with Styrofoam and blue polyurethane. The sculpture is an homage to the power of nature and represents the relationship and outlook towards the water that surrounds us." };
            await artItemsTable.InsertAsync(item1);

            var item2 = new art_items { Title = "Digital Orca", Artist = "Douglas Coupland", Latitude = 49.289798, Longitude = -123.116801, ImageUrl = "http://1drv.ms/1L9LE6o", Tags = "sculpture", Description = "Made using a steel armature with aluminum cladding, black and white cubes comprise the orca’s body, making a familiar symbol of the West Coast become something unexpected and new." };
            await artItemsTable.InsertAsync(item2);

            var item3 = new art_items { Title = "Light Shed", Artist = "Liz Magor", Latitude = 49.291371, Longitude = -123.123373, ImageUrl = "", Tags = "sculpture", Description = "Constructed mostly of aluminum, it is based on the shape of an old boat shed and at night it glows softly from the inside." };
            await artItemsTable.InsertAsync(item3);
        }

        private async Task InsertArtItem(art_items artItem)
        {
            // This code inserts a new ArtItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await artItemsTable.InsertAsync(artItem);
            //items.Add(artItem);

            //await SyncAsync(); // offline sync
        }

    }
}
