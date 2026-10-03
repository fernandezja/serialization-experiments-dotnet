using System.Text.Json;

namespace SystemTextJsonConsole.Tests
{
    public class SystemTextJsonConsoleTests
    {
        [Fact]
        public void DeserializeConfiguration_MapsAllProperties()
        {
            const string json = """
                {
                  "ApiUrl": "api-url",
                  "ClientId": "client-id",
                  "ClientSecret": "client-secret",
                  "Scope": "scope",
                  "GoogleAndroidClientId": "android-client-id",
                  "GoogleiOSClientId": "ios-client-id",
                  "FacebookClientId": "facebook-client-id",
                  "BranchOfficesMapUrl": "map-url",
                  "Web": "web-url",
                  "Facebook": "facebook-url",
                  "Instagram": "instagram-url",
                  "Twitter": "twitter-url",
                  "Whatsapp": "whatsapp-url"
                }
                """;

            var configuration = Program.DeserializeConfiguration(json);

            Assert.Equal("api-url", configuration.ApiUrl);
            Assert.Equal("client-id", configuration.ClientId);
            Assert.Equal("client-secret", configuration.ClientSecret);
            Assert.Equal("scope", configuration.Scope);
            Assert.Equal("android-client-id", configuration.GoogleAndroidClientId);
            Assert.Equal("ios-client-id", configuration.GoogleiOSClientId);
            Assert.Equal("facebook-client-id", configuration.FacebookClientId);
            Assert.Equal("map-url", configuration.BranchOfficesMapUrl);
            Assert.Equal("web-url", configuration.Web);
            Assert.Equal("facebook-url", configuration.Facebook);
            Assert.Equal("instagram-url", configuration.Instagram);
            Assert.Equal("twitter-url", configuration.Twitter);
            Assert.Equal("whatsapp-url", configuration.Whatsapp);
        }

        [Fact]
        public void DeserializeConfiguration_InvalidJson_ThrowsJsonException()
        {
            Assert.Throws<JsonException>(
                () => Program.DeserializeConfiguration("{ invalid json }"));
        }

        [Fact]
        public void DeserializeConfiguration_NullJson_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => Program.DeserializeConfiguration(null!));
        }

        [Fact]
        public void Main_WritesGreetingAndApiUrl()
        {
            var originalOut = Console.Out;
            using var output = new StringWriter();

            try
            {
                Console.SetOut(output);

                Program.Main([]);
            }
            finally
            {
                Console.SetOut(originalOut);
            }

            var lines = output.ToString().Split(
                Environment.NewLine,
                StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal("Hello World!", lines[0]);
            Assert.Equal("ApiUrl =  http://127.0.0.1:3000", lines[1]);
        }
    }
}
