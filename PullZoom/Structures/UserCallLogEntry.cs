using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using PullZoom.Util;

namespace PullZoom.Structures;

// UserCallLogEntry is superficially similar to CallLogEntry, but differs in a multitude of petty ways we can't ignore (e.g., enum members having
// slightly different nomenclature or capitalization) so entirely separate structures are needed.

[PublicAPI]
public class UserCallLogEntry : ZoomStructure {
    [JsonProperty("accepted_by")]
    public UserCallAcceptedBy AcceptedBy { get; init; }

    [JsonProperty("answer_start_time")]
    public DateTime? AnswerStartTime { get; init; }

    [JsonProperty("call_end_time")]
    public DateTime? CallEndTime { get; init; }

    [JsonProperty("call_id")]
    public string CallId { get; init; }

    [JsonProperty("callee_country_code")]
    public string CalleeCountryCode { get; init; }

    [JsonProperty("callee_country_iso_code")]
    public string CalleeCountryIsoCode { get; init; }

    [JsonProperty("callee_did_number")]
    public string CalleeDidNumber { get; init; }

    [JsonProperty("callee_name")]
    public string CalleeName { get; init; }

    [JsonProperty("callee_number")]
    public string CalleeNumber { get; init; }

    [JsonProperty("callee_number_type")]
    public UserCallNumberType CalleeNumberType { get; init; }

    [JsonProperty("callee_number_source")]
    public UserCallNumberSource CalleeNumberSource { get; init; }

    [JsonProperty("caller_country_code")]
    public string CallerCountryCode { get; init; }

    [JsonProperty("caller_country_iso_code")]
    public string CallerCountryIsoCode { get; init; }

    [JsonProperty("caller_did_number")]
    public string CallerDidNumber { get; init; }

    [JsonProperty("caller_name")]
    public string CallerName { get; init; }

    [JsonProperty("caller_number")]
    public string CallerNumber { get; init; }

    [JsonProperty("caller_number_type")]
    public UserCallNumberType CallerNumberType { get; init; }

    [JsonProperty("caller_number_source")]
    public UserCallNumberSource CallerNumberSource { get; init; }

    [JsonProperty("caller_billing_reference_id")]
    public string CallerBillingReferenceId { get; init; }

    [JsonProperty("charge")]
    public string Charge { get; init; }

    [JsonProperty("client_code")]
    public string ClientCode { get; init; }

    [JsonProperty("date_time")]
    public DateTime? CallStartTime { get; init; }

    [JsonProperty("direction")]
    public UserCallDirection? Direction { get; init; }

    [JsonProperty("duration")]
    public ulong Duration { get; init; }

    [JsonProperty("forwarded_by")]
    public UserCallForwardedBy ForwardedBy { get; init; }

    [JsonProperty("forwarded_to")]
    public UserCallOutgoingNode ForwardedTo { get; init; }

    [JsonProperty("id")]
    public string CallLogId { get; init; }

    [JsonProperty("outgoing_by")]
    public UserCallOutgoingNode OutgoingBy { get; init; }

    [JsonProperty("path")]
    public string Path { get; init; }

    [JsonProperty("rate")]
    public string Rate { get; init; }

    [JsonProperty("recording_type")]
    public UserCallRecordingType RecordingType { get; init; }
    
    [JsonProperty("result")]
    public UserCallResult Result { get; init; }
    
    [JsonProperty("site")]
    public Site Site { get; init; }
    
    [JsonProperty("user_id")]
    public string UserId { get; init; }
    
    [JsonProperty("hold_time")]
    public ulong HoldTime { get;init; }
    
    [JsonProperty("waiting_time")]
    public ulong WaitingTime { get; init; }
    
    [JsonProperty("department")]
    public string Department { get; init; }
    
    [JsonProperty("cost_center")]
    public string CostCenter { get; init; }
}

[PublicAPI]
public class UserCallAcceptedBy : ZoomStructure {
    [JsonProperty("extension_number")]
    public string ExtensionNumber { get; init; }

    [JsonProperty("location")]
    public string Location { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("number_type")]
    public UserCallNumberType NumberType { get; init; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; init; }
}

[PublicAPI]
public class UserCallForwardedBy : ZoomStructure {
    [JsonProperty("extension_number")]
    public string ExtensionNumber { get; init; }

    [JsonProperty("extension_type")]
    public UserCallExtensionType ExtensionType { get; init; }

    [JsonProperty("location")]
    public string Location { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("number_type")]
    public UserCallNumberType NumberType { get; init; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; init; }
}

[PublicAPI]
public class UserCallOutgoingNode : ZoomStructure {
    [JsonProperty("extension_number")]
    public string ExtensionNumber { get; init; }

    [JsonProperty("location")]
    public string Location { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("number_type")]
    public UserCallNumberType NumberType { get; init; }

    [JsonProperty("phone_number")]
    public string PhoneNumber { get; init; }
}

[PublicAPI]
[JsonConverter(typeof(OrdinalZoomApiEnumConverter<UserCallNumberType>))]
public enum UserCallNumberType {
    Extension = 1,
    E164Number = 2,
    CustomNumber = 3
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<UserCallNumberSource>))]
public enum UserCallNumberSource {
    [ZoomApiRepresentation("internal")]
    Internal,
    [ZoomApiRepresentation("external")]
    External,
    [ZoomApiRepresentation("byop")]
    Byop
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<UserCallDirection>))]
public enum UserCallDirection {
    [ZoomApiRepresentation("inbound")]
    Inbound,
    [ZoomApiRepresentation("outbound")]
    Outbound
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<UserCallExtensionType>))]
public enum UserCallExtensionType {
    [ZoomApiRepresentation("user")]
    User,
    [ZoomApiRepresentation("callQueue")]
    CallQueue,
    [ZoomApiRepresentation("commonAreaPhone")]
    CommonAreaPhone,
    [ZoomApiRepresentation("autoReceptionist")]
    AutoReceptionist,
    [ZoomApiRepresentation("sharedLineGroup")]
    SharedLineGroup
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<UserCallRecordingType>))]
public enum UserCallRecordingType {
    [ZoomApiRepresentation("OnDemand")]
    OnDemand,
    [ZoomApiRepresentation("Automatic")]
    Automatic
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<UserCallResult>))]
public enum UserCallResult {
    [ZoomApiRepresentation("Missed")]
    Missed,
    [ZoomApiRepresentation("Voicemail")]
    Voicemail,
    [ZoomApiRepresentation("Call connected")]
    CallConnected,
    [ZoomApiRepresentation("Rejected")]
    Rejected,
    [ZoomApiRepresentation("Blocked")]
    Blocked,
    [ZoomApiRepresentation("Busy")]
    Busy,
    [ZoomApiRepresentation("Wrong Number")]
    WrongNumber,
    [ZoomApiRepresentation("No Answer")]
    NoAnswer,
    [ZoomApiRepresentation("International Disabled")]
    InternationalDisabled,
    [ZoomApiRepresentation("Internal Error")]
    InternalError,
    [ZoomApiRepresentation("Call failed")]
    CallFailed,
    [ZoomApiRepresentation("Restricted Number")]
    RestrictedNumber,
    [ZoomApiRepresentation("Call Cancel")]
    CallCancel,
    [ZoomApiRepresentation("Message")]
    Message,
    [ZoomApiRepresentation("Answered by Other Member")]
    AnsweredByOtherMember,
    [ZoomApiRepresentation("Call Cancelled")]
    CallCancelled,
    [ZoomApiRepresentation("Park")]
    Park,
    [ZoomApiRepresentation("Parked")]
    Parked,
    [ZoomApiRepresentation("Blocked by non-GAL")]
    BlockedByNonGal,
    [ZoomApiRepresentation("Blocked by info-Barriers")]
    BlockedByInfoBarriers,
    [ZoomApiRepresentation("Recording Failure")]
    RecordingFailure,
    [ZoomApiRepresentation("Recorded")]
    Recorded,
    [ZoomApiRepresentation("Auto Recorded")]
    AutoRecorded
}
