﻿using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    /// <summary>
    /// Entidad base para representar a una persona
    /// </summary>
    public class Person : Base.BaseInfo
    {
        public TypeIdentification TypeIdentification { get; set; }
        public int NumberIdentification { get; set; }

        // Relación con ubicación geográfica
        public int? NeighborhoodId { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }

        // Propiedades calculadas
        //public string FullName => $"{FirstName} {LastName}";
    }
}