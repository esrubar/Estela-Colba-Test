using Estela_Colba_Test.Models;
using Estela_Colba_Test.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estela_Colba_Test.Controllers
{
    [ApiController]
    [System.Web.Mvc.Route("[controller]")]
    public class MemesController: Controller 
    {
        
        private ThumbnailRepository _memeRepo;
        public MemesController()
        {
            _memeRepo = new ThumbnailRepository();
        }

        //GET: Meme
        public ViewResult Details(Guid id)
        {
            var thumbnail = _memeRepo.GetById(id);
            return View(thumbnail);
        }

    }
}