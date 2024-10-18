using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using PullZoom.Structures;
using PullZoom.Util;

namespace PullZoom.Api; 

using static Extensions;

public partial class ZoomApi {

    public async Task<CallPathEntry> GetCallPath(string callLogId) {
        var response = await client.GetAsync($"phone/call_history/{callLogId}");
        return await DeserializeObject<CallPathEntry>(response);
    }
    
    public Task<CallPathEntry> GetCallPath(CallLogEntry callLogEntry) {
        return GetCallPath(callLogEntry.Id);
    }
    
    public async IAsyncEnumerable<CallLogEntry> StreamCallHistory(DateTime? from = null,
                                                                  DateTime? to = null,
                                                                  string keyword = null,
                                                                  IEnumerable<ConnectType> connectTypes = null,
                                                                  IEnumerable<PhoneNumberType> numberTypes = null,
                                                                  IEnumerable<CallType> callTypes = null,
                                                                  IEnumerable<ExtensionType> extensionTypes = null,
                                                                  IEnumerable<CallResult> callResults = null,
                                                                  IEnumerable<string> groupIds = null,
                                                                  IEnumerable<string> siteIds = null,
                                                                  string department = null,
                                                                  string costCenter = null,
                                                                  TimeType? timeType = null,
                                                                  RecordingStatus? recordingStatus = null) {
        var baseArgs = new List<(string, string)> {
            ("from", from?.ToIso8601DateWithoutTime()),
            ("to", to?.ToIso8601DateWithoutTime()),
            ("keyword", keyword),
            ("department", department),
            ("cost_center", costCenter),
            ("time_type", timeType?.GetApiRepresentation()),
            ("recording_status", recordingStatus?.GetApiRepresentation())
        };

        if (connectTypes != null) {
            baseArgs.AddRange(connectTypes.Select(connectType => ("connect_types", connectType.GetApiRepresentation())));
        }
        
        if (numberTypes != null) {
            baseArgs.AddRange(numberTypes.Select(numberType => ("number_types", numberType.GetApiRepresentation())));
        }
        
        if (callTypes != null) {
            baseArgs.AddRange(callTypes.Select(callType => ("call_types", callType.GetApiRepresentation())));
        }
        
        if (extensionTypes != null) {
            baseArgs.AddRange(extensionTypes.Select(extensionType => ("extension_types", extensionType.GetApiRepresentation())));
        }
        
        if (callResults != null) {
            baseArgs.AddRange(callResults.Select(callResult => ("call_results", callResult.GetApiRepresentation())));
        }
        
        if (groupIds != null) {
            baseArgs.AddRange(groupIds.Select(groupId => ("group_ids", groupId)));
        }
        
        if (siteIds != null) {
            baseArgs.AddRange(siteIds.Select(siteId => ("site_ids", siteId)));
        }
        
        var requestFunc = async (PaginationArgs p) => {
            var args = p.AsArgs();
            args.AddRange(baseArgs);
            return await client.GetAsync("phone/call_history" + BuildDuplicateKeyQueryString(args.ToArray()));
        };
        
        await foreach (var logEntry in StreamDeserializeListPaginated<CallLogEntry>(requestFunc, "call_logs")) {
            yield return logEntry;
        }
    }
    
    [PublicAPI]
    public enum TimeType {
        [ZoomApiRepresentation("start_time")]
        StartTime,
        [ZoomApiRepresentation("end_time")]
        EndTime
    }
}
