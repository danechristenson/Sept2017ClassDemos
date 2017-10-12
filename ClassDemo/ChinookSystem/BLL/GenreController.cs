using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
using ChinookSystem.DAL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace ChinookSystem.BLL
{
    [DataObject]
    public class GenreController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<GenreDTO> Genre_GenreAlbumTracks()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Genres //this is the DbSet in context
                              select new GenreDTO
                              {
                                  genre = x.Name,
                                  albums = from y in x.Tracks
                                           group y by y.Album into gresults //.Album is the key data attribute group
                                           select new AlbumDTO
                                           {
                                               title = gresults.Key.Title,
                                               releaseYear = gresults.Key.ReleaseYear,
                                               numberOfTracks = gresults.Count(),
                                               tracks = from z in gresults
                                                        select new TrackPOCO
                                                        {
                                                            song = z.Name,
                                                            milliseconds = z.Milliseconds
                                                        }
                                           }
                              };
                return results.ToList();
            }
        }

    }
}
