using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using saborna_crkva_API.Dtos;
using saborna_crkva_API.EF;
using saborna_crkva_API.Models;
using Stripe;

namespace saborna_crkva_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UplataController : ControllerBase
    {
        private readonly MyContext _context;

        public UplataController(MyContext context)
        {
            _context = context;
        }

        [HttpPost("pay")]
        public ActionResult Pay(PaymentCardAdd cardInfo)
        {
            try
            {
                var token = GetToken(cardInfo);
                StripeConfiguration.ApiKey = "sk_test_ZYySFlXrQCDciqzHKybrdcWU";

                // `source` is obtained with Stripe.js; see https://stripe.com/docs/payments/accept-a-payment-charges#web-create-token
                var options = new ChargeCreateOptions
                {
                    Amount = cardInfo.Amount * 100,
                    Currency = "bam",
                    Source = token,
                    Description = cardInfo.Desc,
                };

                var service = new ChargeService();
                Charge charge = service.Create(options);
                //service.Create(options);
                Uplata uplata = new Uplata
                {
                    ChargeId = charge.Id,
                    Description = charge.Description,
                    UplacenoUkupno = charge.Amount,
                    Status = charge.Status
                };

                Donacije donacija = new Donacije
                {
                    Datum = DateTime.Now,
                    Iznos = cardInfo.Amount,
                    Poruka = cardInfo.Desc,
                    UserId = cardInfo.UserId
                };
                _context.Donacije.Add(donacija);
                _context.SaveChanges();

                return Ok(uplata);
            }
            catch(StripeException e)
            {
                return BadRequest(e.Message);
            }
        }

        private string GetToken(PaymentCardAdd cardInfo)
        {
            StripeConfiguration.ApiKey = "sk_test_ZYySFlXrQCDciqzHKybrdcWU";

            var options = new TokenCreateOptions
            {
                Card = new CreditCardOptions
                {
                    Number = cardInfo.BrojKartice,
                    ExpYear = int.Parse(20 + cardInfo.Godina.ToString()),
                    ExpMonth = cardInfo.Mjesec,
                    Cvc = cardInfo.CVV.ToString()
                }
            };

            var service = new TokenService();
            Token stripeToken = service.Create(options);
            return stripeToken.Id;
        }
    
        [HttpGet("getdonations")]
        public ActionResult GetDonacije([FromQuery] int? userid)
        {
            var query = _context.Donacije.Include(x => x.User)
                .Select(x=> new PrikazDonacija
                {
                    Datum = x.Datum,
                    Iznos = x.Iznos,
                    Poruka = x.Poruka,
                    ImePrezime = x.User.Ime + " "+ x.User.Prezime,
                    UserId = x.UserId,
                    Id = x.Id
                }).OrderByDescending(x=>x.Id)
                .AsQueryable();

            if(userid != null)
            {
                query = query.Where(x => x.UserId == userid);
            }

            var result = query.ToList();

            return Ok(result);  
        }
    
    }
}