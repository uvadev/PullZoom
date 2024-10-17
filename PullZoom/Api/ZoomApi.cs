using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace PullZoom.Api;

[PublicAPI]
public partial class ZoomApi : IDisposable {
    private readonly HttpClient client;
    private readonly ZoomApiAuthenticator authenticator;
    private ZoomAccessToken token;

    private ZoomApi(ZoomApiAuthenticator authenticator, ZoomAccessToken token) {
        this.token = token;
        this.authenticator = authenticator;
        client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        PopulateClientFromToken();
    }

    public static async Task<ZoomApi> New(ZoomApiAuthenticator authenticator) {
        var token = await authenticator.Authenticate();
        return new ZoomApi(authenticator, token);
    }

    private void PopulateClientFromToken() {
        client.BaseAddress = new Uri(new Uri(token.AccessUrl), "/v2/");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
    }

    public async void RefreshAuth() {
        token = await authenticator.Authenticate();
        PopulateClientFromToken();
    }

    public string GetScope() {
        return token.Scope;
    }
    
    public void Dispose() {
        client?.Dispose();
    }
}
