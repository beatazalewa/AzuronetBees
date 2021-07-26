using AzuronetBees.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using AzuronetBees.Web.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AzuronetBees.Web.Controllers
{
    public class BeeController : Controller
    {
        private readonly ILogger<BeeController> _logger;
        private IBeeRepository _repository;
        private IWebHostEnvironment _environment;


        public BeeController(ILogger<BeeController> logger, IBeeRepository repository, IWebHostEnvironment environment)
        {
            _logger = logger;
            _repository = repository;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_repository.GetBees());
        }

        public IActionResult Details(int id)
        {
            var bee = _repository.GetBeeById(id);
            if (bee == null)
            {
                return NotFound();
            }
            return View(bee);
        }

       private void PopulateBeehivesDropDownList(int? selectedBeehive = null)
        {
            var beehives = _repository.PopulateBeehivesDropDownList();
            ViewBag.BeehiveID = new SelectList(beehives.AsNoTracking(), "BeehiveId", "BeehiveName", selectedBeehive);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateBeehivesDropDownList();
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(Bee bee)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateBee(bee);
                return RedirectToAction(nameof(Index));
            }
            PopulateBeehivesDropDownList(bee.BeehiveId);
            return View(bee);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Bee bee = _repository.GetBeeById(id);
            if (bee == null)
            {
                return NotFound();
            }
            PopulateBeehivesDropDownList(bee.BeehiveId);
            return View(bee);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditPost(int id)
        {
            var beeToUpdate = _repository.GetBeeById(id);
            bool isUpdated = await TryUpdateModelAsync<Bee>(
                                     beeToUpdate,
                                     "",
                                     b => b.BeehiveId,
                                     b => b.BreedOfBees,
                                     b => b.Description,
                                     b => b.SwarmingBees,
                                     b => b.Active,
                                     b => b.Overall);
            if (isUpdated == true)
            {
                _repository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            PopulateBeehivesDropDownList(beeToUpdate.BeehiveId);
            return View(beeToUpdate);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bee = _repository.GetBeeById(id);
            if (bee == null)
            {
                return NotFound();
            }
            return View(bee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteBee(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult GetImage(int id)
        {
            Bee requestedBee = _repository.GetBeeById(id);
            if (requestedBee != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedBee.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    return File(fileBytes, requestedBee.ImageMimeType);
                }
                else
                {
                    if (requestedBee.PhotoFile.Length > 0)
                    {
                        return File(requestedBee.PhotoFile, requestedBee.ImageMimeType);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
