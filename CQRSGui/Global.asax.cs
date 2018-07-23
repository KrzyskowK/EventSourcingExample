using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SimpleCQRS;

namespace CQRSGui
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            var bus = new FakeBus();

            var storage = new EventStore(bus);

            bus.RegisterHandler<CheckInItemsToInventoryCommand>(new CheckInItemsToInventoryCommandHandler(storage).Handle);
            bus.RegisterHandler<CreateInventoryCommand>(new CreateInventoryCommandHandler(storage).Handle);
            bus.RegisterHandler<DeactivateInventoryCommand>(new DeactivateInventoryCommandHandler(storage).Handle);
            bus.RegisterHandler<RemoveItemsFromInventoryCommand>(new RemoveItemsFromInventoryCommandHandler(storage).Handle);
            bus.RegisterHandler<RenameInventoryCommand>(new RenameInventoryCommandHandler(storage).Handle);

            var detailsView = new InventoryDetailsView();
            bus.RegisterHandler<Inventory.Events.Created>(detailsView.Handle);
            bus.RegisterHandler<Inventory.Events.Deactivated>(detailsView.Handle);
            bus.RegisterHandler<Inventory.Events.Renamed>(detailsView.Handle);
            bus.RegisterHandler<Inventory.Events.CheckedInToInventory>(detailsView.Handle);
            bus.RegisterHandler<Inventory.Events.RemovedFromInventory>(detailsView.Handle);

            var listView = new InventoriesView();
            bus.RegisterHandler<Inventory.Events.Created>(listView.Handle);
            bus.RegisterHandler<Inventory.Events.Renamed>(listView.Handle);
            bus.RegisterHandler<Inventory.Events.Deactivated>(listView.Handle);
            ServiceLocator.Bus = bus;
        }
    }
}