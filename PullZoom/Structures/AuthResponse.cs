using Newtonsoft.Json;

namespace PullZoom.Structures;

internal class AuthResponse : ZoomStructure {
    [JsonProperty("access_token")]
    public string AccessToken { get; init; }

    [JsonProperty("token_type")]
    public string TokenType { get; init; }

    [JsonProperty("expires_in")]
    public ulong ExpiresIn { get; init; }

    [JsonProperty("scope")]
    public string Scope { get; init; }

    [JsonProperty("api_url")]
    public string ApiUrl { get; init; }
}
