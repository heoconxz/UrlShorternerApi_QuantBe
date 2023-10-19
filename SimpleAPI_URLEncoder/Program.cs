using UrlEncoder.Api;

public class Program
{
    //default value
    public static int maxLength = 6;
    public static string baseUrl = "https://example.co/";
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        //getting configuration
        if (builder.Configuration.GetValue<int>("ShrinkUrlSettings:MaxLength") > 0)
            maxLength = builder.Configuration.GetValue<int>("ShrinkUrlSettings:MaxLength");
        if (builder.Configuration.GetValue<string>("ShrinkUrlSettings:BaseUrl") is not null)
            baseUrl = builder.Configuration.GetValue<string>("ShrinkUrlSettings:BaseUrl");

        app.MapGetUrlEndpoints();
        app.Run();
    }
}