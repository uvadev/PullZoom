using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using PullZoom.Util;

namespace PullZoom.Structures; 

[PublicAPI]
public class CallPathEntry : ZoomStructure {
    [JsonProperty("id")]
    public string Id { get; init; }
    
    [JsonProperty("call_id")]
    public string CallId { get; init; }
    
    [JsonProperty("direction")]
    public CallDirection? Direction { get; init; }
    
    [JsonProperty("international")]
    public bool International { get; init; }
    
    [JsonProperty("start_time")]
    public DateTime StartTime { get; init; }
    
    [JsonProperty("answer_time")]
    public DateTime AnswerTime { get; init; }
    
    [JsonProperty("end_time")]
    public DateTime EndTime { get; init; }
    
    [JsonProperty("duration")]
    public ulong Duration { get; init; }
    
    [JsonProperty("connect_type")]
    public ConnectType ConnectType { get; init; }
    
    [JsonProperty("call_type")]
    public CallType CallType { get; init; }
    
    [JsonProperty("caller_ext_id")]
    public string CallerExtId { get; init; }
    
    [JsonProperty("caller_did_number")]
    public string CallerDidNumber { get; init; }
    
    [JsonProperty("caller_ext_number")]
    public string CallerExtNumber { get; init; }
    
    [JsonProperty("caller_name")]
    public string CallerName { get; init; }
    
    [JsonProperty("caller_email")]
    public string CallerEmail { get; init; }
    
    [JsonProperty("caller_ext_type")]
    public ExtensionType CallerExtType { get; init; }
    
    [JsonProperty("callee_ext_id")]
    public string CalleeExtId { get; init; }
    
    [JsonProperty("callee_did_number")]
    public string CalleeDidNumber { get; init; }
    
    [JsonProperty("callee_ext_number")]
    public string CalleeExtNumber { get; init; }
    
    [JsonProperty("callee_name")]
    public string CalleeName { get; init; }
    
    [JsonProperty("callee_email")]
    public string CalleeEmail { get; init; }
    
    [JsonProperty("callee_ext_type")]
    public ExtensionType CalleeExtType { get; init; }
    
    [JsonProperty("department")]
    public string Department { get; init; }
    
    [JsonProperty("cost_center")]
    public string CostCenter { get; init; }
    
    [JsonProperty("site_id")]
    public string SiteId { get; init; }
    
    [JsonProperty("group_id")]
    public string GroupId { get; init; }
    
    [JsonProperty("site_name")]
    public string SiteName { get; init; }
    
    [JsonProperty("call_path")]
    public IEnumerable<CallPathSegment> CallPath { get; init; }
}

[PublicAPI]
public class CallPathSegment : CallLogEntry {
    [JsonProperty("event")]
    public CallPathEventType Event { get; init; }
    
    [JsonProperty("result")]
    public CallPathEventResult Result { get; init; }
    
    [JsonProperty("result_reason")]
    public CallPathEventReason ResultReason { get; init; }
    
    [JsonProperty("press_key")]
    public string PressKey { get; init; }
    
    [JsonProperty("segment")]
    public ulong Segment { get; init; }
    
    [JsonProperty("node")]
    public ulong Node { get; init; }
    
    [JsonProperty("is_node")]
    public ulong IsNode { get; init; }
    
    [JsonProperty("recording_id")]
    public string RecordingId { get; init; }
    
    [JsonProperty("recording_type")]
    public CallPathEventRecordingType RecordingType { get; init; }
    
    [JsonProperty("hold_time")]
    public ulong HoldTime { get; init; }
    
    [JsonProperty("waiting_time")]
    public ulong WaitingTime { get; init; }
    
    [JsonProperty("voicemail_id")]
    public string VoicemailId { get; init; }
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<CallPathEventType>))]
public enum CallPathEventType {
    [ZoomApiRepresentation("incoming")]
    Incoming,
    [ZoomApiRepresentation("outgoing")]
    Outgoing,
    [ZoomApiRepresentation("forward")]
    Forward,
    [ZoomApiRepresentation("ring_to_member")]
    RingToMember,
    [ZoomApiRepresentation("overflow")]
    Overflow,
    [ZoomApiRepresentation("direct_transfer")]
    DirectTransfer,
    [ZoomApiRepresentation("barge")]
    Barge,
    [ZoomApiRepresentation("monitor")]
    Monitor,
    [ZoomApiRepresentation("whisper")]
    Whisper,
    [ZoomApiRepresentation("listen")]
    Listen,
    [ZoomApiRepresentation("takeover")]
    Takeover,
    [ZoomApiRepresentation("conference_barge")]
    ConferenceBarge,
    [ZoomApiRepresentation("park")]
    Park,
    [ZoomApiRepresentation("timeout")]
    Timeout,
    [ZoomApiRepresentation("park_pick_up")]
    ParkPickUp,
    [ZoomApiRepresentation("merge")]
    Merge,
    [ZoomApiRepresentation("shared")]
    Shared,
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<CallPathEventResult>))]
public enum CallPathEventResult {
    [ZoomApiRepresentation("answered")]
    Answered,
    [ZoomApiRepresentation("accepted")]
    Accepted,
    [ZoomApiRepresentation("picked_up")]
    PickedUp,
    [ZoomApiRepresentation("connected")]
    Connected,
    [ZoomApiRepresentation("succeeded")]
    Succeeded,
    [ZoomApiRepresentation("voicemail")]
    Voicemail,
    [ZoomApiRepresentation("canceled")]
    Canceled,
    [ZoomApiRepresentation("call_failed")]
    CallFailed,
    [ZoomApiRepresentation("rejected")]
    Rejected,
    [ZoomApiRepresentation("busy")]
    Busy,
    [ZoomApiRepresentation("ring_timeout")]
    RingTimeout,
    [ZoomApiRepresentation("overflowed")]
    Overflowed,
    [ZoomApiRepresentation("no_answer")]
    NoAnswer,
    [ZoomApiRepresentation("invalid_key")]
    InvalidKey,
    [ZoomApiRepresentation("abandoned")]
    Abandoned,
    [ZoomApiRepresentation("system_blocked")]
    SystemBlocked,
    [ZoomApiRepresentation("service_unavailable")]
    ServiceUnavailable,
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<CallPathEventReason>))]
public enum CallPathEventReason {
    [ZoomApiRepresentation("answered_by_other")]
    AnsweredByOther,
    [ZoomApiRepresentation("pickup_by_other")]
    PickupByOther,
    [ZoomApiRepresentation("call_out_by_other")]
    CallOutByOther,
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<CallPathEventRecordingType>))]
public enum CallPathEventRecordingType {
    [ZoomApiRepresentation("automatic")]
    Automatic,
    [ZoomApiRepresentation("ad-hoc")]
    AdHoc,
}