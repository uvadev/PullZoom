using System;
using System.Collections.Generic;
using PullZoom.Structures;
using static PullZoom.Util.Extensions;

namespace PullZoom.Api; 

public partial class ZoomApi {
    public async IAsyncEnumerable<PhoneNumber> StreamPhoneNumbers() {
        var requestFunc = async (PaginationParams p) => {
            var args = p.AsArgsArray();
            return await client.GetAsync("phone/numbers" + BuildDuplicateKeyQueryString(args));
        };

        await foreach (var phoneNumber in StreamDeserializeListPaginated<PhoneNumber>(requestFunc, "phone_numbers")) {
            yield return phoneNumber;
        }
    }
}
