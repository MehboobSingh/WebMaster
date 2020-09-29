using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gruppeoppgave1.DAL;
using Gruppeoppgave1.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stripe;

namespace Gruppeoppgave1.controllers
{


    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private IBilletRepository _db;

        private ILogger<HomeController> _log;

        private IStrekningRepository _sdb;




        public HomeController(IBilletRepository db, ILogger<HomeController> log, IStrekningRepository sdb)
        {
            _db = db;
            _log = log;
            _sdb = sdb;

        }


        public async Task<ActionResult> lagreStrekning(Strekning lagreStrekning)

        {
            if (ModelState.IsValid)
            {
                bool returnOK = await _sdb.lagreStrekning(lagreStrekning);
                if (!returnOK)
                {
                    _log.LogInformation("Billeten ble ikke lagret");
                    return BadRequest("Billeten ble ikke lagret");

                }
                return Ok("Billeten lagret");
            }

            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }






        public async Task<ActionResult> hentEnStrekning(int SId)
        {
            if (ModelState.IsValid)
            {
                Strekning enstrekning = await _sdb.hentEnStrekning(SId);
                if (enstrekning == null)
                {
                    _log.LogInformation("Strekning ikke finnes");
                    return BadRequest("Billeten ble ikke lagret");
                }

                return Ok();
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }




        public async Task<ActionResult> HentalleStrekninger()

        {
            List<Strekning> alleStrekninger = await _sdb.HentalleStrekning();

            _log.LogInformation("Checking......");
            return Ok(alleStrekninger);
        }

        public async Task<ActionResult> slettStrekning(int SId)
        {

            bool returnOK = await _sdb.slettStrekning(SId);
            if (!returnOK)
            {
                _log.LogInformation("Sletting av Billeten ble ikke utført");
                return NotFound("Sletting av Billeten ble ikke utført");
            }
            return Ok("Billeten Slettet");

        }


        public async Task<ActionResult> endreStrekning(int SId, Strekning endreStrekning)
        {
            if (ModelState.IsValid)
            {

                bool returnOK = await _sdb.endreStrekning(SId, endreStrekning);
                if (!returnOK)
                {
                    _log.LogInformation("Endringen kunne ikke utføres");
                    return NotFound("Endringen kunne ikke utføres");
                }
                return Ok("Billeten Endret");


            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }






















        public async Task<ActionResult> lagreBillet(Billet lagreBillet)

        {
            if (ModelState.IsValid)
            {
                bool returnOK = await _db.lagreBillet(lagreBillet);
                if (!returnOK)
                {
                    _log.LogInformation("Billeten ble ikke lagret");
                    return BadRequest("Billeten ble ikke lagret");
                    
                }
                return Ok("Billeten lagret");
            }

            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }


        public  async Task<ActionResult> HentalleBilleter()

        {
            List<Billet> alleBilleter = await _db.HentalleBilleter();

            _log.LogInformation("Checking......");
            return Ok(alleBilleter);
        }

        public async Task<ActionResult> slettBillet(int BId)
        {

            bool returnOK = await _db.slettBillet(BId);
            if (!returnOK)
            {
                _log.LogInformation("Sletting av Billeten ble ikke utført");
                return NotFound("Sletting av Billeten ble ikke utført");
            }
            return Ok("Billeten Slettet");

        }


        public async Task<ActionResult> hentEnBillet(int BId)
        {
            if (ModelState.IsValid)
            {

                Billet Billeten = await _db.hentEnBillet(BId);
                if (Billeten == null)
                {
                    _log.LogInformation("Fant ikke Billeten");
                    return NotFound("Fant ikke Billeten");
                }
                return Ok(Billeten);

            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");

        }


        public async Task<ActionResult> endreBillet(int BId, Billet endreBillet)
        {
            if (ModelState.IsValid)
            {

                bool returnOK = await _db.endreBillet(BId, endreBillet);
                if (!returnOK)
                {
                    _log.LogInformation("Endringen kunne ikke utføres");
                    return NotFound("Endringen kunne ikke utføres");
                }
                return Ok("Billeten Endret");


            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }


        public bool Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                Customer = customer.Id
            });

            return charge.Paid;
        }

        public IActionResult Index()
        {
            return RedirectToPage("/");
        }

        public IActionResult Error()
        {
            return RedirectToAction("/");
        }

    }

}
