using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Contracts.Breakfast
{
    public record BreakfastResponse(
        Guid id,
        string Name,
        string Description,
        DateTime StartDateTime,
        DateTime EndDateTime,
        DateTime LastModifiedDateTime,
        List<string> Savory,
        List<string> Sweet
    );
}