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
            foreach (Item item in Items)
            {
                UpdateItemQuality(item);
            }
        }
           
        private static void UpdateItemQuality(Item item)
        {
            var alter = ItemAlter.GetInstanceFor(item);
            alter.UpdateItemQuality(item);
        }

        public IList<Item> GetItems()
        {
            return this.Items;
        }
    }
}

