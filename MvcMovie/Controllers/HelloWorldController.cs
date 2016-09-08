using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/ 

        public ActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public ActionResult Welcome(string name, int numTimes = 1)  // Data is taken from the URL and passed to the Controller using the model binder
        {
            ViewBag.Message = "Hello " + name; // Viewbag is a dynamic object, which means you can put whatever you want in it
            ViewBag.NumTimes = numTimes;  // Viewbag object has no defined properties until you put something inside of it

            return View();
        }
    }
}

// Here we used a Viewbag object to pass data from Controller to View.  The view model approach to passing data is generally much preferred