using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace cbbmsR3.Controllers
{
    public abstract class BaseController : Controller
    {
        public string UserId { get; private set; }
        protected BaseController()
        {
        }
  
        public virtual ActionResult NotEmptyView(Object model)
        {
            if (model == null)
                return RedirectToNotFound();

            return View(model);
        }
        public virtual ActionResult RedirectToLocal(String url)
        {
            if (!Url.IsLocalUrl(url))
                return RedirectToDefault();

            return Redirect(url);
        }
        public virtual RedirectToRouteResult RedirectToDefault()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public virtual RedirectToRouteResult RedirectToNotFound()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public virtual RedirectToRouteResult RedirectToUnauthorized()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public virtual RedirectToRouteResult RedirectIfAuthorized(String action)
        {
            return RedirectIfAuthorized(action, null, null);
        }
        public virtual RedirectToRouteResult RedirectIfAuthorized(String action, Object route)
        {
            return RedirectIfAuthorized(action, null, route);
        }
        public virtual RedirectToRouteResult RedirectIfAuthorized(String action, String controller)
        {
            return RedirectIfAuthorized(action, controller, null);
        }
        public virtual RedirectToRouteResult RedirectIfAuthorized(String action, String controller, Object route)
        {
            RouteValueDictionary values = new RouteValueDictionary(route);
            String area = (values["area"] ?? RouteData.Values["area"]) as String;
            controller = (controller ?? values["controller"] ?? RouteData.Values["controller"]) as String;

            ////if (!IsAuthorizedFor(action, controller, area))
            ////    return RedirectToDefault();

            return RedirectToAction(action, controller, values);
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, Object state)
        {
            UserId = User.Identity.GetUserId();
            return base.BeginExecuteCore(callback, state);
        }
        protected override void OnAuthorization(AuthorizationContext context)
        {
            if (!User.Identity.IsAuthenticated) return;

            String area = context.RouteData.Values["area"] as String;
            String action = context.RouteData.Values["action"] as String;
            String controller = context.RouteData.Values["controller"] as String;

            //if (!IsAuthorizedFor(action, controller, area))
            //    context.Result = RedirectToUnauthorized();
        }
        protected override void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
