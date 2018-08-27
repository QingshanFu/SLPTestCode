namespace SLPValidation.Helper
{
    using SLPValidation.Controllers;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Filters;

    /// <summary>
    /// A class for authentication the current user
    /// </summary>
    public class AuthenticationAttribute : FilterAttribute, IAuthenticationFilter
    {
        /// <summary>
        /// If the user has administrator permission, direct to admin page; otherwise redirect to home page
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = (LoginUser)HttpContext.Current.Session["UserInfo"];
            
            if (user == null)
            {
                var Url = new UrlHelper(filterContext.RequestContext);
                var url = Url.Action("Login", "Account");
                filterContext.Result = new RedirectResult(url);
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}