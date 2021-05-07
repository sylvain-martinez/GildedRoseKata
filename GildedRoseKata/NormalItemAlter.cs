namespace GildedRoseKata
{
    internal class NormalItemAlter : ItemAlter
    {
        public override void UpdateItemQuality(Item item)
        {
            if (--item.SellIn < 0)
                item.Quality -= 2;
            else
                item.Quality--;

            item.Quality = item.Quality < 0 ? 0 : item.Quality;
        }
    }
}