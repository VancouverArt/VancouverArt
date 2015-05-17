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

            items.Add(new art_items() { Title = "Awesome picture", Artist = "Jan", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent feugiat dui ut accumsan consectetur. Fusce at ipsum dui. Suspendisse varius quam sit amet eros suscipit, in vehicula massa vestibulum. Suspendisse potenti. Nam feugiat urna et ante pretium iaculis. Quisque mattis velit ex, eu interdum leo maximus a. Nunc tempus sem facilisis egestas pulvinar. Pellentesque efficitur elit viverra, tristique ex sit amet, eleifend risus." });
            items.Add(new art_items() { Title = "Me", Artist = "Jan", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent feugiat dui ut accumsan consectetur. Fusce at ipsum dui. Suspendisse varius quam sit amet eros suscipit, in vehicula massa vestibulum. Suspendisse potenti. Nam feugiat urna et ante pretium iaculis. Quisque mattis velit ex, eu interdum leo maximus a. Nunc tempus sem facilisis egestas pulvinar. Pellentesque efficitur elit viverra, tristique ex sit amet, eleifend risus." });
            items.Add(new art_items() { Title = "Awesome picture", Artist = "Jan", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent feugiat dui ut accumsan consectetur. Fusce at ipsum dui. Suspendisse varius quam sit amet eros suscipit, in vehicula massa vestibulum. Suspendisse potenti. Nam feugiat urna et ante pretium iaculis. Quisque mattis velit ex, eu interdum leo maximus a. Nunc tempus sem facilisis egestas pulvinar. Pellentesque efficitur elit viverra, tristique ex sit amet, eleifend risus." });
            items.Add(new art_items() { Title = "Awesome picture", Artist = "Jan", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent feugiat dui ut accumsan consectetur. Fusce at ipsum dui. Suspendisse varius quam sit amet eros suscipit, in vehicula massa vestibulum. Suspendisse potenti. Nam feugiat urna et ante pretium iaculis. Quisque mattis velit ex, eu interdum leo maximus a. Nunc tempus sem facilisis egestas pulvinar. Pellentesque efficitur elit viverra, tristique ex sit amet, eleifend risus." });
            return items;
        }
    }
}
