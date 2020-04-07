using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApi.Models
{
    /// <summary>
    /// Http module for enabling 
    /// </summary>
    /// <seealso cref="System.Web.IHttpModule" />
    public class CorsModule : IHttpModule
    {
        private readonly HashSet<string> _allowedOrigin,
            _allowedOriginWithCredentials,
            _allowedMethods,
            _allowedHeaders;

        private int _preflightMaxAge;
        private CorsResult _corsResult;

        public CorsModule()
        {
            _allowedOrigin = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            _allowedOriginWithCredentials = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            _allowedMethods = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            _allowedHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpApplication" /> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application</param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += Application_BeginRequest;
            context.EndRequest += Application_EndRequest;

            ParseConfigHeaders("AllowedOrigins", _allowedOrigin);
            ParseConfigHeaders("AllowedOriginsWithCredentials", _allowedOriginWithCredentials);
            ParseConfigHeaders("AccessControlAllowMethods", _allowedMethods);
            ParseConfigHeaders("AccessControlAllowHeaders", _allowedHeaders);
            _preflightMaxAge = Convert.ToInt32(ConfigurationManager.AppSettings["AccessControlMaxAge"]);
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule" />.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Handles the BeginRequest event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Application_BeginRequest(object sender, EventArgs eventArgs)
        {
            if (!(sender is HttpApplication application)) return;

            var context = application.Context;
            var isPreflightRequest = ValidateRequest(context.Request);


            if (isPreflightRequest)
            {
                // OPTIONS request need not run the actual action, return as soon as we have required headers
                context.Response.StatusCode = (int)HttpStatusCode.NoContent;
                context.Response.End();
            }
        }

        /// <summary>
        /// Handles the EndRequest event of the Application control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Application_EndRequest(object source, EventArgs e)
        {
            if (!(source is HttpApplication application)) return;

            ApplyCorsResult(application.Context.Response);
        }

        private void ParseConfigHeaders(string settingName, HashSet<string> headers)
        {
            var commaSeparatedText = ConfigurationManager.AppSettings[settingName];
            if (!string.IsNullOrEmpty(commaSeparatedText))
            {
                foreach (var header in commaSeparatedText.Split(','))
                    headers.Add(header);
            }
        }

        /// <summary>
        /// Validates the request.
        /// </summary>
        /// <param name="currentRequest">The current request.</param>
        /// <returns>true, if its a CORS preflight request</returns>
        private bool ValidateRequest(HttpRequest currentRequest)
        {
            _corsResult = new CorsResult();
            if (currentRequest == null) return false;

            var origin = currentRequest.Headers.Get(CorsConstants.Origin);
            _corsResult.IsCrossOrigin = _allowedOrigin.Contains(origin, StringComparer.InvariantCultureIgnoreCase);

            if (_allowedOriginWithCredentials.Contains(origin, StringComparer.InvariantCultureIgnoreCase))
            {
                _corsResult.IsCrossOrigin = true;
                _corsResult.SupportsCredentials = true;
            }

            if (_corsResult.IsCrossOrigin)
            {
                _corsResult.AllowedOrigin = origin;

                foreach (var methods in _allowedMethods)
                    _corsResult.AllowedMethods.Add(methods);

                foreach (var header in _allowedHeaders)
                    _corsResult.AllowedHeaders.Add(header);

                _corsResult.PreflightMaxAge = _preflightMaxAge;
            }

            return currentRequest.HttpMethod.Equals(CorsConstants.PreflightHttpMethod,
                StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Applies the cors result.
        /// </summary>
        /// <param name="currentResponse">The current response.</param>
        private void ApplyCorsResult(HttpResponse currentResponse)
        {
            if (currentResponse == null || !_corsResult.IsCrossOrigin) return;

            currentResponse.Headers[CorsConstants.AccessControlAllowOrigin] = _corsResult.AllowedOrigin;
            currentResponse.Headers[CorsConstants.AccessControlAllowMethods] =
                string.Join(",", _corsResult.AllowedMethods);

            currentResponse.Headers[CorsConstants.AccessControlAllowHeaders] =
                string.Join(",", _corsResult.AllowedHeaders);
            currentResponse.Headers[CorsConstants.AccessControlMaxAge] = _corsResult.PreflightMaxAge.ToString();

            if (_corsResult.SupportsCredentials)
                currentResponse.Headers[CorsConstants.AccessControlAllowCredentials] = "true";

            // Add 'Vary' header based on origin, so that CDNs & browsers will know that
            // the CORS headers can differ based on the origin that makes the request.
            currentResponse.AppendHeader("Vary", "Origin");
        }
    }
}
internal class CorsResult
{
    public bool IsCrossOrigin { get; set; } = false;
    public string AllowedOrigin { get; set; }
    public bool SupportsCredentials { get; set; }
    public IList<string> AllowedMethods { get; } = new List<string>();
    public IList<string> AllowedHeaders { get; } = new List<string>();
    public IList<string> AllowedExposedHeaders { get; } = new List<string>();
    public int PreflightMaxAge { get; set; }
}
internal class CorsConstants
{
    public static readonly string PreflightHttpMethod = "Options";
    public static readonly string Origin = "Origin";
    public static readonly string AccessControlRequestMethod = "Access-Control-Request-Method";
    public static readonly string AccessControlRequestHeaders = "Access-Control-Request-Headers";

    public static readonly string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
    public static readonly string AccessControlAllowMethods = "Access-Control-Allow-Methods";
    public static readonly string AccessControlAllowHeaders = "Access-Control-Allow-Headers";
    public static readonly string AccessControlAllowCredentials = "Access-Control-Allow-Credentials";
    public static readonly string AccessControlMaxAge = "Access-Control-Max-Age";
}