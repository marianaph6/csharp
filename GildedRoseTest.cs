using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {

        [Test]
        public void Quality_Degrades_Twice_As_Fast_Once_SellBy_Date_Passed()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Item Name", SellIn = 0, Quality = 5 } };
            var gildedRose = new GildedRose(items);

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.That(items[0].Quality, Is.EqualTo(3));
        }

        [Test]
        public void QualityOfAnItemIsNeverNegative()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Item", SellIn = 5, Quality = 0 } };
            var gildedRose = new GildedRose(items);

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.GreaterOrEqual(items[0].Quality, 0);
        }

        [Test]
        public void Aged_Brie_Increases_In_Quality_As_It_Gets_Older()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 } };
            var gildedRose = new GildedRose(items);

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.That(items[0].Quality, Is.EqualTo(11));
        }

        [Test]
        public void Quality_Should_Not_Exceed_50()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Item Name", SellIn = 10, Quality = 50 } };
            var gildedRose = new GildedRose(items);

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.That(items[0].Quality, Is.LessThanOrEqualTo(50));
        }

        [Test]
        public void Sulfuras_Never_Has_To_Be_Sold_Or_Decreases_In_Quality()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
            var gildedRose = new GildedRose(items);

            // Act
            gildedRose.UpdateQuality();

            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(10));
            Assert.That(items[0].Quality, Is.EqualTo(80));
        }


        [Test]
        public void Backstage_Passes_Increase_In_Quality_As_SellIn_Value_Approaches()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
            var gildedRose = new GildedRose(items);

            // Act
            gildedRose.UpdateQuality(); // SellIn = 14, Quality = 21
            gildedRose.UpdateQuality(); // SellIn = 13, Quality = 22
            gildedRose.UpdateQuality(); // SellIn = 12, Quality = 23
            gildedRose.UpdateQuality(); // SellIn = 11, Quality = 24
            gildedRose.UpdateQuality(); // SellIn = 10, Quality = 26
            gildedRose.UpdateQuality(); // SellIn = 9, Quality = 28
            gildedRose.UpdateQuality(); // SellIn = 8, Quality = 30
            gildedRose.UpdateQuality(); // SellIn = 7, Quality = 32
            gildedRose.UpdateQuality(); // SellIn = 6, Quality = 35
            gildedRose.UpdateQuality(); // SellIn = 5, Quality = 38
            gildedRose.UpdateQuality(); // SellIn = 4, Quality = 41
            gildedRose.UpdateQuality(); // SellIn = 3, Quality = 44
            gildedRose.UpdateQuality(); // SellIn = 2, Quality = 47
            gildedRose.UpdateQuality(); // SellIn = 1, Quality = 50
            gildedRose.UpdateQuality(); // SellIn = 0, Quality = 0

            // Assert
            Assert.That(items[0].SellIn, Is.EqualTo(0));
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }
    }
}
