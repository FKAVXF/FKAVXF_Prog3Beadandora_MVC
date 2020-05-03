using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LogiData.Web.Models;
using MyLogiscool.Logic;
using MyLogiscool.Data;
using MyLogiscool.Repository;

namespace LogiData.Web.Controllers
{
    public class OwnersController : Controller
    {
        ILogic logic;
        IMapper mapper;
        OwnerViewModel vm;

        public OwnersController()
        {
            logic = new MainLogic();
            mapper = MapperFactory.CreateMapper();
            vm = new OwnerViewModel();
            vm.EditedOwner = new Owner();
            var owners = logic.ReadAllOwners();
            vm.OwnersList = mapper.Map<IEnumerable<MyLogiscool.Data.Owners>, List<Models.Owner>>(owners);
        }

        private Owner GetOneOwner(int id)
        {
            Owners oneOwner = logic.ReadOwners(id);
            return mapper.Map<MyLogiscool.Data.Owners, Models.Owner>(oneOwner);
        }

        // GET: Owner
        public ActionResult Index()
        {
            ViewData["editAction"] = "AddNew";
            return View("OwnerIndex", vm);
        }

        // GET: Owner/Details/5
        public ActionResult Details(int id)
        {
            return View("OwnerDetails", GetOneOwner(id));
        }

        //GET: /Owner/Remove/5
        public ActionResult Remove(int id)
        {
            //TempData["editResult"] = "Delete FAIL";
            logic.DeleteOwners(id);
            TempData["editResult"] = "Delete OK";
            return RedirectToAction("Index");
        }

        // GET: /Owner/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["editAction"] = "Edit";
            vm.EditedOwner = GetOneOwner(id);
            return View("OwnerIndex", vm);
        }

        // POST: /Owner/Edit
        [HttpPost]
        public ActionResult Edit(Owner owner, string editAction)
        {
            if (ModelState.IsValid && owner != null)
            {
                TempData["editResult"] = "Edit Ok";
                if (editAction == "AddNew")
                {
                    logic.CreateOwners(mapper.Map<Models.Owner,MyLogiscool.Data.Owners>(owner));
                }
                else
                {
                    logic.UpdateOwners(mapper.Map<Models.Owner, MyLogiscool.Data.Owners>(owner));
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["editAction"] = "Edit";
                vm.EditedOwner = owner;
                return View("OwnerIndex", vm);
            }
        }
    }
}
