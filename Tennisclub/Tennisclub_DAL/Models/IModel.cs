using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub_DAL.Models
{
    public interface IModel<TIdType> where TIdType : struct
    {
        public TIdType Id { get; set; }
    }
}
