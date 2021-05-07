using FluentAssertions;
using Xunit;

namespace GildedRoseKata
{
    public class ItemAlterTests
    {
        [Theory]
        [InlineData("Vest", 10, 20, 9, 19)]
        [InlineData("Vest", 10, 0, 9, 0)]
        [InlineData("Vest", 0, 20, -1, 18)]
        [InlineData("Elixir", 5, 7, 4, 6)]
        [InlineData("Sulfuras", 0, 80, 0, 80)]
        [InlineData("Conjured", 3, 6, 2, 4)]
        [InlineData("Conjured", 0, 6, -1, 2)]
        [InlineData("Conjured", 0, 2, -1, 0)]
        [InlineData("Aged Brie", 2, 0, 1, 1)]
        [InlineData("Aged Brie", 2, 50, 1, 50)]
        [InlineData("Aged Brie", 0, 40, -1, 42)]
        [InlineData("Backstage passes", 15, 20, 14, 21)]
        [InlineData("Backstage passes", 11, 20, 10, 21)]
        [InlineData("Backstage passes", 10, 20, 9, 22)]
        [InlineData("Backstage passes", 6, 20, 5, 22)]
        [InlineData("Backstage passes", 5, 20, 4, 23)]
        [InlineData("Backstage passes", 3, 49, 2, 50)]

        public void ShouldProcessSellinAndQualityAsPrescribed(string name, int sellin, int quality, int newsellin, int newquality)
        {
            var item = new Item { Name = name, Quality = quality, SellIn = sellin };

            ItemAlter.GetInstanceFor(item).UpdateItemQuality(item);
            item.Name.Should().Be(name);
            item.Quality.Should().Be(newquality);
            item.SellIn.Should().Be(newsellin);
        }

        [Theory]
        [InlineData("Aged Brie", Category.AgedBrie)]
        [InlineData("Backstage passes", Category.BackstagePasses)]
        [InlineData("Sulfuras", Category.LegendaryItem)]
        [InlineData("Conjured", Category.ConjuredItem)]
        [InlineData("Vest", Category.NormalItem)]
        [InlineData("Elixir", Category.NormalItem)]
        public void CanGetItemCategoryFromItemName(string name, Category expectedcategory)
        {
            var item = new Item { Name = name };
            var category = ItemAlter.GetCategory(item);
            category.Should().Be(expectedcategory);
        }

        [Fact]
        public void CreatesAgedBrieProcessorForAgedBrie()
        {
            var item = new Item { Name = "Aged Brie" };
            var alter = ItemAlter.GetInstanceFor(item);
            alter.Should().NotBeNull();
            alter.Should().BeOfType<AgedBrieAlter>();
        }

        [Fact]
        public void LegendaryItemAlterForLegendaryItems()
        {
            var item = new Item { Name = "Sulfuras" };
            var alter = ItemAlter.GetInstanceFor(item);
            alter.Should().NotBeNull();
            alter.Should().BeOfType<LegendaryItemAlter>();
        }

        [Fact]
        public void CreatesBackstagePassAlterForBackstagePasses()
        {
            var item = new Item { Name = "Backstage passes" };

            var alter = ItemAlter.GetInstanceFor(item);
            alter.Should().NotBeNull();
            alter.Should().BeOfType<BackstagePassAlter>();
        }

        [Fact]
        public void ConjuredItemAlterForConjuredItems()
        {
            var item = new Item { Name = "Conjured" };
            var alter = ItemAlter.GetInstanceFor(item);
            alter.Should().NotBeNull();
            alter.Should().BeOfType<ConjuredItemAlter>();
        }

        [Fact]
        public void NormalItemAlterForNormalItems()
        {
            var item = new Item { Name = "Elixir" };
            var alter = ItemAlter.GetInstanceFor(item);
            alter.Should().NotBeNull();
            alter.Should().BeOfType<NormalItemAlter>();
        }

    }
}
