using System;
using JetBrains.Annotations;

namespace PullZoom.Api; 

[PublicAPI]
public class ZoomAccessToken {
    public string Token { get; init; }
    public string Scope { get; init; }
    public DateTime ExpiresAt { get; init; }
    public string AccessUrl { get; init; }
}
