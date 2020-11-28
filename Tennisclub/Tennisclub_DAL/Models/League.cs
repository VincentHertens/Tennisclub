using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub_DAL.Models
{
    public class League : IModel<byte>
    {
        public byte Id { get; set; } //byte

        public string Name { get; set; }
    }
}
