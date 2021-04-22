using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseApp

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
        public enum Type { NORMAL, BRIE, PASS, LEGACY};
        public static Type getType(String itemName)
        {
            switch (itemName)
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
        public static void UpdateQualityForItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            Type type = getType(item.Name);
            UpdateQualityForType(item, type);
        }

        public static void UpdateQualityForType(Item item, Type type)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
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



