using System;

namespace csharp
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }  
    }

    public class ItemUpdater
    {
        private const int MAX_QUALITY = 50;
        private const int MIN_QUALITY = 0;
        private const int SELL_IN_EXPIRED = 0;

        public void UpdateItemQuality(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros") return;

            UpdateSellIn(item);

            switch (item.Name)
            {
                case "Aged Brie":
                    UpdateAgedBrie(item);
                    break;

                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackstagePass(item);
                    break;

                case "Conjured Mana Cake":
                    UpdateConjuredItem(item);
                    break;

                default:
                    UpdateNormalItem(item);
                    break;
            }
        }

        private void UpdateSellIn(Item item)
        {
            item.SellIn--;
        }

        private void UpdateNormalItem(Item item)
        {
            int qualityChange = item.SellIn < SELL_IN_EXPIRED ? 2 : 1;
            DecreaseQuality(item, qualityChange);
        }

        private void UpdateAgedBrie(Item item)
        {
            IncreaseQuality(item);
        }

        private void UpdateBackstagePass(Item item)
        {
            int qualityChange;

            if (item.SellIn < 0)
            {
                item.Quality = MIN_QUALITY;
                return;
            }

            if (item.SellIn < 5)
            {
                qualityChange = 3;
            }
            else if (item.SellIn < 10)
            {
                qualityChange = 2;
            }
            else
            {
                qualityChange = 1;
            }

            IncreaseQuality(item, qualityChange);
        }

        private void UpdateConjuredItem(Item item)
        {
            int qualityChange = item.SellIn < SELL_IN_EXPIRED ? -4 : -2;
            DecreaseQuality(item, qualityChange);
        }

        private void IncreaseQuality(Item item, int amount = 1)
        {
            item.Quality = Math.Min(item.Quality + amount, MAX_QUALITY);
        }

        private void DecreaseQuality(Item item, int amount = 1)
        {
            item.Quality = Math.Max(item.Quality - amount, MIN_QUALITY);
        }
    }
}
