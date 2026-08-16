using CustomerRegistrationPortal.Models;
using CustomerRegistrationPortal.Services;
using System;
using System.Web.Mvc;

namespace CustomerRegistrationPortal.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                DataverseService service = new DataverseService();

                service.CreateRegistrationRecord(
                model.FirstName,
                model.LastName,
                model.Email,
                model.Phone,
                model.Address);

                ViewBag.Message = "Registration Successful";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("same email"))
                {
                    ViewBag.ErrorMessage =
                    "A contact with this email already exists.";
                }
                else
                {
                    ViewBag.ErrorMessage =
                    "Registration failed. Please try again.";
                }
            }

            return View(model);
        }
    }
}
