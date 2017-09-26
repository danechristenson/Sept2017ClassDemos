<<<<<<< HEAD
﻿using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel; // expose methods for ODS wizard
=======
﻿
>>>>>>> refs/remotes/dwelchnait/master
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
=======
#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;  //expose methods for ODS wizard
#endregion
>>>>>>> refs/remotes/dwelchnait/master

namespace ChinookSystem.BLL
{
    [DataObject]
    public class ArtistController
    {
<<<<<<< HEAD
        [DataObjectMethod(DataObjectMethodType.Select, false)]
=======
        [DataObjectMethod(DataObjectMethodType.Select,false)]
>>>>>>> refs/remotes/dwelchnait/master
        public List<Artist> Artists_List()
        {
            using (var context = new ChinookContext())
            {
                return context.Artists.ToList();
            }
        }
    }
}
