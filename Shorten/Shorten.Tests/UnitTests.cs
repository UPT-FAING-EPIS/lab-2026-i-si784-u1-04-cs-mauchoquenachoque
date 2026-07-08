using Xunit;
using Shorten.Areas.Domain;

namespace Shorten.Tests;

public class UnitTests
{
    [Fact]
    public void TestUrlMappingProperties()
    {
        // Arrange
        var mapping = new UrlMapping();

        // Act
        mapping.Id = 1;
        mapping.OriginalUrl = "https://google.com";
        mapping.ShortenedUrl = "https://short.en/google";

        // Assert
        Assert.Equal(1, mapping.Id);
        Assert.Equal("https://google.com", mapping.OriginalUrl);
        Assert.Equal("https://short.en/google", mapping.ShortenedUrl);
    }
}
