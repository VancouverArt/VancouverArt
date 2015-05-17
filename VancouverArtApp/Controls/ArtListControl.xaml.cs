using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VancouverArtApp.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VancouverArtApp.Controls
{
    public sealed partial class ArtListControl : UserControl
    {
        public ArtListControl()
        {
            this.InitializeComponent();
        }

        private void OnClick(object sender, ItemClickEventArgs e)
        {
            (DataContext as MainViewModel).SelectedArt = e.ClickedItem as art_items;
            (Window.Current.Content as Frame).Navigate(typeof(DetailPage));
        }
    }
}
