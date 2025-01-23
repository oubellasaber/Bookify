﻿using Bookify.Domain.Abstraction;

namespace Bookify.Domain.Apartments
{
    public static class ApartmentErrors
    {
        public static readonly Error NotFound = new(
            "Property.NotFound",
            "The property with the specified identifier was not found");
    }
}
