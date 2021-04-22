Feature: Gilded Rose Kata
	- All items have a SellIn value which denotes the number of days we have to sell the item
	- All items have a Quality value which denotes how valuable the item is
	- At the end of each day our system lowers both values for every item

Pretty simple, right? Well this is where it gets interesting:

	- Once the sell by date has passed, Quality degrades twice as fast
	- The Quality of an item is never negative
	- "Aged Brie" actually increases in Quality the older it gets
	- The Quality of an item is never more than 50
	- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
	- "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
	Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
	Quality drops to 0 after the concert
Just for clarification, an item can never have its Quality increase above 50, however "Sulfuras" is a
legendary item and as such its Quality is 80 and it never alters.

We have recently signed a supplier of conjured items. This requires an update to our system:

	- "Conjured" items degrade in Quality twice as fast as normal items

Scenario Outline: Quality changes each day 
Given item "<name>" with current Quality <cq> and current SellIn <cs>
When a day passes
Then item has revised Quality <rq> and revised Sellin <rs> 
Examples:
| name                                      | cq | cs | rq | rs | notes            |
| Non-specific-item                         | 1               | 1              | 0               | 0              | quality decrease |
| Non-specific-item                         | 0               | 1              | 0               | 0              | never below 0    |
| Non-specific-item                         | 4               | 0              | 2               | -1             | twice as fast    |
| Aged Brie                                 | 4               | 1              | 5               | 0              | increases        |
| Aged Brie                                 | 4               | 0              | 6               | -1             | increases twice  |
| Aged Brie                                 | 4               | -1             | 6               | -2             | increases twice  |
| Aged Brie                                 | 49              | -1             | 50              | -2             | 50 limit         |
| Aged Brie                                 | 50              | -1             | 50              | -2             | 50 limit         |
| Sulfuras, Hand of Ragnaros                | 80              | 1              | 80              | 1              | never changes    |
| Backstage passes to a TAFKAL80ETC concert | 1               | 11             | 2               | 10             | increase by 1    |
| Backstage passes to a TAFKAL80ETC concert | 1               | 10             | 3               | 9              | increase by 2    |
| Backstage passes to a TAFKAL80ETC concert | 1               | 6              | 3               | 5              | increase by 2    |
| Backstage passes to a TAFKAL80ETC concert | 1               | 5              | 4               | 4              | increase by 3    |
| Backstage passes to a TAFKAL80ETC concert | 1               | 0              | 0               | -1             | after concert    |
| Backstage passes to a TAFKAL80ETC concert | 50              | 11             | 50              | 10             | 50 limit         |

Scenario: Quality changes each day alternative 
# current quality cq and current sellIn cs
# revised quality rq and revised sellIn rs
* Quality changes after a day passes for specific items
| name                                      | cq | cs | rq | rs | notes            |
| Non-specific-item                         | 1               | 1              | 0               | 0              | quality decrease |
| Non-specific-item                         | 0               | 1              | 0               | 0              | never below 0    |
| Non-specific-item                         | 4               | 0              | 2               | -1             | twice as fast    |
| Aged Brie                                 | 4               | 1              | 5               | 0              | increases        |
| Aged Brie                                 | 4               | 0              | 6               | -1             | increases twice  |
| Aged Brie                                 | 4               | -1             | 6               | -2             | increases twice  |
| Aged Brie                                 | 49              | -1             | 50              | -2             | 50 limit         |
| Aged Brie                                 | 50              | -1             | 50              | -2             | 50 limit         |
| Sulfuras, Hand of Ragnaros                | 80              | 1              | 80              | 1              | never changes    |
| Backstage passes to a TAFKAL80ETC concert | 1               | 11             | 2               | 10             | increase by 1    |
| Backstage passes to a TAFKAL80ETC concert | 1               | 10             | 3               | 9              | increase by 2    |
| Backstage passes to a TAFKAL80ETC concert | 1               | 6              | 3               | 5              | increase by 2    |
| Backstage passes to a TAFKAL80ETC concert | 1               | 5              | 4               | 4              | increase by 3    |
| Backstage passes to a TAFKAL80ETC concert | 1               | 0              | 0               | -1             | after concert    |
| Backstage passes to a TAFKAL80ETC concert | 50              | 11             | 50              | 10             | 50 limit         |


Scenario: Quality changes each day for items (Type Scenario)
* Quality change type for specific items   
| name                                      | type      |
| Non-specific-item                         | NORMAL    |
| Aged Brie                                 | BRIE      | 
| Sulfuras, Hand of Ragnaros                | LEGACY    | 
| Backstage passes to a TAFKAL80ETC concert | PASS      | 

Scenario: SellIn changes each day except for Sulfuras 
# Current sellIn cs and revised sellIn rs 
* SellIn changes after a day passes 
| type                        | cs   | rs  | notes                       | 
| NORMAL                      | 1    | 0   | SellIn down by 1            | 
| NORMAL                      | -1   | -2  | Regardless of value         |
| NORMAL                      | 100  | 99  | Is there a maximum SellIn?  | 
| LEGACY                      | 1    | 1   | SellIn never changes        | 

Scenario: Quality changes each day for items (Change Scenario) 
* Quality changes after a day passes based on item type  
| type      | cq | cs | rq | notes            |
| NORMAL    | 1  | 1  | 0  | quality decrease |
| NORMAL    | 0  | 1  | 0  | never below 0    |
| NORMAL    | 4  | 0  | 2  | twice as fast    |
| BRIE      | 4  | 1  | 5  | increases        |
| BRIE      | 4  | 0  | 6  | increases twice  |
| BRIE      | 4  | -1 | 6  | increases twice  |
| BRIE      | 49 | -1 | 50 | 50 limit         |
| BRIE      | 50 | -1 | 50 | 50 limit         |
| LEGACY    | 80 | 1  | 80 | never changes    |
| PASS      | 1  | 11 | 2  | increase by 1    |
| PASS      | 1  | 10 | 3  | increase by 2    |
| PASS      | 1  | 6  | 3  | increase by 2    |
| PASS      | 1  | 5  | 4  | increase by 3    |
| PASS      | 1  | 0  | 0  | after concert    |
| PASS      | 50 | 11 | 50 | 50 limit         |

