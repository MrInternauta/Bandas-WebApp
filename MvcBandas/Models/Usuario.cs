﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcBandas.Models
{   //Preparando el uso de Identity
    public class Usuario: IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
