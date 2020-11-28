using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub_Common
{
    public interface IModelReadDto<TIdType> where TIdType : struct
    {
        public TIdType Id { get; set; }
    }
}
