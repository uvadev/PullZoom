using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using PullZoom.Util;

namespace PullZoom.Structures;

[PublicAPI]
public class PhoneNumber : ZoomStructure {
    [JsonProperty("assignee")]
    public PhoneNumberAssignee Assignee { get; init; }

    [JsonProperty("capability")]
    public PhoneNumberCapabilities Capabilities { get; init; }

    [CanBeNull]
    [JsonProperty("carrier")]
    public Carrier Carrier { get; init; }

    [JsonProperty("display_name")]
    public string DisplayName { get; init; }

    [CanBeNull]
    [JsonProperty("emergency_address")]
    public EmergencyAddress EmergencyAddress { get; init; }

    [JsonProperty("emergency_address_status")]
    public EmergencyAddressStatus? EmergencyAddressStatus { get; init; }

    [JsonProperty("emergency_address_update_time")]
    public DateTime? EmergencyAddressUpdateTime { get; init; }

    [JsonProperty("id")]
    public string Id { get; init; }

    [JsonProperty("location")]
    public string Location { get; init; }

    [JsonProperty("number")]
    public string Number { get; init; }

    [JsonProperty("number_type")]
    public TollType NumberType { get; init; }

    [CanBeNull]
    [JsonProperty("sip_group")]
    public SipGroup SipGroup { get; init; }

    [CanBeNull]
    [JsonProperty("site")]
    public Site Site { get; init; }
    
    [JsonProperty("source")]
    public PhoneNumberSource Source { get; init; }
    
    [JsonProperty("status")]
    public PhoneNumberStatus Status { get; init; }
}

[PublicAPI]
public class PhoneNumberAssignee : ZoomStructure {
    [JsonProperty("extension_number")]
    public ulong ExtensionNumber { get; init; }

    [JsonProperty("id")]
    public string Id { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("type")]
    public PhoneNumberAssigneeType Type { get; init; }
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<PhoneNumberAssigneeType>))]
public enum PhoneNumberAssigneeType {
    [ZoomApiRepresentation("user")]
    User,
    [ZoomApiRepresentation("callQueue")]
    CallQueue,
    [ZoomApiRepresentation("autoReceptionist")]
    AutoReceptionist,
    [ZoomApiRepresentation("commonArea")]
    CommonArea,
    [ZoomApiRepresentation("emergencyNumberPool")]
    EmergencyNumberPool,
    [ZoomApiRepresentation("companyLocation")]
    CompanyLocation,
    [ZoomApiRepresentation("meetingService")]
    MeetingService
}

[PublicAPI]
[Flags]
[JsonConverter(typeof(ZoomApiFlagsEnumConverter<PhoneNumberCapabilities>))]
public enum PhoneNumberCapabilities {
    [ZoomApiRepresentation("incoming")]
    Incoming,
    [ZoomApiRepresentation("outgoing")]
    Outgoing
}

[PublicAPI]
public class Carrier : ZoomStructure {
    [JsonProperty("code")]
    public long Code { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }
}

[PublicAPI]
public class EmergencyAddress : ZoomStructure {
    [JsonProperty("address_line1")]
    public string AddressLine1 { get; init; }

    [JsonProperty("address_line2")]
    public string AddressLine2 { get; init; }

    [JsonProperty("city")]
    public string City { get; init; }

    [JsonProperty("country")]
    public string Country { get; init; }

    [JsonProperty("state_code")]
    public string StateCode { get; init; }

    [JsonProperty("zip")]
    public string Zip { get; init; }
}

[PublicAPI]
[JsonConverter(typeof(OrdinalZoomApiEnumConverter<EmergencyAddressStatus>))]
public enum EmergencyAddressStatus {
    CarrierUpdateRequired = 1,
    Confirmed = 2
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<TollType>))]
public enum TollType {
    [ZoomApiRepresentation("toll")]
    Toll,
    // ReSharper disable once StringLiteralTypo
    [ZoomApiRepresentation("tollfree")]
    TollFree
}

[PublicAPI]
public class SipGroup : ZoomStructure {
    [JsonProperty("display_name")]
    public string DisplayName { get; init; }

    [JsonProperty("id")]
    public string Id { get; init; }
}

[PublicAPI]
public class Site : ZoomStructure {
    [JsonProperty("id")]
    public string Id { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<PhoneNumberSource>))]
public enum PhoneNumberSource {
    [ZoomApiRepresentation("internal")]
    Internal,
    [ZoomApiRepresentation("external")]
    External
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<PhoneNumberStatus>))]
public enum PhoneNumberStatus {
    [ZoomApiRepresentation("pending")]
    Pending,
    [ZoomApiRepresentation("available")]
    Available
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<PhoneNumberAssignmentStatus>))]
public enum PhoneNumberAssignmentStatus {
    [ZoomApiRepresentation("pending")]
    Assigned,
    [ZoomApiRepresentation("unassigned")]
    Unassigned,
    [ZoomApiRepresentation("byoc")]
    Byoc,
    [ZoomApiRepresentation("all")]
    All
}
