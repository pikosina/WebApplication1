using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment _appEnvironment;
        IHashService _hashService;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ApplicationDbContext context, IWebHostEnvironment appEnvironment, ILogger<HomeController> logger, IHashService hashService)
        {
            _context = context;
            _appEnvironment = appEnvironment;
            _logger = logger;
            _hashService = hashService;
        }
        [HttpGet]
        public ActionResult addHash()
        {

            List<string> NameOfPictures = new List<string>();
            List<Picture> pictures = _context.Picture.ToList();
            foreach (Picture n in pictures)
            {
                NameOfPictures.Add(n.Name);
            }
            ViewBag.data = pictures;
            return View();
        }
        [HttpPost]
        public ActionResult addHash(Hash hash)
        {
            var result = _hashService.AddHash(hash);
            return RedirectToAction("Index");
        }
        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Index()
            {
            List<Picture> pictures = _context.Picture.ToList();

            List<Picture> picturesResult = new List<Picture>();
            var result = _hashService.GetHash();
            foreach (Picture p in pictures)
            {
                try
                {
                    List<Hash> hash = _hashService.SelectHashById(p.Id);
                    if (hash != null) 
                    {
                        p.hash = hash;
                        picturesResult.Add(p);
                    }
                } catch (Exception ex) { continue; }
            }


            return View(picturesResult);
            }
        
        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                Picture file = new Picture { Name = uploadedFile.FileName, Path = path };
                _context.Picture.Add(file);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult FindByHash(string findByHash)
        {
            List<Picture> pictures = _context.Picture.ToList();

            List<Picture> picturesResult = new List<Picture>();
            var result = _hashService.GetHash();
            foreach (Picture p in pictures)
            {
                try
                {
                    List<Hash> hash = _hashService.SelectHashById(p.Id);
                    if (hash != null)
                    {

                        foreach (Hash hh in hash)
                        {
                            if (hh.Name.Contains(findByHash))
                            {
                                p.hash = hash;
                                picturesResult.Add(p);
                            }
                        }
                    }
                }
                catch (Exception ex) { continue; }
            }


            return View(picturesResult);
           
        }


    }
}
