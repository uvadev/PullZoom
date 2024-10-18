using System;
using System.Collections.Generic;
using PullZoom.Structures;

namespace PullZoom.Api; 

using static Util.Extensions;

public partial class ZoomApi {
    public async IAsyncEnumerable<MetricsCallLogEntry> StreamMetricsCallLogs(DateTime? from = null,
                                                                             DateTime? to = null,
                                                                             string siteId = null,
                                                                             MetricsQualityType? qualityType = null) {
        var baseArgs = new List<(string, string)> {
            ("from", from?.ToIso8601DateWithoutTime()),
            ("to", to?.ToIso8601DateWithoutTime()),
            ("quality_type", qualityType?.GetApiRepresentation()),
            ("site_id", siteId)
        }.AsReadOnly();
        
        var requestFunc = async (PaginationArgs p) => {
            var args = p.AsArgs();
            args.AddRange(baseArgs);
            return await client.GetAsync("phone/metrics/call_logs" + BuildDuplicateKeyQueryString(args.ToArray()));
        };
        
        await foreach (var logEntry in StreamDeserializeListPaginated<MetricsCallLogEntry>(requestFunc, "call_logs")) {
            yield return logEntry;
        }
    }
}
