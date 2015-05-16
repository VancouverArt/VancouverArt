using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VancouverArtApp.DataModel
{
    public class DummyArtService : IArtService
    {
        public async Task<List<art_items>> LoadArt()
        {
            await Task.Delay(0);
            var items = new List<art_items>();

            items.Add(new art_items() { Title = "Awesome picture", Artist = "Jan" });
            items.Add(new art_items() { Title = "Me", Artist = "Jan" });
            items.Add(new art_items() { Title = "Awesome picture", Artist = "Jan" });
            items.Add(new art_items() { Title = "Awesome picture", Artist = "Jan" });
            return items;
        }
    }
}
