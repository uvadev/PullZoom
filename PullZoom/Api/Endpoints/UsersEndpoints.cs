using System.Collections.Generic;
using PullZoom.Structures;
using PullZoom.Util;

namespace PullZoom.Api; 

using static Extensions;

public partial class ZoomApi {
    public async IAsyncEnumerable<PhoneUser> StreamPhoneUsers(string siteId = null,
                                                              PhoneCallingPlanType? callingType = null,
                                                              PhoneLicenseStatus? status = null,
                                                              string department = null,
                                                              string costCenter = null,
                                                              string keyword = null) {
        var baseArgs = new List<(string, string)> {
            ("site_id", siteId),
            ("calling_type", callingType?.GetOrdinal()?.ToString()),
            ("status", status?.GetApiRepresentation()),
            ("department", department),
            ("cost_center", costCenter),
            ("keyword", keyword)
        }.AsReadOnly();

        var requestFunc = async (PaginationArgs p) => {
            var args = p.AsArgs();
            args.AddRange(baseArgs);
            return await client.GetAsync("phone/users" + BuildDuplicateKeyQueryString(args.ToArray()));
        };
        
        await foreach (var user in StreamDeserializeListPaginated<PhoneUser>(requestFunc, "users")) {
            yield return user;
        }
    }
}