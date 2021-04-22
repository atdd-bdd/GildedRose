using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using GildedRoseApp;
using TechTalk.SpecFlow.Assist;

namespace GildedRoseApp.Features
{
    public class Parameters
    {
        public String name { get; set; }
        public int cq { get; set; }
        public int cs { get; set; }
        public int rq { get; set; }
        public int rs { get; set; }
        public String notes { get; set; }
    }

    public class Parameters2
    {
        public String name { get; set; }
        public global::GildedRoseApp.GildedRose.Type type{ get; set; }
    }

    public class Parameters3
    {
        public int cs { get; set; }
        public int rs { get; set; }
         public String notes { get; set; }
        public global::GildedRoseApp.GildedRose.Type type { get; set; }
    }

    public class Parameters4
    {
        public int cq { get; set; }
        public int rq { get; set; }
        public int cs { get; set; }
        public String notes { get; set; }
        public global::GildedRoseApp.GildedRose.Type type { get; set; }
    }

    [Binding]
 
    public static class GildedRoseKataSteps
    {
         [Given(@"Quality changes after a day passes for specific items")]
        static public void GivenQualityChangesAfterADayPassesForSpecificItems(Table table)
        {
 
            var parameters = table.CreateSet<Parameters>();
                foreach (Parameters p in parameters)
            {
                IList<Item> Items = new List<Item>();
                Items.Add(new Item { Name = p.name, SellIn = p.cs, Quality = p.cq });
                global::GildedRoseApp.GildedRose app = new global::GildedRoseApp.GildedRose(Items);
                app.UpdateQuality();
                Assert.AreEqual(p.rs, Items[0].SellIn, "Sellin" + p.notes);
                Assert.AreEqual(p.rq, Items[0].Quality, "Quality" + p.notes);

            }
        }
        [Given(@"Quality change type for specific items")]
        static public void GivenQualityChangeTypeForSpecificItems(Table table)
        {
            var parameters = table.CreateSet<Parameters2>();
            foreach (Parameters2 p in parameters)
            {
                global::GildedRoseApp.GildedRose.Type t = global::GildedRoseApp.GildedRose.getType(p.name);
                
                Assert.AreEqual(t, p.type, " Type ");
                  }        
        }
        [Given(@"SellIn changes after a day passes")]
        static public void GivenSellInChangesAfterADayPasses(Table table)
        {
            var parameters = table.CreateSet<Parameters3>();
            foreach (Parameters3 p in parameters)
            {

                Item item = new Item(); 
                item.SellIn = p.cs;
                global::GildedRoseApp.GildedRose.UpdateQualityForType(item, p.type);
                Assert.AreEqual(p.rs, item.SellIn, p.notes);
             }
        }

        [Given(@"Quality changes after a day passes based on item type")]
        static public void GivenQualityChangesAfterADayPassesBasedOnItemType(Table table)
        {
            var parameters = table.CreateSet<Parameters4>();
            foreach (Parameters4 p in parameters)
            {

                Item item = new Item(); 
                item.Quality = p.cq;
                item.SellIn = p.cs; 
                global::GildedRoseApp.GildedRose.UpdateQualityForType(item, p.type);
                Assert.AreEqual(p.rq, item.Quality, p.notes);
            }
        }


    }
}
