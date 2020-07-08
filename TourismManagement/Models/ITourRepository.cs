using System;
using System.Collections.Generic;

namespace TourismManagement.Models
{
    public interface ITourRepository
    {
        IEnumerable<Tour> Gets();
        Tour Get(int id);
        bool Create(Tour tour);
        bool Edit(Tour tour);
        bool Delete(int id);
    }
}
