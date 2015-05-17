using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VancouverArtApp.ViewModel
{
    public class DetailViewModel : ViewModelBase
    {
        private art_items art;

        public art_items Art
        {
            get { return art; }
            set { art = value; }
        }

    }
}
