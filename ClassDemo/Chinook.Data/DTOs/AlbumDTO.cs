﻿using Chinook.Data.POCOs;
using System.Collections.Generic;



namespace Chinook.Data.DTOs
{
    public class AlbumDTO
    {
        public string title { get; set; }
        public int releaseYear { get; set; }
        public int numberOfTracks { get; set; }
        public IEnumerable<TrackPOCO> tracks { get; set; }
    }
}
