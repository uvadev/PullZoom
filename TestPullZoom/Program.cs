using System;
using System.Threading.Tasks;
using PullZoom.Api;
using PullZoom.Structures;

namespace TestPullZoom; 

internal static class Program {
    
    // This program serves as a short demo for use of the library.
        
    public static async Task Main() {
        // Authenticate with Zoom and get a ZoomApi instance. It will be valid for 1 hour by default. To reauthenticate, you can call RefreshAuth().
        var api = await ZoomApi.New(new ZoomApiAuthenticator(
            Environment.GetEnvironmentVariable("ZOOM_ACC"),
            Environment.GetEnvironmentVariable("ZOOM_CLI"),
            Environment.GetEnvironmentVariable("ZOOM_SEC")
        ));
        
        // Print the scopes our app is granted.
        Console.WriteLine(api.GetScope());

        // Print the full list of phone users.
        await foreach (var user in api.StreamPhoneUsers()) {
            Console.WriteLine(user);
        }

        // Pick the first call log entry we receive...
        CallLogEntry e = null;
        await foreach (var logEntry in api.StreamCallHistory()) {
            e = logEntry;
            break;
        }

        if (e == null) {
            return;
        }

        // ...then get the call path and print.
        var path = await api.GetCallPath(e);
        Console.WriteLine(path);

        // Find the first phone user for whom logs exist, then print the full log for that user.
        await foreach (var user in api.StreamPhoneUsers()) {
            bool ok = false;
            
            await foreach (var logEntry in api.StreamUserCallLogs(user.Id)) {
                if (!ok) {
                    ok = true;
                    Console.WriteLine(user);
                }
                
                Console.WriteLine(logEntry);
            }

            if (ok) {
                break;
            }
        }
    }
}