using Xunit;

namespace GildedTros.App.Tests;

public class GildedTrosTest
{
    [Fact]
    public void UpdateQualitySellIn()
    {
        IList<Item> items = [new() { Name = "foo", SellIn = 1, Quality = 2 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].SellIn); // At the end of each day, SellIn lowers by 1
    }
    
    [Fact]
    public void UpdateQualityDegradation()
    {
        IList<Item> items = [new() { Name = "foo", SellIn = 1, Quality = 10 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(9, items[0].Quality); // At the end of each day, Quality lowers by 1
    }
    
    [Fact]
    public void UpdateQualityDatePassedDegradation()
    {
        IList<Item> items = [new() { Name = "foo", SellIn = 0, Quality = 10 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(8, items[0].Quality); // Once the sell by date has passed, Quality degrades twice as fast
    }
    
    [Fact]
    public void UpdateQualityNoNegativeDegradation()
    {
        IList<Item> items = [new() { Name = "foo", SellIn = 0, Quality = 0 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality); // The Quality of an item is never negative
    }
    
    [Fact]
    public void UpdateQualityGoodWine()
    {
        IList<Item> items = [new() { Name = "Good Wine", SellIn = 0, Quality = 0 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(1, items[0].Quality); // "Good Wine" actually increases in Quality the older it gets
    }
    
    [Fact]
    public void UpdateQualityMaxLimit()
    {
        IList<Item> items = [new() { Name = "Good Wine", SellIn = 0, Quality = 50 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(50, items[0].Quality); // The Quality of an item is never more than 50
    }
    
    [Fact]
    public void UpdateQualityLegendaryQualityDegradation()
    {
        IList<Item> items = [new() { Name = "B-DAWG Keychain", SellIn = 0, Quality = 80 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(80, items[0].Quality); // Legendary items never decrease in quality
    }
    
    [Fact]
    public void UpdateQualityLegendarySellIn()
    {
        IList<Item> items = [new() { Name = "B-DAWG Keychain", SellIn = 0, Quality = 50 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].SellIn); // Legendary items never need to be sold
    }
    
    [Fact]
    public void UpdateQualityBackstagePassesSingleIncrease()
    {
        IList<Item> items = [new() { Name = "Backstage passes", SellIn = 15, Quality = 0 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(1, items[0].Quality); // "Backstage passes" increase in Quality as the SellIn value approaches
    }
    
    [Fact]
    public void UpdateQualityBackstagePassesDoubleIncrease()
    {
        IList<Item> items = [new() { Name = "Backstage passes", SellIn = 10, Quality = 0 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(2, items[0].Quality); // "Backstage passes" increase in Quality by 2 when there are 10 days or less
    }
    
    [Fact]
    public void UpdateQualityBackstagePassesTripleIncrease()
    {
        IList<Item> items = [new() { Name = "Backstage passes", SellIn = 5, Quality = 0 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(3, items[0].Quality); // "Backstage passes" increase in Quality by 3 when there are 5 days or less
    }
    
    [Fact]
    public void UpdateQualityBackstagePassesPastExpiryDate()
    {
        IList<Item> items = [new() { Name = "Backstage passes", SellIn = 0, Quality = 50 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality); // "Backstage passes" Quality drops to 0 after the conference
    }
    
    [Fact]
    public void UpdateQualitySmellyItemDegradation()
    {
        IList<Item> items = [new() { Name = "Duplicate Code", SellIn = 1, Quality = 10 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(8, items[0].Quality); // Smelly items degrade in Quality twice as fast as normal items
    }
    
    [Fact]
    public void UpdateQualitySmellyItemDatePassedDegradation()
    {
        IList<Item> items = [new() { Name = "Long Methods", SellIn = 0, Quality = 10 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(6, items[0].Quality); // Smelly items degrade in Quality twice as fast as normal items
    }

    [Fact]
    public void UpdateQualityLegendaryQuality()
    {
        IList<Item> items = [new() { Name = "B-DAWG Keychain", SellIn = 0, Quality = 0 }];
        var app = new GildedTros(items);
        app.UpdateQuality();
        Assert.Equal(80, items[0].Quality); // Legendary items always have Quality 80
    }
}