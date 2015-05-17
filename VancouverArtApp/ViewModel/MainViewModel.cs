using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using VancouverArtApp.DataModel;
using System.Linq;

namespace VancouverArtApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<art_items> _art = new ObservableCollection<art_items>();

        public ObservableCollection<art_items> Art
        {
            get { return _art; }
            set { _art = value; }
        }

        private art_items selectedArt;

        public art_items SelectedArt
        {
            get { return selectedArt; }
            set { selectedArt = value; }
        }


        IArtService _artService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IArtService artService)
        {
            //cut and paste this line to your ctor
            _load = new RelayCommand(ExecLoad, CanLoad);

            _artService = artService;

            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
                ExecLoad();
            }
            else
            {
                // Code runs "for real"
            }
        }


        private RelayCommand _load;
        public RelayCommand Load
        {
            get
            {
                return _load;
            }
        }

        /// <summary>
        /// Checks whether the Load command is executable
        /// </summary>
        private bool CanLoad()
        {
            return true;
        }

        /// <summary>
        /// Executes the Load command 
        /// </summary>
        private async void ExecLoad()
        {
            var art = await _artService.LoadArt();

            foreach (var item in art)
            {
                _art.Add(item);
            }
            SelectedArt = _art.FirstOrDefault();
        }



    }
}