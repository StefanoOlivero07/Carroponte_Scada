using Microsoft.AspNetCore.Mvc;
using Scada.Core;

namespace Scada.Tests.Controllers
{
    public class HomeController : Controller
    {
        private readonly PlcScada plcScada;

        public HomeController()
        {
            plcScada = new PlcScada("192.168.2.111");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Connect()
        {
            string status = plcScada.ConnectPlc();

            if (status == "true")
                ViewBag.Status = "CONNECTED";
            else
                ViewBag.Status = status;

            return View("Index");
        }

        public IActionResult Disconnect()
        {
            string status = plcScada.DisconnectPlc();

            if (status == "OK")
                ViewBag.Status = "DISCONNECTED";
            else
                ViewBag.Status = status;

            return View("Index");
        }

        public IActionResult Manual()
        {
            plcScada.Manual();

            return View("Index");
        }

        public IActionResult Left()
        {
            plcScada.GoLeft(true);

            return View("Index");
        }

        public IActionResult Right()
        {
            plcScada.GoRight(true);

            return View("Index");
        }

        public IActionResult Forward()
        {
            plcScada.GoForward(true);

            return View("Index");
        }

        public IActionResult Back()
        {
            plcScada.GoBack(true);

            return View("Index");
        }

        public IActionResult Up()
        {
            plcScada.GoUp(true);

            return View("Index");
        }

        public IActionResult Down()
        {
            plcScada.GoDown(true);

            return View("Index");
        }

        public IActionResult Stop()
        {
            plcScada.Stop();

            return View("Index");
        }

        public IActionResult Automatic()
        {
            plcScada.Automatic();

            return View("Index");
        }

        public IActionResult Emergency()
        {
            plcScada.Emergency();

            return View("Index");
        }

        public IActionResult Reset()
        {
            plcScada.Reset();

            return View("Index");
        }
    }
}
