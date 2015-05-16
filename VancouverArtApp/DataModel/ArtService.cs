using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VancouverArtApp.DataModel
{
    public class ArtService : IArtService
    {
        private MobileServiceCollection<art_items, art_items> items;
        private IMobileServiceTable<art_items> todoTable = App.MobileService.GetTable<art_items>();


        public async Task<List<art_items>> LoadArt()
        {
            items = await todoTable.ToCollectionAsync();

            return items.ToList();
        }
    }
}
