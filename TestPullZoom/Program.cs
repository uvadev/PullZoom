using System;
using System.Threading.Tasks;
using PullZoom.Api;
using PullZoom.Structures;

namespace TestPullZoom; 

internal static class Program {
        
    public static async Task Main() {
        var api = await ZoomApi.New(new ZoomApiAuthenticator(
            Environment.GetEnvironmentVariable("ZOOM_ACC"),
            Environment.GetEnvironmentVariable("ZOOM_CLI"),
            Environment.GetEnvironmentVariable("ZOOM_SEC")
        ));

        CallLogEntry e = null;
        await foreach (var logEntry in api.StreamCallHistory()) {
            e = logEntry;
            break;
        }

        if (e == null) {
            return;
        }

        var path = await api.GetCallPath(e);
        Console.WriteLine(path);
    }
}