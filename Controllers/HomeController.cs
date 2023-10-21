using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, DatabaseContext context) {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Cinema() {
            return View();
        }
        public IActionResult Theatre() {
            return View();
        }

        public IActionResult ContactUs() {
            return View();
        }

       


        public IActionResult booking(int id, string MovieName, int price) {

            var model = new MovieModel { id = id, MovieName=MovieName, price=price };



            return View(model);
        }
       





        public IActionResult AddBookingToDatabase(PaymentModel payment) {
            if(ModelState.IsValid) {
                var newpayment = new PaymentModel {
                    NameSurname = payment.NameSurname,
                    CardNumber = payment.CardNumber,
                    Expiry = payment.Expiry,
                    CVV = payment.CVV,
                    MovieName = payment.MovieName,
                    TotalPrice = payment.TotalPrice
                };

                _context.Payments.Add(newpayment);
                _context.SaveChanges();

                return Json(new { success = true, message = "Payment succesfull." });
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, errors = errors });
        }

        public IActionResult AddContactToDatabase(ContactModel contact) {
            if(ModelState.IsValid) {
                var newcontact = new ContactModel {
                    NameSurname = contact.NameSurname,
                    Email = contact.Email,
                    PhoneNumber = contact.PhoneNumber,
                    Message = contact.Message
                };

                _context.Contacts.Add(newcontact);
                _context.SaveChanges();

                return Json(new { success = true, message = "Your message sent." });
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, errors = errors });
        }
    }
}