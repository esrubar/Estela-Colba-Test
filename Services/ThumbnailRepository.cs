using Estela_Colba_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estela_Colba_Test.Services
{
    public class ThumbnailRepository
    {
        public List<Thumbnail> GetAll()
        {
            using (var db = new ThumbnailContext())
            {
                return db.Thumbnails.ToList();
            }
        }

        internal void CreateThumbnail(Thumbnail thumbnail)
        {
            using (var db = new ThumbnailContext())
            {
                Guid newId = Guid.NewGuid();
                thumbnail.Id = newId;
                thumbnail.visits = 0;

                db.Thumbnails.Add(thumbnail);
                db.SaveChanges();
            }
        }

        internal Thumbnail GetById(Guid id)
        {
            using (var db = new ThumbnailContext())
            {
                var thumbnail = db.Thumbnails.FirstOrDefault(t => t.Id == id);
                return thumbnail;
            }
        }

        internal void UpdateThumbnail(Thumbnail thumbnail)
        {
            using (var db = new ThumbnailContext())
            {
                //var thumbnail = GetById(thumbnail);
                db.Entry(thumbnail).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

        }

        internal void newVisit(Thumbnail thumbnail)
        {
            using (var db = new ThumbnailContext())
            {
                var visits = thumbnail.visits;
                visits += 1;
                thumbnail.visits = visits;
                db.Entry(thumbnail).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
                

        }

        internal void DeleteThumbnail(Guid id)
        {
            using (var db = new ThumbnailContext())
            {
                Thumbnail thumbnail = GetById(id);
                db.Entry(thumbnail).State = System.Data.Entity.EntityState.Deleted;                
                db.SaveChanges();
            }
               
        }

        internal object getMostViewed()
        {
            using (var db = new ThumbnailContext())
            
            {
                var thumbnail = db.Thumbnails.OrderByDescending(t => t.visits).FirstOrDefault();
                return thumbnail;
            }
        }

        /*internal List<Thumbnail> GetByName(Guid id)
        {
            using (var db = new ThumbnailContext())
            {
                //var thumbnails = db.Thumbnails.Where(t => t.Name.ToLower().Contains(name.ToLower())).ToList();
                //var thumbnail
                //return thumbnails;
            }
                
        }*/
    }
}