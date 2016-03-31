using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using FragSwapperV2.Models;
using FragSwapperV2.Models.Db;
using Microsoft.AspNet.Http;
using Newtonsoft.Json;
using Microsoft.AspNet.Hosting;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNet.Authorization;
using System;
using FragSwapperV2.ViewModels.Hosts;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace FragSwapperV2.Controllers
{
    [Authorize]
    public class HostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public HostsController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        // GET: /Hosts
        public IActionResult Index()
        {
            return View(_context.Hosts.Where(x => x.AccountType > HostAccountType.Inactive).ToList());
        }

        // GET: Hosts/Create
        public IActionResult Create()
        {
            ViewData["ImageGuid"] = Guid.NewGuid().ToString();
            return View();
        }

        // POST: /Hosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateHostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var host = new Host { Name = model.Name, ShortName = model.ShortName, Abbreviation = model.Abbreviation, AccountType = HostAccountType.New };
                _context.Hosts.Add(host);
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var hostAdministrator = new HostAdministrator { ApplicationUser = user, Host = host };
                _context.HostAdministrators.Add(hostAdministrator);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /// <summary>
        /// Validates part of the create host form. Only ONE of the parameters will ever be something
        /// other than null since each text box on the form calls this process for itself.
        /// </summary>
        /// <param name="name">Validates that the Host Name doesn't already exist.</param>
        /// <param name="shortName">Validates that the Short Name doesn't already exist.</param>
        /// <returns></returns>
        [HttpGet]
        public bool CreateValidation(string name, string shortName)
        {
            if (name != null) return (!_context.Hosts.Any(x => x.Name == name));
            if (shortName != null) return (!_context.Hosts.Any(x => x.ShortName == shortName));
            return false; // This should never happen!!!
        }

        /*
        // GET: Hosts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Host host = _context.Hosts.Single(m => m.ID == id);
            if (host == null)
            {
                return HttpNotFound();
            }

            return View(host);
        }

        // GET: Hosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Host host)
        {
            if (ModelState.IsValid)
            {
                _context.Hosts.Add(host);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(host);
        }

        // GET: Hosts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Host host = _context.Hosts.Single(m => m.ID == id);
            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }

        // POST: Hosts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Host host)
        {
            if (ModelState.IsValid)
            {
                _context.Update(host);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(host);
        }

        // GET: Hosts/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Host host = _context.Hosts.Single(m => m.ID == id);
            if (host == null)
            {
                return HttpNotFound();
            }

            return View(host);
        }

        // POST: Hosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Host host = _context.Hosts.Single(m => m.ID == id);
            _context.Hosts.Remove(host);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    */
    }
}
