using Microsoft.AspNetCore.Mvc;
using _2211_Assignment_2_Full_Stack_CRUD.Models;
using CPRO_2211_Assignment_3_Trip_Log.Models;

namespace CPRO_2211_Assignment_3_Trip_Log.Controllers
{
    public class TripController : Controller
    {
        //loading data from db
        private TripContext context { get; set; }

        public TripController(TripContext ctx)
        {
            context = ctx;
        }

        //Default path index action method returning model list
        public IActionResult Index()
        {
            var trips = context.Trips.ToList();
            return View(trips);
        }

        
        [HttpGet]
        public IActionResult Page1()
        {
            return View("Add/Page-1");
        }

        [HttpPost]
        public IActionResult Page1(Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return View("Add/Page-1", trip);
            }
            //Store data from Page 1 in TempData
            TempData["Destination"] = trip.Destination;
            TempData["Accommodation"] = trip.Accommodation;
            TempData["StartDate"] = trip.StartDate;
            TempData["EndDate"] = trip.EndDate;
            return RedirectToAction("Page2");
        }

        [HttpGet]
        public IActionResult Page2()
        {
            //Retrieve data from TempData if available
            var page1Data = TempData["Page1Data"] as Trip;
            return View("Add/Page-2",page1Data);
        }

        [HttpPost]
        public IActionResult Page2(Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return View("Add/Page-2",trip);
            }
            //Store data from Page 2 in TempData
            TempData["AccommodationPhone"] = trip.AccommodationPhone;
            TempData["AccommodationEmail"] = trip.AccommodationEmail;
            return RedirectToAction("Page3");
        }

        [HttpGet]
        public IActionResult Page3()
        {
            //Retrieve data from TempData if available
            var page1Data = TempData["Page1Data"] as Trip;
            var page2Data = TempData["Page2Data"] as Trip;
            return View("Add/Page-3",(page1Data, page2Data));
        }

        [HttpPost]
        public IActionResult Page3(Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return View("Add/Page-3",trip);
            }
            //Store data from Page 3 in TempData
            TempData["Page3Data"] = trip;
            //form submission or final processing
            return RedirectToAction("Confirmation");
        }

        [HttpGet]
        public IActionResult Confirmation()
        {
            //Retrieve data from TempData if needed for confirmation page
            var page1Data = TempData["Page1Data"] as Trip;
            var page2Data = TempData["Page2Data"] as Trip;
            var page3Data = TempData["Page3Data"] as Trip;
            //Display confirmation page with collected data
            return View((page1Data, page2Data, page3Data));
        }
    }
}
