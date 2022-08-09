using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Breakfast.Contracts.Breakfast;
using Breakfast.Models;

namespace Breakfast.Services.Breakfast
{
    public class BreakfastService : IBreakfastService
    {
        private static readonly Dictionary<Guid, BreakfastModel> _breakfast = new();
        public void CreateBreakfast(BreakfastModel breakfast)
        {
            _breakfast.Add(breakfast.Id, breakfast);
        }

        public void DeleteBreakfast(Guid id)
        {
            _breakfast.Remove(id);
        }

        public BreakfastModel GetBreakfast(Guid id)
        {
            return _breakfast[id];
        }

        public void UpdateBreakfast(BreakfastModel breakfast)
        {
            _breakfast[breakfast.Id] = breakfast;
        }
    }
}