using System;
using System.Web.Mvc;
using SimpleCQRS;
using SimpleCQRS.Queries;

namespace CQRSGui.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private FakeBus _bus;

        public HomeController()
        {
            _bus = ServiceLocator.Bus;
        }

        public ActionResult Index()
        {
            ViewData.Model = new GetInventoryItemsQueryHandler().Handle();
            return View();
        }

        public ActionResult Details(Guid id)
        {
            ViewData.Model = new GetInventoryDetailsQueryHandler().Handle(id);
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            _bus.Send(new CreateInventoryItemCommand(Guid.NewGuid(), name));

            return RedirectToAction("Index");
        }

        public ActionResult ChangeName(Guid id)
        {
            ViewData.Model = new GetInventoryDetailsQueryHandler().Handle(id);
            return View();
        }

        [HttpPost]
        public ActionResult ChangeName(Guid id, string name, int version)
        {
            var command = new RenameInventoryItemCommand(id, name);
            _bus.Send(command);

            return RedirectToAction("Index");
        }

        public ActionResult Deactivate(Guid id)
        {
            ViewData.Model = new GetInventoryDetailsQueryHandler().Handle(id);
            return View();
        }

        [HttpPost]
        public ActionResult Deactivate(Guid id, int version)
        {
            _bus.Send(new DeactivateInventoryItemCommand(id));
            return RedirectToAction("Index");
        }

        public ActionResult CheckIn(Guid id)
        {
            ViewData.Model = new GetInventoryDetailsQueryHandler().Handle(id);
            return View();
        }

        [HttpPost]
        public ActionResult CheckIn(Guid id, int number, int version)
        {
            _bus.Send(new CheckInItemsToInventoryCommand(id, number));
            return RedirectToAction("Index");
        }

        public ActionResult Remove(Guid id)
        {
            ViewData.Model = new GetInventoryDetailsQueryHandler().Handle(id);
            return View();
        }

        [HttpPost]
        public ActionResult Remove(Guid id, int number, int version)
        {
            _bus.Send(new RemoveItemsFromInventoryCommand(id, number));
            return RedirectToAction("Index");
        }
    }
}
