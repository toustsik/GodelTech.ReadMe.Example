using System.Linq;
using GodelTech.Microservices.EntityFrameworkCore.Specifications;
using GodelTech.ReadMe.Example.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GodelTech.ReadMe.Example.Data.Specifications
{
    public class PrecipitationSpecification : Specification<Precipitation>
    {
        public string Town { get; set; }

        public int? Temperature { get; set; }

        public bool? IncludePrecipitationType { get; set; }

        public override IQueryable<Precipitation> AddPredicates(IQueryable<Precipitation> query)
        {
            if (Temperature.HasValue)
            {
                query = query.Where(x => x.Temperature == Temperature);
            }

            if (!string.IsNullOrWhiteSpace(Town))
            {
                query = query.Where(x => x.Town.Contains(Town));
            }

            return query;
        }

        public override IQueryable<Precipitation> AddEagerFetching(IQueryable<Precipitation> query)
        {
            if (IncludePrecipitationType.HasValue)
            {
                query = query.Include(x => x.PrecipitationType);
            }

            return query;
        }

        public override IQueryable<Precipitation> AddSorting(IQueryable<Precipitation> query)
        {
            return query.OrderBy(c => c.Town).ThenBy(x => x.Temperature);
        }
    }
}