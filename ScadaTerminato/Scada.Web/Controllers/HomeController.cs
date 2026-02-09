using Microsoft.AspNetCore.Mvc;
using Scada.Core;

namespace Scada.Controllers
{
	public class HomeController : Controller
	{
		private static PlcScada? plcScada = null;
		private static string status = "DISCONNESSO";
		private static Dictionary<string, bool> movements = new Dictionary<string, bool>
        {
            {"forward", false },
            {"left", false },
            {"back", false },
            {"right", false },
            {"up", false },
            {"down", false },

        };
        private static string ipAddress = "";

  
        public IActionResult Index()
		{
       
            ViewBag.Movements = movements;
            return View();
		}

        [HttpPost]
        public IActionResult Connect(string? address)
        {
            plcScada = PlcScada.GetInstance(address);
            ViewBag.Movements = movements;
            DisableMovements();
            status = plcScada.ConnectPlc();



            if (status == "OK")
            {
                status = "CONNESSO";
                ViewBag.Status = status;
            }
            else
            {
                plcScada = null;
                ViewBag.Status = status;
                ViewBag.ShowErrorModal = true;
                ViewBag.ErrorMessage = status;
            }

            ipAddress = address;
            ViewBag.Address = ipAddress;
            return View("Index");
        }

        public IActionResult Disconnect()
		{
            if (plcScada != null)
            {
                status = plcScada.DisconnectPlc();

                if (status == "OK")
                {
                    status = "DISCONNESSO";
                    ViewBag.Status = status;
                    plcScada = null;
                }
                else
                    ViewBag.Status = status;
            }
            ViewBag.Movements = movements;

            return View("Index");
        }

		public IActionResult Manual()
		{
            if (plcScada != null)
            {
                DisableMovements();
                plcScada.Manual();
            }

            ViewBag.Movements = movements;
            ViewBag.Status = status;
            ViewBag.Address = ipAddress;
            return View("Index");
		}

		public IActionResult Automatic()
		{
            if (plcScada != null)
            {
                DisableMovements();
                plcScada.Automatic();
            }

            ViewBag.Movements = movements;
            ViewBag.Status = status;
            ViewBag.Address = ipAddress;
            return View("Index");
		}

		public IActionResult Reset()
		{
            if (plcScada != null)
            {
                DisableMovements();
                plcScada.Reset();
            }

            ViewBag.Movements = movements;
            ViewBag.Status = status;
            ViewBag.Address = ipAddress;
            return View("Index");
        }

		public IActionResult Emergency()
		{
            if (plcScada != null)
            {
                DisableMovements();
                plcScada.Emergency();
            }

            ViewBag.Movements = movements;
            ViewBag.Status = status;
            ViewBag.Address = ipAddress;
            return View("Index");
        }

		public IActionResult Stop()
		{
            if (plcScada != null)
            {
                DisableMovements();
                plcScada.Stop();
            }

            ViewBag.Movements = movements;
            ViewBag.Status = status;
            ViewBag.Address = ipAddress;
            return View("Index");
        }

		public IActionResult Left()
		{
            if (plcScada != null)
            {
                movements["right"] = false; 
                movements["left"] = !movements["left"];
			    plcScada.GoLeft(movements["left"]);
            }

            ViewBag.Movements = movements;
            ViewBag.Status = status;
            ViewBag.Address = ipAddress;
            return View("Index");
        }

        public IActionResult Right()
        {
            if (plcScada != null)
            {
                movements["left"] = false;
                movements["right"] = !movements["right"];
                plcScada.GoRight(movements["right"]);
            }

            ViewBag.Movements = movements;
            ViewBag.Status = status;
            ViewBag.Address = ipAddress;
            return View("Index");
        }

        public IActionResult Forward()
        {
            if (plcScada != null)
            {
                movements["back"] = false;
                movements["forward"] = !movements["forward"];
			    plcScada.GoForward(movements["forward"]);
            }

            ViewBag.Movements = movements;
            ViewBag.Status = status;
            ViewBag.Address = ipAddress;
            return View("Index");
        }

		public IActionResult Back()
		{
            if (plcScada != null)
            {
                movements["forward"] = false;
                movements["back"] = !movements["back"];
			    plcScada.GoBack(movements["back"]);
            }

            ViewBag.Movements = movements;
            ViewBag.Status = status;
            ViewBag.Address = ipAddress;
            return View("Index");
		}

        public IActionResult Up()
        {
            if (plcScada != null)
            {
                movements["down"] = false;
                movements["up"] = !movements["up"];
			    plcScada.GoUp(movements["up"]);
            }

            ViewBag.Movements = movements;
            ViewBag.Status = status;
            ViewBag.Address = ipAddress;
            return View("Index");
        }

        public IActionResult Down()
        {
            if (plcScada != null)
            {
                movements["up"] = false;
                movements["down"] = !movements["down"];
			    plcScada.GoDown(movements["down"]);
            }

            ViewBag.Movements = movements;
            ViewBag.Status = status;
            ViewBag.Address = ipAddress;
            return View("Index");
        }

		private static void DisableMovements()
		{
			movements["forward"] = false;
            movements["left"] = false;
            movements["back"] = false;
            movements["right"] = false;
            movements["up"] = false;
            movements["down"] = false;
        }
    }
}


