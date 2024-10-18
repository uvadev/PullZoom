using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using PullZoom.Util;

namespace PullZoom.Structures; 

[PublicAPI]
public class CallLogEntry : ZoomStructure {
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
    
    [JsonProperty("sbc_id")]
    public string SbcId { get; init; }
    
    [JsonProperty("sbc_name")]
    public string SbcName { get; init; }
    
    [JsonProperty("sip_group_id")]
    public string SipGroupId { get; init; }
    
    [JsonProperty("sip_group_name")]
    public string SipGroupName { get; init; }
    
    [JsonProperty("call_type")]
    public CallType CallType { get; init; }
    
    [JsonProperty("call_result")]
    public CallResult CallResult { get; init; }
    
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
    
    [JsonProperty("caller_number_type")]
    public PhoneNumberType CallerNumberType { get; init; }
    
    [JsonProperty("caller_device_type")]
    public string CallerDeviceType { get; init; }
    
    [JsonProperty("caller_country_iso_code")]
    public string CallerCountryIsoCode { get; init; }
    
    [JsonProperty("caller_country_code")]
    public string CallerCountryCode { get; init; }
    
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
    
    [JsonProperty("callee_number_type")]
    public PhoneNumberType CalleeNumberType { get; init; }
    
    [JsonProperty("callee_device_type")]
    public string CalleeDeviceType { get; init; }
    
    [JsonProperty("callee_country_iso_code")]
    public string CalleeCountryIsoCode { get; init; }
    
    [JsonProperty("callee_country_code")]
    public string CalleeCountryCode { get; init; }
    
    [JsonProperty("client_code")]
    public string ClientCode { get; init; }
    
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
    
    [JsonProperty("spam")]
    public string Spam { get; init; }
    
    [JsonProperty("recording_status")]
    public RecordingStatus RecordingStatus { get; init; }
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<CallDirection>))]
public enum CallDirection {
    [ZoomApiRepresentation("internal")]
    Internal,
    [ZoomApiRepresentation("outbound")]
    Outbound
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<ConnectType>))]
public enum ConnectType {
    [ZoomApiRepresentation("internal")]
    Internal,
    [ZoomApiRepresentation("external")]
    External
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<CallType>))]
public enum CallType {
    [ZoomApiRepresentation("general")]
    General,
    [ZoomApiRepresentation("emergency")]
    Emergency
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<CallResult>))]
public enum CallResult {
    [ZoomApiRepresentation("answered")]
    Answered,
    [ZoomApiRepresentation("connected")]
    Connected,
    [ZoomApiRepresentation("voicemail")]
    Voicemail,
    [ZoomApiRepresentation("hang_up")]
    HangUp,
    [ZoomApiRepresentation("no_answer")]
    NoAnswer,
    [ZoomApiRepresentation("invalid_operation")]
    InvalidOperation,
    [ZoomApiRepresentation("abandoned")]
    Abandoned,
    [ZoomApiRepresentation("blocked")]
    Blocked,
    [ZoomApiRepresentation("service_unavailable")]
    ServiceUnavailable
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<ExtensionType>))]
public enum ExtensionType {
    [ZoomApiRepresentation("user")]
    User,
    [ZoomApiRepresentation("call_queue")]
    CallQueue,
    [ZoomApiRepresentation("auto_receptionist")]
    AutoReceptionist,
    [ZoomApiRepresentation("common_area")]
    CommonArea,
    [ZoomApiRepresentation("zoom_room")]
    ZoomRoom,
    [ZoomApiRepresentation("cisco_room")]
    CiscoRoom,
    [ZoomApiRepresentation("shared_line_group")]
    SharedLineGroup,
    [ZoomApiRepresentation("group_call_pickup")]
    GroupCallPickup,
    [ZoomApiRepresentation("external_contact")]
    ExternalContact,
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<PhoneNumberType>))]
public enum PhoneNumberType {
    [ZoomApiRepresentation("zoom_pstn")]
    ZoomPstn,
    [ZoomApiRepresentation("zoom_toll_free_number")]
    ZoomTollFreeNumber,
    [ZoomApiRepresentation("external_pstn")]
    ExternalPstn,
    [ZoomApiRepresentation("external_contact")]
    ExternalContact,
    [ZoomApiRepresentation("byoc")]
    Byoc,
    [ZoomApiRepresentation("byop")]
    Byop,
    [ZoomApiRepresentation("3rd_party_contact_center")]
    ThirdPartyContactCenter,
    [ZoomApiRepresentation("zoom_service_number")]
    ZoomServiceNumber,
    [ZoomApiRepresentation("external_service_number")]
    ExternalServiceNumber,
    [ZoomApiRepresentation("zoom_contact_center")]
    ZoomContactCenter,
    [ZoomApiRepresentation("meeting_phone_number")]
    MeetingPhoneNumber,
    [ZoomApiRepresentation("meeting_id")]
    MeetingId,
    [ZoomApiRepresentation("anonymous_number")]
    AnonymousNumber,
    [ZoomApiRepresentation("zoom_revenue_accelerator")]
    ZoomRevenueAccelerator,
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<RecordingStatus>))]
public enum RecordingStatus {
    [ZoomApiRepresentation("recorded")]
    Recorded,
    [ZoomApiRepresentation("non_recorded")]
    NonRecorded
}
