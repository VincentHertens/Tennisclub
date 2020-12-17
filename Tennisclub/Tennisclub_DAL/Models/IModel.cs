using System;

namespace Tennisclub_DAL.Models
{
    public interface IModel<TIdType> where TIdType : struct
    {
        public TIdType Id { get; set; }
    }
}
