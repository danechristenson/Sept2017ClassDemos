<<<<<<< HEAD
﻿using Chinook.Data.POCOs;
using ChinookSystem.DAL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;  //expose methods for ODS wizard
using Chinook.Data.POCOs;
#endregion
>>>>>>> refs/remotes/dwelchnait/master

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
<<<<<<< HEAD
        public List<ArtistAlbumByReleaseYear> Albums_ListForArtist(int artistId)
=======
        public List<ArtistAlbumByReleaseYear> Albums_ListforArtist(int artistid)
>>>>>>> refs/remotes/dwelchnait/master
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
<<<<<<< HEAD
                              where x.ArtistId.Equals(artistId)
=======
                              where x.ArtistId.Equals(artistid)
>>>>>>> refs/remotes/dwelchnait/master
                              select new ArtistAlbumByReleaseYear
                              {
                                  Title = x.Title,
                                  Released = x.ReleaseYear
                              };
                return results.ToList();
            }
<<<<<<< HEAD
        }

=======
        }//eom

      
>>>>>>> refs/remotes/dwelchnait/master
    }
}
