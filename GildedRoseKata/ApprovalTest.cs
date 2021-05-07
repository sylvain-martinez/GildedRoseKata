using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;

namespace GildedRoseKata
{


    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest
    {
        [Fact]
        public void ThirtyDays()
        {
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();

            Approvals.Verify(output);
        }

        [Fact]
        public void TestWhatTheAppAlreadyDoes()
        {
            var items = new List<Item>
                        {
                            new Item {Name = "Vest", SellIn = 11, Quality = 20},
                            new Item {Name = "Aged Brie", SellIn = 5, Quality = 2},
                            new Item {Name = "Elixi", SellIn = 10, Quality = 5},
                            new Item {Name = "Sulfuras", SellIn = 0, Quality = 80},
                            new Item {Name = "Backstage passes", SellIn = 12, Quality = 22},
                            new Item {Name = "Conjured", SellIn = 3, Quality = 8}
                        };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            var alteredItems = app.GetItems();

            alteredItems[1].Name.Should().Be("Aged Brie");
            alteredItems[1].SellIn.Should().Be(4);
            alteredItems[1].Quality.Should().Be(3);

            alteredItems[3].Name.Should().Be("Sulfuras");
            alteredItems[3].SellIn.Should().Be(0);
            alteredItems[3].Quality.Should().Be(80);

            alteredItems[4].Name.Should().Be("Backstage passes");
            alteredItems[4].SellIn.Should().Be(11);
            alteredItems[4].Quality.Should().Be(23);

            alteredItems[0].Name.Should().Be("Vest");
            alteredItems[0].SellIn.Should().Be(10);
            alteredItems[0].Quality.Should().Be(19);

            alteredItems[2].Name.Should().Be("Elixir");
            alteredItems[2].SellIn.Should().Be(9);
            alteredItems[2].Quality.Should().Be(4);

            alteredItems[5].Name.Should().Be("Conjured");
            alteredItems[5].SellIn.Should().Be(2);
            alteredItems[5].Quality.Should().Be(6);

        }

    }
}
