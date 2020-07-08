using System;
using System.Collections.Generic;

namespace TourismManagement.Models
{
    public interface ITypeRepository
    {
        IEnumerable<Type> Gets();

    }
}
