using JetBrains.Annotations;
using Newtonsoft.Json;
using PullZoom.Util;

namespace PullZoom.Structures;

// magic numbers reference: https://developers.zoom.us/docs/api/rest/other-references/calling-plans/

[PublicAPI]
[JsonConverter(typeof(OrdinalZoomApiEnumConverter<PhoneCallingPlanType>))]
// ReSharper disable StringLiteralTypo
public enum PhoneCallingPlanType {
    [ZoomApiRepresentation("NO_FEATURE_PACKAGE")]
    NoFeaturePackage = 1,
    [ZoomApiRepresentation("INTERNATIONAL_TOLL_NUMBER")]
    InternationalTollNumber = 3,
    [ZoomApiRepresentation("INTERNATIONAL_TOLL_FREE_NUMBER")]
    InternationalTollFreeNumber = 4,
    [ZoomApiRepresentation("BYOC_NUMBER")]
    ByocNumber = 5,
    [ZoomApiRepresentation("BETA_NUMBER")]
    BetaNumber = 6,
    [ZoomApiRepresentation("METERED_PLAN_US_CA")]
    MeteredPlanUsCa = 100,
    [ZoomApiRepresentation("METERED_PLAN_AU_NZ")]
    MeteredPlanAuNz = 101,
    [ZoomApiRepresentation("METERED_PLAN_GB_IE")]
    MeteredPlanGbIe = 102,
    [ZoomApiRepresentation("METERED_EURA")]
    MeteredEurA = 103,
    [ZoomApiRepresentation("METERED_EURB")]
    MeteredEurB = 104,
    [ZoomApiRepresentation("METERED_JP")]
    MeteredJp = 107,
    [ZoomApiRepresentation("UNLIMITED_PLAN_US_CA")]
    UnlimitedPlanUsCa = 200,
    [ZoomApiRepresentation("UNLIMITED_PLAN_AU_NZ")]
    UnlimitedPlanAuNz = 201,
    [ZoomApiRepresentation("UNLIMITED_PLAN_GB_IE")]
    UnlimitedPlanGbIe = 202,
    [ZoomApiRepresentation("UNLIMITED_EURA")]
    UnlimitedEurA = 203,
    [ZoomApiRepresentation("UNLIMITED_EURB")]
    UnlimitedEurB = 204,
    [ZoomApiRepresentation("UNLIMITED_JP")]
    UnlimitedJp = 207,
    [ZoomApiRepresentation("US_CA_NUMBER")]
    UsCaNumber = 300,
    [ZoomApiRepresentation("AU_NZ_NUMBER")]
    AuNzNumber = 301,
    [ZoomApiRepresentation("GB_IE_NUMBER")]
    GbIeNumber = 302,
    [ZoomApiRepresentation("EURA_NUMBER")]
    EurANumber = 303,
    [ZoomApiRepresentation("EURB_NUMBER")]
    EurBNumber = 304,
    [ZoomApiRepresentation("JP_NUMBER")]
    JpNumber = 307,
    [ZoomApiRepresentation("US_CA_TOLLFREE_NUMBER")]
    UsCaTollFreeNumber = 400,
    [ZoomApiRepresentation("AU_TOLLFREE_NUMBER")]
    AuTollFreeNumber = 401,
    [ZoomApiRepresentation("GB_IE_TOLLFREE_NUMBER")]
    GbIeTollFreeNumber = 402,
    [ZoomApiRepresentation("NZ_TOLLFREE_NUMBER")]
    NzTollFreeNumber = 403,
    [ZoomApiRepresentation("GLOBAL_TOLLFREE_NUMBER")]
    GlobalTollFreeNumber = 404,
    [ZoomApiRepresentation("BETA")]
    Beta = 600,
    [ZoomApiRepresentation("UNLIMITED_DOMESTIC_SELECT")]
    UnlimitedDomesticSelect = 1000,
    [ZoomApiRepresentation("METERED_GLOBAL_SELECT")]
    MeteredGlobalSelect = 1001,
    [ZoomApiRepresentation("UNLIMITED_DOMESTIC_SELECT_NUMBER")]
    UnlimitedDomesticSelectNumber = 2000,
    [ZoomApiRepresentation("ZP_PRO")]
    ZpPro = 3000,
    [ZoomApiRepresentation("BASIC")]
    Basic = 3010,
    [ZoomApiRepresentation("ZP_COMMON_AREA")]
    ZpCommonArea = 3040,
    [ZoomApiRepresentation("RESERVED_PLAN")]
    ReservedPlan = 3098,
    [ZoomApiRepresentation("BASIC_MIGRATED")]
    BasicMigrated = 3099,
    [ZoomApiRepresentation("INTERNATIONAL_SELECT_ADDON")]
    InternationalSelectAddon = 4000,
    [ZoomApiRepresentation("ZP_POWER_USER")]
    ZpPowerUser = 4010,
    [ZoomApiRepresentation("ZP_PREMIUM_ADDON")]
    ZpPremiumAddon = 4010,
    [ZoomApiRepresentation("ZP_POWER_PACK")]
    ZpPowerPack = 4010,
    [ZoomApiRepresentation("PREMIUM_NUMBER")]
    PremiumNumber = 5000,
    [ZoomApiRepresentation("METERED_US_CA_NUMBER_INCLUDED")]
    MeteredUsCaNumberIncluded = 30000,
    [ZoomApiRepresentation("METERED_AU_NZ_NUMBER_INCLUDED")]
    MeteredAuNzNumberIncluded = 30001,
    [ZoomApiRepresentation("METERED_GB_IE_NUMBER_INCLUDED")]
    MeteredGbIeNumberIncluded = 30002,
    [ZoomApiRepresentation("METERED_EURA_NUMBER_INCLUDED")]
    MeteredEurANumberIncluded = 30003,
    [ZoomApiRepresentation("METERED_EURB_NUMBER_INCLUDED")]
    MeteredEurBNumberIncluded = 30004,
    [ZoomApiRepresentation("METERED_JP_NUMBER_INCLUDED")]
    MeteredJpNumberIncluded = 30007,
    [ZoomApiRepresentation("UNLIMITED_US_CA_NUMBER_INCLUDED")]
    UnlimitedUsCaNumberIncluded = 31000,
    [ZoomApiRepresentation("UNLIMITED_AU_NZ_NUMBER_INCLUDED")]
    UnlimitedAuNzNumberIncluded = 31001,
    [ZoomApiRepresentation("UNLIMITED_GB_IE_NUMBER_INCLUDED")]
    UnlimitedGbIeNumberIncluded = 31002,
    [ZoomApiRepresentation("UNLIMITED_EURA_NUMBER_INCLUDED")]
    UnlimitedEurANumberIncluded = 31003,
    [ZoomApiRepresentation("UNLIMITED_EURB_NUMBER_INCLUDED")]
    UnlimitedEurBNumberIncluded = 31004,
    [ZoomApiRepresentation("UNLIMITED_JP_NUMBER_INCLUDED")]
    UnlimitedJpNumberIncluded = 31007,
    [ZoomApiRepresentation("UNLIMITED_DOMESTIC_SELECT_NUMBER_INCLUDED")]
    UnlimitedDomesticSelectNumberIncluded = 31005,
    [ZoomApiRepresentation("METERED_GLOBAL_SELECT_NUMBER_INCLUDED")]
    MeteredGlobalSelectNumberIncluded = 31006,
    [ZoomApiRepresentation("MEETINGS_PRO_UNLIMITED_US_CA")]
    MeetingsProUnlimitedUsCa = 40200,
    [ZoomApiRepresentation("MEETINGS_PRO_UNLIMITED_AU_NZ")]
    MeetingsProUnlimitedAuNz = 40201,
    [ZoomApiRepresentation("MEETINGS_PRO_UNLIMITED_GB_IE")]
    MeetingsProUnlimitedGbIe = 40202,
    [ZoomApiRepresentation("MEETINGS_PRO_UNLIMITED_JP")]
    MeetingsProUnlimitedJp = 40207,
    [ZoomApiRepresentation("MEETINGS_PRO_GLOBAL_SELECT")]
    MeetingsProGlobalSelect = 41000,
    [ZoomApiRepresentation("MEETINGS_PRO_PN_PRO")]
    MeetingsProPnPro = 43000,
    [ZoomApiRepresentation("MEETINGS_BUS_UNLIMITED_US_CA")]
    MeetingsBusUnlimitedUsCa = 50200,
    [ZoomApiRepresentation("MEETINGS_BUS_UNLIMITED_AU_NZ")]
    MeetingsBusUnlimitedAuNz = 50201,
    [ZoomApiRepresentation("MEETINGS_BUS_UNLIMITED_GB_IE")]
    MeetingsBusUnlimitedGbIe = 50202,
    [ZoomApiRepresentation("MEETINGS_BUS_UNLIMITED_JP")]
    MeetingsBusUnlimitedJp = 50207,
    [ZoomApiRepresentation("MEETINGS_BUS_GLOBAL_SELECT")]
    MeetingsBusGlobalSelect = 51000,
    [ZoomApiRepresentation("MEETINGS_BUS_PN_PRO")]
    MeetingsBusPnPro = 53000,
    [ZoomApiRepresentation("MEETINGS_ENT_UNLIMITED_US_CA")]
    MeetingsEntUnlimitedUsCa = 60200,
    [ZoomApiRepresentation("MEETINGS_ENT_UNLIMITED_AU_NZ")]
    MeetingsEntUnlimitedAuNz = 60201,
    [ZoomApiRepresentation("MEETINGS_ENT_UNLIMITED_GB_IE")]
    MeetingsEntUnlimitedGbIe = 60202,
    [ZoomApiRepresentation("MEETINGS_ENT_UNLIMITED_JP")]
    MeetingsEntUnlimitedJp = 60207,
    [ZoomApiRepresentation("MEETINGS_ENT_GLOBAL_SELECT")]
    MeetingsEntGlobalSelect = 61000,
    [ZoomApiRepresentation("MEETINGS_ENT_PN_PRO")]
    MeetingsEntPnPro = 63000,
    [ZoomApiRepresentation("MEETINGS_US_CA_NUMBER_INCLUDED")]
    MeetingsUsCaNumberIncluded = 70200,
    [ZoomApiRepresentation("MEETINGS_AU_NZ_NUMBER_INCLUDED")]
    MeetingsAuNzNumberIncluded = 70201,
    [ZoomApiRepresentation("MEETINGS_GB_IE_NUMBER_INCLUDED")]
    MeetingsGbIeNumberIncluded = 70202,
    [ZoomApiRepresentation("MEETINGS_JP_NUMBER_INCLUDED")]
    MeetingsJpNumberIncluded = 70207,
    [ZoomApiRepresentation("MEETINGS_GLOBAL_SELECT_NUMBER_INCLUDED")]
    MeetingsGlobalSelectNumberIncluded = 71000,
}
