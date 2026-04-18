using System;
using System.Collections.Generic;

namespace GildedTros.App;

public class GildedTros
{
    IList<Item> Items;
    public GildedTros(IList<Item> Items)
    {
        this.Items = Items;
    }
    
    // the above can be simplified to a primary constructor like "public class GildedTros(IList<Item> items)"
    // but I'm keeping it like this for the requirements

    private readonly string[] _smellyItems = ["Duplicate Code", "Long Methods", "Ugly Variable Names"];
    
    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            if (item.Name != "B-DAWG Keychain") item.SellIn--;

            // increase or decrease
            item.Quality = item.Name switch
            {
                "Good Wine" => item.Quality + 1,
                
                var s when s.StartsWith("Backstage passes") => item.SellIn switch
                {
                    < 0 => 0,
                    <= 5 => item.Quality + 3,
                    <= 10 => item.Quality + 2,
                    _ => item.Quality + 1
                },
                
                var s when _smellyItems.Contains(item.Name) => item.SellIn switch
                {
                    < 0 => item.Quality - 4,
                    _ => item.Quality - 2
                },
                
                _ => item.SellIn switch
                {
                    < 0 => item.Quality - 2,
                    _ => item.Quality - 1
                }
            };
            
            // set the limits
            item.Quality = item.Quality switch
            {
                < 0 => 0,
                > 50 => 50,
                _ => item.Quality
            };
            
            // legendary items always have quality 80
            if (item.Name == "B-DAWG Keychain") item.Quality = 80;
        }
    }
}
