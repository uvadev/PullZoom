using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using PullZoom.Structures;
using PullZoom.Util;

using static PullZoom.Util.Extensions;

namespace PullZoom.Api; 

[PublicAPI]
public class ZoomApiAuthenticator : IDisposable {
    private readonly HttpClient client;
    private readonly string accountId;

    public ZoomApiAuthenticator(string accountId, string clientId, string clientSecret, string authUrl = "https://zoom.us/oauth/token") {
        this.accountId = accountId;
        client = new HttpClient();
        client.BaseAddress = new Uri(authUrl);

        var authToken = Base64Encode($"{clientId}:{clientSecret}");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
    }

    public async Task<ZoomAccessToken> Authenticate() {
        var startTime = DateTime.Now;
        
        var response = await client.PostAsync("", BuildHttpArguments(new [] {
            ("grant_type", "account_credentials"),
            ("account_id", accountId)
        }));

        var auth = await DeserializeObject<AuthResponse>(response);
        
        return new ZoomAccessToken {
            Token = auth.AccessToken,
            AccessUrl = auth.ApiUrl,
            ExpiresAt = startTime.AddSeconds(auth.ExpiresIn),
            Scope = auth.Scope
        };
    }
    
    public void Dispose() {
        client?.Dispose();
    }
}
