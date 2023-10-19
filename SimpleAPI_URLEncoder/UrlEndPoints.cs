using SimpleAPI_URLEncoder;

namespace UrlEncoder.Api
{
    /// <summary>
    /// Map and handle GetUrl request
    /// Separation for unit testing
    /// </summary>
    public static class UrlEndPoints
    {
        public static void MapGetUrlEndpoints(this WebApplication app)
        {
            app.MapGet("/api/geturl", GetUrl);
        }
        public static IResult GetUrl(string originalUrl)
        {
            try
            {
                string shortUrl = ShortenUrl(originalUrl, Program.maxLength);
                return Results.Ok(Program.baseUrl + shortUrl);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(ex.Message);
            }
            catch (FormatException ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }
        public static string ShortenUrl(string originalUrl, int maxLength = 6)
        {
            if (string.IsNullOrWhiteSpace(originalUrl))
                throw new ArgumentException("Original URL cannot be empty or null.");

            if (!Uri.TryCreate(originalUrl, UriKind.Absolute, out _))
                throw new FormatException("Original URL has an invalid format.");

            return Cryptography.EncryptUrl(originalUrl, maxLength);
        }
    }
}
