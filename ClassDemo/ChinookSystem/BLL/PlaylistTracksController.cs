using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
using ChinookSystem.DAL;
using System.ComponentModel;
#endregion

namespace ChinookSystem.BLL
{
    public class PlaylistTracksController
    {
        public List<UserPlaylistTrack> List_TracksForPlaylist(
            string playlistname, string username)
        {
            using (var context = new ChinookContext())
            {

                // what would happen if there is no match for the 
                // incoming parameter value
                // we need to ensure that the results have a valid value
                // this value will the resolve of the query either a null ( not found_
                // or an IEnumberable<T> collection
                // to achieve a valid value encapsulate the query in a 
                // .FirstOrDefault

                var results = (from x in context.Playlists
                               where x.UserName.Equals(username)
                               && x.Name.Equals(playlistname)
                               select x).FirstOrDefault();
                if (results == null)
                {
                    return null;
                }
                else
                {

                    // now get the tracks
                    var theTracks = from x in context.PlaylistTracks
                                    where x.PlaylistId.Equals(results.PlaylistId)
                                    orderby x.TrackNumber
                                    select new UserPlaylistTrack
                                    {
                                        TrackID = x.TrackId,
                                        TrackNumber = x.TrackNumber,
                                        TrackName = x.Track.Name,
                                        Milliseconds = x.Track.Milliseconds,
                                        UnitPrice = x.Track.UnitPrice
                                    };
                    return theTracks.ToList();
                }

            }
        }//eom
        public List<UserPlaylistTrack> Add_TrackToPLaylist(string playlistname, string username, int trackid)
        {
            using (var context = new ChinookContext())
            {
                //code to go here
                //Part One:
                //
                var exists =  (from x in context.Playlists
                               where x.UserName.Equals(username)
                               && x.Name.Equals(playlistname)
                               select x).FirstOrDefault();

                // initialize the tracknumber
                int tracknumber = 0;
                // I will need to create an instance of PlayListTrack
                PlaylistTrack newtrack = null;

                // determine if a PlayList "Parent" instances need to be created
                if (exists == null)
                {
                    // this is a new playlist
                    // create an instance of playlist to add to Playlist table
                    exists = new Playlist();
                    exists.Name = playlistname;
                    exists.UserName = username;
                    exists = context.Playlists.Add(exists);
                    // at this time there is  no physical PKey
                    // the psuedo pkey is handled by the HashSet
                    tracknumber = 1;
                }
                else
                {
                    // playlist exists
                    // I need ot generate the next track number
                    tracknumber = exists.PlaylistTracks.Count() + 1;

                    // validation: in our example a track can only exist once
                    // on a particular playlist
                    newtrack = exists.PlaylistTracks.SingleOrDefault(x => x.TrackId == trackid);
                    if (newtrack != null)
                    {
                        throw new Exception("Playlist already contains track");
                    }
                }

                // Part Two: Add the PlaylistTrack instance
                // use navigation to .Add the new track to PlaylistTrack
                newtrack = new PlaylistTrack();
                newtrack.TrackId = trackid;
                newtrack.TrackNumber = tracknumber;

                // NOTE: the pkey for PlaylistId may not yet exist
                // using navigation one can let HashSet handle the PlaylistId pkey value
                exists.PlaylistTracks.Add(newtrack);

                // physically add all data to the database
                // commit
                context.SaveChanges();
                return List_TracksForPlaylist(playlistname, username);
             
            }
        }//eom
        public void MoveTrack(string username, string playlistname, int trackid, int tracknumber, string direction)
        {
            using (var context = new ChinookContext())
            {
                //code to go here 
                var exists = (from x in context.Playlists
                              where x.UserName.Equals(username)
                              && x.Name.Equals(playlistname)
                              select x).FirstOrDefault();
                if (exists == null)
                {
                    throw new Exception("Playlist has been removed from the file.");
                }
                else
                {
                    PlaylistTrack moveTrack = (from x in exists.PlaylistTracks
                                               where x.TrackId == trackid
                                               select x).FirstOrDefault();

                    if(moveTrack == null)
                    {
                        throw new Exception("Playlist track has been removed from file.");
                    }
                    else
                    {
                        PlaylistTrack otherTrack = null;
                        if (direction.Equals("up"))
                        {
                            if(moveTrack.TrackNumber == 1)
                            {
                                throw new Exception("Playlist track is already at the top of the playlist.");
                            }
                            else
                            {
                                otherTrack = (from x in exists.PlaylistTracks
                                                           where x.TrackNumber == moveTrack.TrackNumber - 1
                                                           select x).FirstOrDefault();
                                if(otherTrack == null)
                                {
                                    throw new Exception("Playlist track has been removed from file.");
                                }
                                else
                                {
                                    moveTrack.TrackNumber--;
                                    otherTrack.TrackNumber++;
                                }
                            }
                        } 
                        else
                        {
                            if (moveTrack.TrackNumber == exists.PlaylistTracks.Count())
                            {
                                throw new Exception("Playlist track is already at the bottom of the playlist.");
                            }
                            else
                            {
                                otherTrack = (from x in exists.PlaylistTracks
                                              where x.TrackNumber == moveTrack.TrackNumber + 1
                                              select x).FirstOrDefault();
                                if (otherTrack == null)
                                {
                                    throw new Exception("Playlist track has been removed from file.");
                                }
                                else
                                {
                                    moveTrack.TrackNumber++;
                                    otherTrack.TrackNumber--;
                                }
                            }
                        }
                        //staging
                        context.Entry(moveTrack).Property(y => y.TrackNumber).IsModified = true; // changes only one thing
                        context.Entry(otherTrack).Property(y => y.TrackNumber).IsModified = true;
                        // saving
                        context.SaveChanges();
                    }
                }
            }
        }//eom


        public void DeleteTracks(string username, string playlistname, List<int> trackstodelete)
        {
            using (var context = new ChinookContext())
            {
               //code to go here


            }
        }//eom
    }
}
