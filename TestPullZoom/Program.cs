using System;
using System.Threading.Tasks;
using PullZoom.Api;

namespace TestPullZoom; 

internal static class Program {
        
    public static async Task Main() {
        var api = await ZoomApi.New(new ZoomApiAuthenticator(
            Environment.GetEnvironmentVariable("ZOOM_ACC"),
            Environment.GetEnvironmentVariable("ZOOM_CLI"),
            Environment.GetEnvironmentVariable("ZOOM_SEC")
        ));

        await foreach (var phoneNumber in api.StreamPhoneNumbers()) {
            Console.WriteLine(phoneNumber);
        }
    }
}