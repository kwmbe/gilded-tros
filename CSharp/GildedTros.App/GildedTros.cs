using System.Collections.Generic;

namespace GildedTros.App;

public class GildedTros
{
    IList<Item> Items;
    public GildedTros(IList<Item> Items)
    {
        this.Items = Items;
    }
    
    // the above can be simplified to a primary constructor like public class GildedTros(IList<Item> items)
    // but I'm keeping it like this for the requirements
    
    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            if (item.Name != "Good Wine" 
                && item.Name != "Backstage passes for Re:factor"
                && item.Name != "Backstage passes for HAXX")
            {
                if (item.Quality > 0)
                {
                    if (item.Name != "B-DAWG Keychain")
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes for Re:factor"
                        || item.Name == "Backstage passes for HAXX")
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != "B-DAWG Keychain")
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != "Good Wine")
                {
                    if (item.Name != "Backstage passes for Re:factor"
                        && item.Name != "Backstage passes for HAXX")
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "B-DAWG Keychain")
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }
}
