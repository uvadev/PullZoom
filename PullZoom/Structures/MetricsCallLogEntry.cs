using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using PullZoom.Util;

namespace PullZoom.Structures; 

[PublicAPI]
public class MetricsCallLogEntry : ZoomStructure {
    [JsonProperty("call_id")]
    public string CallId { get; init; }
    
    [JsonProperty("callee")]
    public MetricsCallLogPersonItem Callee { get; init; }
    
    [JsonProperty("caller")]
    public MetricsCallLogPersonItem Caller { get; init; }
    
    [JsonProperty("date_time")]
    public DateTime StartedAt { get; init; }
    
    [JsonProperty("direction")]
    public MetricsCallDirection? Direction { get; init; }
    
    [JsonProperty("duration")]
    public ulong Duration { get; init; }
    
    [JsonProperty("mos")]
    public string Mos { get; init; }
}

[PublicAPI]
public class MetricsCallLogPersonItem : ZoomStructure {
    [JsonProperty("codec")]
    public string Codec { get; init; }
    
    [JsonProperty("device_private_ip")]
    public string DevicePrivateIp { get; init; }
    
    [JsonProperty("device_public_ip")]
    public string DevicePublicIp { get; init; }
    
    [JsonProperty("device_type")]
    public string DeviceType { get; init; }
    
    [JsonProperty("extension_number")]
    public string ExtensionNumber { get; init; }
    
    [JsonProperty("headset")]
    public string Headset { get; init; }
    
    [JsonProperty("isp")]
    public string Isp { get; init; }
    
    [JsonProperty("microphone")]
    public string Microphone { get; init; }
    
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; init; }
    
    [JsonProperty("site_id")]
    public string SiteId { get; init; }
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<MetricsQualityType>))]
public enum MetricsQualityType {
    [ZoomApiRepresentation("good")]
    Good,
    [ZoomApiRepresentation("bad")]
    Bad,
    [ZoomApiRepresentation("all")]
    All
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<MetricsCallDirection>))]
public enum MetricsCallDirection {
    [ZoomApiRepresentation("internal")]
    Internal,
    [ZoomApiRepresentation("outbound")]
    Outbound
}
