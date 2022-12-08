using Estela_Colba_Test.Models;
using Estela_Colba_Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estela_Colba_Test.Controllers
{
    public class ThumbnailsController : Controller
    {
        private ThumbnailRepository _thumbnailRepo;
        public ThumbnailsController()
        {
            _thumbnailRepo = new ThumbnailRepository();
        }
        // GET: Thumbnails
        public ActionResult Index(string search)
        {            
            IEnumerable<Thumbnail> thumbnails = _thumbnailRepo.GetAll();

            if (!String.IsNullOrWhiteSpace(search))
            {
                using (var db = new ThumbnailContext())
                {
                    thumbnails = thumbnails.Where(t => t.Name.ToLower().Contains(search.ToLower()));
                }
            }

            return View(thumbnails.ToList());
        }

        // GET: Thumbnails/Details/5
        public ActionResult Details(Guid id)
        {
            var thumbnail = _thumbnailRepo.GetById(id);
            _thumbnailRepo.newVisit(thumbnail);
            if(thumbnail is null)
            {
                return HttpNotFound();
            }
            return View(thumbnail);
        }

        // GET: Thumbnails/Create
        public ActionResult Create(FormCollection collection)
        {
            
            return View();

        }

        // POST: Thumbnails/Create
        [HttpPost]
        public ActionResult Create(Thumbnail thumbnail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _thumbnailRepo.CreateThumbnail(thumbnail);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // log
            }
            return View();
        }

        // GET: Thumbnails/Edit/5
        public ActionResult Edit(Guid id)
        {
            var thumbnail = _thumbnailRepo.GetById(id);
            if(thumbnail is null)
            {
                return HttpNotFound();
            }
            return View(thumbnail);
        }

        // POST: Thumbnails/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Width,Height,OriginalRoute,ThumbnailRoute") ]Thumbnail thumbnail)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _thumbnailRepo.UpdateThumbnail(thumbnail);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
               
            }
            return View();
        }

        // GET: Thumbnails/Delete/5
        public ActionResult Delete(Guid id)
        {
            var thumbnail = _thumbnailRepo.GetById(id);
            if (thumbnail is null)
            {
                return HttpNotFound();
            }
            return View(thumbnail);
        }

        // POST: Thumbnails/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id,Name,Description,Width,Height,OriginalRoute,ThumbnailRoute")] Thumbnail thumbnail)
        {
            try
            {
                _thumbnailRepo.DeleteThumbnail(thumbnail.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search (Thumbnail thumbnail)
        {
            /*var id = _thumbnailRepo.GetById(id)
             var thumbnail = _thumbnailRepo.GetByName();
             if (thumbnail is null)
             {
                 return HttpNotFound();
             }
            var model = _thumbnailRepo.GetAll();*/
            return View();
        }
        public ActionResult SearchByName([Bind(Include = "Name")] string Name)
        {
            /*var thumbnail = _thumbnailRepo.GetByName(Name);
            if (thumbnail is null)
            {
                return HttpNotFound();
            }*/
            return View();
        }

        // GET: Thumbnails/MostViewed
        public ActionResult MostViewed()
        {
            var thumbnail = _thumbnailRepo.getMostViewed();
            return View(thumbnail);

        }

    }
}
