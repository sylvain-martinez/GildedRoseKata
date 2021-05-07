namespace GildedRoseKata
{
    internal class ConjuredItemAlter : ItemAlter
    {
        public override void UpdateItemQuality(Item item)
        {
            if (--item.SellIn < 0)
                item.Quality -= 4;
            else
                item.Quality -= 2;

            item.Quality = item.Quality < 0 ? 0 : item.Quality;
        }
    }
}