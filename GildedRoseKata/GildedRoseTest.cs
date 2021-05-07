using Xunit;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Aged Brie", Items[0].Name);
        }
    }
}