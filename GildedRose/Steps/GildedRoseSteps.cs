using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using GildedRoseKata; 
namespace GildedRose.Features
{
    [Binding]
    public class GildedRoseSteps
    {
        String name;
        int currentSellin;
        int currentQuality;
        int revisedSellin;
        int revisedQuality;



        [Given(@"item ""(.*)"" with current Quality (.*) and current SellIn (.*)")]
        public void GivenItemWithCurrentQualityAndCurrentSellIn(string p0, int p1, int p2)
        {
            name = p0;
            currentSellin = p2;
            currentQuality = p1;
        }
        IList<Item> Items = new List<Item>();

        [When(@"a day passes")]
        public void WhenADayPasses()
        {
            Items.Add(new Item { Name = name, SellIn = currentSellin, Quality = currentQuality });
            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
        }
   

    [Then(@"item has revised Quality (.*) and revised Sellin (.*)")]
    public void ThenItemHasRevisedQualityAndRevisedSellin(int p0, int p1)
    {
        revisedSellin = p1;
            revisedQuality = p0;
            Assert.AreEqual(revisedSellin, Items[0].SellIn, "Sellin");
            Assert.AreEqual(revisedQuality, Items[0].Quality, "Quality");
        }
    }
}
