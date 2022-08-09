using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakfast.Contracts.Breakfast
{
    public record CreateBreakfastRequest(
        string Name,
        string Description,
        DateTime StartDateTime,
        DateTime EndDateTime,
        List<string> Savory,
        List<string> Sweet
    );
}