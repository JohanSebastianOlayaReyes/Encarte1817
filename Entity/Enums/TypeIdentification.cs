using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums
{
     public enum TypeIdentification
    {
        [Display(Name = "Cédula de Ciudadanía")]
        cc = 1,

        [Display(Name = "Pasaporte")]
        Pasaporte = 2,

        [Display(Name = "Licencia de Conducir")]
        LicenciaConducir = 3,

        [Display(Name = "RUC")]
        RUC = 4,

        [Display(Name = "Documento Nacional de Identidad")]
        DNI = 5

    }
}
