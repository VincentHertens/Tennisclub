﻿using System;

namespace Tennisclub_DAL.Models
{
    public class League : IModel<byte>
    {
        public byte Id { get; set; } 

        public string Name { get; set; }
    }
}
