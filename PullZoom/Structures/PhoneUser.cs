using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using PullZoom.Util;

namespace PullZoom.Structures; 

[PublicAPI]
public class PhoneUser : ZoomStructure {
    [JsonProperty("calling_plans")]
    public IEnumerable<PhoneCallingPlan> CallingPlans { get; init; }
    
    [JsonProperty("email")]
    public string Email { get; init; }
    
    [JsonProperty("extension_id")]
    public string ExtensionId { get; init; }
    
    [JsonProperty("extension_number")]
    public ulong ExtensionNumber { get; init; }
    
    [JsonProperty("id")]
    public string Id { get; init; }
    
    [JsonProperty("name")]
    public string Name { get; init; }
    
    [JsonProperty("site")]
    public Site Site { get; init; }
    
    [JsonProperty("status")]
    public PhoneLicenseStatus Status { get; init; }
    
    [JsonProperty("phone_numbers")]
    public IEnumerable<UserPhoneNumber> PhoneNumbers { get; init; }
    
    [JsonProperty("department")]
    public string Department { get; init; }
    
    [JsonProperty("cost_center")]
    public string CostCenter { get; init; }
}

[PublicAPI]
public class UserPhoneNumber : ZoomStructure {
    [JsonProperty("id")]
    public string Id { get; init; }
    
    [JsonProperty("number")]
    public string Number { get; init; }
}

[PublicAPI]
public class PhoneCallingPlan : ZoomStructure {
    [JsonProperty("name")]
    public string Name { get; init; }
    
    [JsonProperty("type")]
    public PhoneCallingPlanType Type { get; init; }
    
    [JsonProperty("billing_account_id")]
    public string BillingAccountId { get; init; }
    
    [JsonProperty("billing_account_name")]
    public string BillingAccountName { get; init; }
}

[PublicAPI]
[JsonConverter(typeof(ZoomApiEnumConverter<PhoneLicenseStatus>))]
public enum PhoneLicenseStatus {
    [ZoomApiRepresentation("activate")]
    Active,
    [ZoomApiRepresentation("deactivate")]
    Inactive,
    [ZoomApiRepresentation("pending")]
    Pending
}
