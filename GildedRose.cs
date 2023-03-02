using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            var updater = new ItemUpdater();

            foreach (var item in Items)
            {
                updater.UpdateItemQuality(item);
            }
        }

    }
}
