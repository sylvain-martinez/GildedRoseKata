namespace GildedRoseKata
{
    internal class AgedBrieAlter : ItemAlter
    {
        public override void UpdateItemQuality(Item item)
        {
            if (--item.SellIn < 0)
            {
                item.Quality += 2;
            }
            else
            {
                item.Quality++;
            }
            item.Quality = (item.Quality > 50) ? 50 : item.Quality;
        }
    }
}