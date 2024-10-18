using System.Collections.Generic;
using PullZoom.Structures;
using static PullZoom.Util.Extensions;

namespace PullZoom.Api; 

public partial class ZoomApi {
    public async IAsyncEnumerable<PhoneNumber> StreamPhoneNumbers(PhoneNumberAssignmentStatus? type = null,
                                                                  PhoneNumberAssigneeType? extensionType = null,
                                                                  TollType? numberType = null,
                                                                  bool? pendingNumbers = null,
                                                                  string siteId = null) {
        var baseArgs = new List<(string, string)> {
            ("type", type?.GetApiRepresentation()),
            ("extension_type", extensionType?.GetApiRepresentation()),
            ("number_type", numberType?.GetApiRepresentation()),
            ("pending_numbers", pendingNumbers?.ToStr()),
            ("site_id", siteId)
        }.AsReadOnly();
        
        var requestFunc = async (PaginationArgs p) => {
            var args = p.AsArgs();
            args.AddRange(baseArgs);
            return await client.GetAsync("phone/numbers" + BuildDuplicateKeyQueryString(args.ToArray()));
        };

        await foreach (var phoneNumber in StreamDeserializeListPaginated<PhoneNumber>(requestFunc, "phone_numbers")) {
            yield return phoneNumber;
        }
    }
}
