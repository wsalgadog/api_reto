﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_reto.Entitites
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fnacimiento { get; set; }
        public int edad { get; set; }

    }
}
