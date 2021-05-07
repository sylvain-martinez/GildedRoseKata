using System;

namespace GildedRoseKata
{
    class ItemAlter
    {
        public virtual void UpdateItemQuality(Item item)
        {
            throw new Exception("Unknown Item Type");
        }

        public static Category GetCategory(Item item)
        {
            if (item.Name.Equals("Aged Brie"))
                return Category.AgedBrie;
            else if (item.Name.Equals("Backstage passes"))
                return Category.BackstagePasses;
            else if (item.Name.Equals("Sulfuras"))
                return Category.LegendaryItem;
            else if (item.Name.Equals("Conjured"))
                return Category.ConjuredItem;
            else
                return Category.NormalItem;
        }

        public static ItemAlter GetInstanceFor(Item item)
        {
            if (GetCategory(item) == Category.AgedBrie)
                return new AgedBrieAlter();
            else if (GetCategory(item) == Category.BackstagePasses)
                return new BackstagePassAlter();
            else if (GetCategory(item) == Category.NormalItem)
                return new NormalItemAlter();
            else if (GetCategory(item) == Category.LegendaryItem)
                return new LegendaryItemAlter();
            else if (GetCategory(item) == Category.ConjuredItem)
                return new ConjuredItemAlter();
            else
                return new ItemAlter();
        }
    }
}
