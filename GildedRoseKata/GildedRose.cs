using System.Collections.Generic;

namespace GildedRoseKata
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
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateItemQuality(Items[i]);
            }
        }
           
        private static void UpdateItemQuality(Item item)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes")
            {
                if (item.Quality > 0)
                {
                    if (item.Name != "Sulfuras")
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes")
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != "Sulfuras")
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes")
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Sulfuras")
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
        public IList<Item> GetItems()
        {
            return this.Items;
        }
    }
}

