using System.Collections.Generic;
using Xunit;

namespace GildedTros.App;

public class GildedTrosTest
{
    [Fact]
    public void foo()
    {
        IList<Item> items = [ new() { Name = "foo", SellIn = 0, Quality = 0 } ];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal("fixme", items[0].Name);
    }
}