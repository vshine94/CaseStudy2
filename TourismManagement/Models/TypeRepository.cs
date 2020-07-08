using System;
using System.Collections.Generic;

namespace TourismManagement.Models
{
    public class TypeRepository :ITypeRepository
    {
        private readonly AppDbContext context;

        public TypeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Type> Gets()
        {
            return context.Types;
        }
    }
}
