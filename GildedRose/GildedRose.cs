using System;
using System.Collections.Generic;
using System.Text;

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

                Item item = Items[i];
                UpdateQualityForItem(item);
            }
        }

        private static void UpdateQualityForItem(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return;
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                     item.Quality = item.Quality - 1;
            }
            else
            {
                item.Quality = item.Quality + 1;

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 11)
                    {
                        item.Quality = item.Quality + 1;
                    }

                    if (item.SellIn < 6)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }

            }

                item.SellIn = item.SellIn - 1;
           if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                             item.Quality = item.Quality - 1;
                    }
                    else
                    {
                        item.Quality = 0;
                    }
                }
                else
                {
                    item.Quality = item.Quality + 1;
                }
            }
            if (item.Quality < 0)
                item.Quality = 0;
            if (item.Quality > 50)
                item.Quality = 50;
        }
    }
}



