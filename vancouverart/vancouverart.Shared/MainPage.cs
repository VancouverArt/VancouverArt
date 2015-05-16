using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// To add offline sync support, add the NuGet package Microsoft.WindowsAzure.MobileServices.SQLiteStore
// to your project. Then, uncomment the lines marked // offline sync
// For more information, see: http://aka.ms/addofflinesync
//using Microsoft.WindowsAzure.MobileServices.SQLiteStore;  // offline sync
//using Microsoft.WindowsAzure.MobileServices.Sync;         // offline sync

namespace vancouverart
{
    sealed partial class MainPage: Page
    {
        private MobileServiceCollection<art_items, art_items> items;
        private IMobileServiceTable<art_items> todoTable = App.MobileService.GetTable<art_items>();
        //private IMobileServiceSyncTable<ArtItem> todoTable = App.MobileService.GetSyncTable<ArtItem>(); // offline sync

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async Task InsertArtItem(art_items ArtItem)
        {
            // This code inserts a new ArtItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await todoTable.InsertAsync(ArtItem);
            items.Add(ArtItem);

            //await SyncAsync(); // offline sync
        }

        private async Task RefreshArtItems()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the ArtItems table.
                // The query excludes completed ArtItems
                items = await todoTable
                    //.Where(ArtItem => ArtItem.Complete == false)
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }
            else
            {
                ListItems.ItemsSource = items;
                this.ButtonSave.IsEnabled = true;
            }
        }

        private async Task UpdateCheckedArtItem(art_items item)
        {
            // This code takes a freshly completed ArtItem and updates the database. When the MobileService 
            // responds, the item is removed from the list 
            await todoTable.UpdateAsync(item);
            items.Remove(item);
            ListItems.Focus(Windows.UI.Xaml.FocusState.Unfocused);

            //await SyncAsync(); // offline sync
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            ButtonRefresh.IsEnabled = false;

            //await SyncAsync(); // offline sync
            await RefreshArtItems();

            ButtonRefresh.IsEnabled = true;
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var ArtItem = new art_items { Title = TextInput.Text };
            await InsertArtItem(ArtItem);
        }

        private async void CheckBoxComplete_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            art_items item = cb.DataContext as art_items;
            await UpdateCheckedArtItem(item);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //await InitLocalStoreAsync(); // offline sync
            await RefreshArtItems();
        }

        #region Offline sync

        //private async Task InitLocalStoreAsync()
        //{
        //    if (!App.MobileService.SyncContext.IsInitialized)
        //    {
        //        var store = new MobileServiceSQLiteStore("localstore.db");
        //        store.DefineTable<ArtItem>();
        //        await App.MobileService.SyncContext.InitializeAsync(store);
        //    }
        //
        //    await SyncAsync();
        //}

        //private async Task SyncAsync()
        //{
        //    await App.MobileService.SyncContext.PushAsync();
        //    await todoTable.PullAsync("ArtItems", todoTable.CreateQuery());
        //}

        #endregion 
    }
}
