using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Repositories
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(TennisclubContext context) : base(context)
        {

        }
       
        // Toekomstige methoden
    }
}
