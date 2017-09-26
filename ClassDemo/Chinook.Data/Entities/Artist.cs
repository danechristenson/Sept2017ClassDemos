using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinook.Data.Entities
{
    [Table("Artists")]
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [StringLength(120, ErrorMessage ="Name is limited to 120 characters")]
        public string Name { get; set; }

<<<<<<< HEAD
        // Navigation properties
        // artist (parent) points to many albums (children)
        // collection of records
=======
        //Navigation properties
        //Artist (parent) points to many albums (chlidren)
        //collection of records
>>>>>>> refs/remotes/dwelchnait/master
        public virtual ICollection<Album> Albums { get; set; }
    }
}
