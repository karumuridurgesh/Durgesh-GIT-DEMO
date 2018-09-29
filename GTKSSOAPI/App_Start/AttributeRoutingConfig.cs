using System.Web.Routing;
using System.Web.Http;
using System.Web;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Threading;
using System.Web.Http.Controllers;
using System.Net;
using System.Web.Http.WebHost;
using System.Web.SessionState;
using Thinktecture.IdentityModel.Tokens.Http;
//using GTKSSOAPI.ServiceEndPoints;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GTKSSOAPI.AttributeRoutingConfig), "Start")]
namespace GTKSSOAPI
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class ValidateAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
    {
        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            try
            {
                //AntiForgery.Validate();
            }
            catch
            {
                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    RequestMessage = actionContext.ControllerContext.Request
                };
                return FromResult(actionContext.Response);
            }
            return continuation();
        }

        private Task<HttpResponseMessage> FromResult(HttpResponseMessage result)
        {
            var source = new TaskCompletionSource<HttpResponseMessage>();
            source.SetResult(result);
            return source.Task;
        }
    }

    public static class WebApiConfig
    {
        public static void Register(System.Web.Http.HttpConfiguration config)
        {

            var authConfig = new AuthenticationConfiguration
            {
                InheritHostClientIdentity = true,
                EnableSessionToken = false,
                RequireSsl = false// only for testing
            };

            // authConfig.AddBasicAuthentication()

            config.MessageHandlers.Add(new AuthenticationHandler(authConfig));
        }
    }

    public static class AttributeRoutingConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // See http://github.com/mccalltd/AttributeRouting/wiki for more options.
            // To debug routes locally using the built in ASP.NET development server, go to /routes.axd
            RouteTable.Routes.MapHttpRoute(
                 name: "GTKSSOAPI",
                 routeTemplate: "api/{controller}/{action}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             ).RouteHandler = new SessionStateRouteHandler();
            
        }

        public static void Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }

    public interface IDataPersistance<T>
    {
        T ObjectValue { get; set; }
    }

    public class SessionDataPersistance<T> : IDataPersistance<T>
      where T : class
    {
        private static string key = typeof(T).FullName.ToString();

        public T ObjectValue
        {
            get
            {
                return HttpContext.Current.Session[key] as T;
            }
            set
            {
                HttpContext.Current.Session[key] = value;
            }
        }
    }
    public class SessionStateRouteHandler : IRouteHandler
    {
        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            return new SessionableControllerHandler(requestContext.RouteData);
        }
    }
    public class SessionableControllerHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionableControllerHandler(RouteData routeData)
            : base(routeData)
        { }
    }
}
