using Microsoft.AspNetCore.Http.HttpResults;
using UrlEncoder.Api;
namespace UrlEncoder.Tests
{
    public class UrlShorternerTests
    {

        [Fact]
        public void GetUrl_ValidUrl_ShouldReturnShortenedUrl()
        {
            // Arrange
            string originalUrl = "https://www.example.com";

            // Act
            var result = UrlEndPoints.GetUrl(originalUrl);

            // Assert


            var okResult = Assert.IsType<Ok<string>>(result);
            if (okResult is not null)
            {
                var shortUrl = okResult?.Value?.ToString();
                Assert.StartsWith(Program.baseUrl, shortUrl);
            }
        }

        [Fact]
        public void GetUrl_InvalidUrl_ShouldReturnBadRequest()
        {
            // Arrange
            string originalUrl = "invalid-url";

            // Act
            var result = UrlEndPoints.GetUrl(originalUrl);

            // Assert
            var badrequest = Assert.IsType<BadRequest<string>>(result);
            if (badrequest is not null)
            {
                var badRequestResult = badrequest?.Value;
                Assert.Equal("Original URL has an invalid format.", badRequestResult);
            }
        }

        [Fact]
        public void GetUrl_NullUrl_ShouldReturnBadRequest()
        {
            // Arrange
            string originalUrl = null;

            // Act
            var result = UrlEndPoints.GetUrl(originalUrl);

            // Assert
            var badrequest = Assert.IsType<BadRequest<string>>(result);
            if (badrequest is not null)
            {
                var badRequestResult = badrequest?.Value;
                Assert.Equal("Original URL cannot be empty or null.", badRequestResult);
            }
        }


        [Fact]
        public void ShortenUrl_ValidUrl_ShouldReturnShortenedUrl()
        {
            // Arrange
            string originalUrl = "https://www.example.com";
            int maxLength = 6;

            // Act
            string shortenedUrl = UrlEndPoints.ShortenUrl(originalUrl, maxLength);

            // Assert
            Assert.NotNull(shortenedUrl);
            Assert.True(shortenedUrl.Length <= maxLength);
        }

        [Fact]
        public void ShortenUrl_InvalidUrl_ShouldThrowFormatException()
        {
            // Arrange
            string originalUrl = "invalid-url";

            // Act and Assert
            Assert.Throws<FormatException>(() => UrlEndPoints.ShortenUrl(originalUrl));
        }

        [Fact]
        public void ShortenUrl_NullUrl_ShouldThrowArgumentException()
        {
            // Arrange
            string originalUrl = null;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => UrlEndPoints.ShortenUrl(originalUrl));
        }
    }
}