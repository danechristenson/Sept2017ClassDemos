using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.BLL
{
    public class ArtistController
    {
        public List<Artist> Artists_List()
        {
            using (var context = new ChinookContext())
            {
                return context.Artists.ToList();
            }
        }
    }
}
