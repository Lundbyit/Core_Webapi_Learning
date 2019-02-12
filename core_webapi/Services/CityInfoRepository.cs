using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_webapi.Entities;
using Microsoft.EntityFrameworkCore;

namespace core_webapi.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }

        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityId, false);
            city.PointsOfInterest.Add(pointOfInterest);
        }

        public bool CityExists(int id)
        {
            return _context.Cities.Any(c => c.Id == id);
        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int id, bool includePointOfInterest)
        {
            if (includePointOfInterest)
            {
                return _context.Cities.Include(c => c.PointsOfInterest)
                    .Where(c => c.Id == id)
                    .FirstOrDefault();
            }

            return _context.Cities.FirstOrDefault(c => c.Id == id);
        }

        public PointOfInterest GetPointOfInterest(int cityId, int id)
        {
            return _context.PointsOfInterest.Where(p => p.CityId == cityId && p.Id == id).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterest(int cityId)
        {
            return _context.PointsOfInterest.Where(p => p.CityId == cityId).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
