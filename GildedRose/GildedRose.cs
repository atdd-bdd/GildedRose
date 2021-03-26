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
        enum Type { NORMAL, BRIE, PASS, LEGACY};
        static Type getType(Item item)
        {
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    return Type.LEGACY;
                case "Aged Brie":
                    return Type.BRIE;
                case "Backstage passes to a TAFKAL80ETC concert":
                    return Type.PASS;
                default:
                    return Type.NORMAL; 
            }
        }
        private static void UpdateQualityForItem(Item item)
        {
            Type type = getType(item); 
           if (type == Type.LEGACY)
                return;
            if (type != Type.BRIE &&
                type != Type.PASS)
                      item.Quality = item.Quality - 1;
            else
            {
                item.Quality = item.Quality + 1;

                if (type == Type.PASS)
                {
                    if (item.SellIn < 11)
                        item.Quality = item.Quality + 1;
  
                    if (item.SellIn < 6)
                        item.Quality = item.Quality + 1;
                 }

            }

           item.SellIn = item.SellIn - 1;
           if (item.SellIn < 0)
            {
                if (type != Type.BRIE)
                {
                    if (type != Type.PASS)
                             item.Quality = item.Quality - 1;
                    else
                         item.Quality = 0;
                 }
                else
                    item.Quality = item.Quality + 1;
             }
            if (item.Quality < 0)
                item.Quality = 0;
            if (item.Quality > 50)
                item.Quality = 50;
        }
    }
}



