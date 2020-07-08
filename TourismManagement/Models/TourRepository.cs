using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TourismManagement.Models
{
    public class TourRepository : ITourRepository
    {
        private readonly AppDbContext context;

        public TourRepository(AppDbContext context)
        {
            this.context = context;
        }

        public bool Create(Tour tour)
        {
            try
            {
                context.Tours.Add(tour);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public bool Delete(int id)
        {
            var delTour = context.Tours.Find(id);
            if(delTour != null)
            {
                context.Remove(delTour);
                context.SaveChanges();
                return true;
            }          
            return false;
        }

        public bool Edit(Tour tour)
        {
            try
            {
                var editTour = context.Tours.Attach(tour);
                editTour.State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Tour Get(int id)
        {
            return context.Tours.Find(id);
        }

        public IEnumerable<Tour> Gets()
        {
           return context.Tours;
        }
    }
}
