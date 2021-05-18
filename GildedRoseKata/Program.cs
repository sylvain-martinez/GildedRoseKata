using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = "Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras", SellIn = -1, Quality = 80},
                new Item {Name = "Backstage passes", SellIn = 15, Quality = 20},
                new Item {Name = "Backstage passes", SellIn = 10, Quality = 49},
                new Item {Name = "Backstage passes", SellIn = 5, Quality = 49},
				new Item {Name = "Conjured", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}