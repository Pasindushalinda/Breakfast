using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Breakfast.Contracts.Breakfast;
using Breakfast.Models;

namespace Breakfast.Services.Breakfast
{
    public interface IBreakfastService
    {
        void CreateBreakfast(BreakfastModel breakfast);
        BreakfastModel GetBreakfast(Guid id);
        void UpdateBreakfast(BreakfastModel breakfast);
        void DeleteBreakfast(Guid id);
    }
}