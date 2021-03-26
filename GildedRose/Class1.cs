﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
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
                switch (Items[i].Name)
                {
                    case "Conjured":
                        {
                            UpdateConjured(Items[i]);
                            continue;
                        }
                }
                    if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].Quality > 0)
                        {
                            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;

                            if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                            {
                                if (Items[i].SellIn < 11)
                                {
                                    if (Items[i].Quality < 50)
                                    {
                                        Items[i].Quality = Items[i].Quality + 1;
                                    }
                                }

                                if (Items[i].SellIn < 6)
                                {
                                    if (Items[i].Quality < 50)
                                    {
                                        Items[i].Quality = Items[i].Quality + 1;
                                    }
                                }
                            }
                        }
                    }

                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        Items[i].SellIn = Items[i].SellIn - 1;
                    }

                    if (Items[i].SellIn < 0)
                    {
                        if (Items[i].Name != "Aged Brie")
                        {
                            if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                            {
                                if (Items[i].Quality > 0)
                                {
                                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                    {
                                        Items[i].Quality = Items[i].Quality - 1;
                                    }
                                }
                            }
                            else
                            {
                                Items[i].Quality = Items[i].Quality - Items[i].Quality;
                            }
                        }
                        else
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }
                    }
                }
            }

        private void UpdateConjured(Item item)
        {
            item.SellIn -= 1;
            if (item.SellIn < 0)
                item.Quality -= 4;
            else
                item.Quality -= 2;
            if (item.Quality < 0)
                item.Quality = 0;
        }
    }
    }

    
