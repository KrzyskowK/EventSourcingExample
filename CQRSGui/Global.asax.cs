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
            var commands = new InventoryCommandHandlers(storage);
            bus.RegisterHandler<CheckInItemsToInventoryCommand>(commands.Handle);
            bus.RegisterHandler<CreateInventoryItemCommand>(commands.Handle);
            bus.RegisterHandler<DeactivateInventoryItemCommand>(commands.Handle);
            bus.RegisterHandler<RemoveItemsFromInventoryCommand>(commands.Handle);
            bus.RegisterHandler<RenameInventoryItemCommand>(commands.Handle);
            var detail = new InventoryItemDetailsView();
            bus.RegisterHandler<InventoryItem.Events.Created>(detail.Handle);
            bus.RegisterHandler<InventoryItem.Events.Deactivated>(detail.Handle);
            bus.RegisterHandler<InventoryItem.Events.Renamed>(detail.Handle);
            bus.RegisterHandler<InventoryItem.Events.CheckedInToInventory>(detail.Handle);
            bus.RegisterHandler<InventoryItem.Events.RemovedFromInventory>(detail.Handle);
            var list = new InventoryListView();
            bus.RegisterHandler<InventoryItem.Events.Created>(list.Handle);
            bus.RegisterHandler<InventoryItem.Events.Renamed>(list.Handle);
            bus.RegisterHandler<InventoryItem.Events.Deactivated>(list.Handle);
            ServiceLocator.Bus = bus;
        }
    }
}