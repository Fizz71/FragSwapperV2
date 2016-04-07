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
using FragSwapperV2.Libraries;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.OptionsModel;

namespace FragSwapperV2.Controllers
{
    [Authorize]
    public class HostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppSettings _appSettings;

        public HostsController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            IHostingEnvironment hostingEnvironment,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
            _appSettings = appSettings.Value;
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
                foreach (string state in model.States)
                {
                    var hostState = new HostStates { Host = host, State = _context.States.Single(x => x.ID == int.Parse(state.Split(':')[1])) };
                    _context.HostStates.Add(hostState);

                }
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

        // GET: Hosts/Details/5
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
          
            if (id == null)
            {
                return HttpNotFound();
            }

            HostDetail hostDetail = new HostDetail();
            hostDetail.Host = _context.Hosts.Single(m => m.ID == id);

            if (hostDetail.Host == null) return HttpNotFound();

            hostDetail.Events = _context.Events.Where(x => x.Host.ID == id).OrderByDescending(x => x.EventDate).ToList();

            // We only care about completed events for averages.
            var completedEvents = hostDetail.Events.Where(x => x.Status > EventStatus.Open);
            hostDetail.CompletedEventsCount = completedEvents.Count();
            if (hostDetail.CompletedEventsCount > 0)
            {
                hostDetail.EventRegistrationAverage = completedEvents.Sum(x => x.Registered) / hostDetail.CompletedEventsCount;
                hostDetail.EventAttendeeAverage = completedEvents.Sum(x => x.Attendees) / hostDetail.CompletedEventsCount;
                hostDetail.EventListingsAverage = completedEvents.Sum(x => x.Listings) / hostDetail.CompletedEventsCount;
                hostDetail.EventTradesAverage = completedEvents.Sum(x => x.Trades) / hostDetail.CompletedEventsCount;
            }
            else
            {
                hostDetail.EventRegistrationAverage = 0;
                hostDetail.EventAttendeeAverage = 0;
                hostDetail.EventListingsAverage = 0;
                hostDetail.EventTradesAverage = 0;
            }

            hostDetail.HostLogoFileName = Common.HostImageLogo((int)id, _context);

            if (hostDetail.IsPremium)
                hostDetail.RandomEventImages = Common.RandomHostImages((int)id, 10, _context);

            return View(hostDetail);
        }

        #region "Crap to go through"

        /*

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
        #endregion
    }
}
