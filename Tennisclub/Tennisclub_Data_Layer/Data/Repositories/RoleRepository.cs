using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(TennisclubContext context) : base(context)
        {

        }
    }
}
