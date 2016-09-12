using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using VOMO.Context;
using VOMO.Context.Entities;

namespace VOMO.Web.Controllers
{
    public class BaseController : Controller
    {
        private VomoContext _vomo;
        private ApplicationUserManager _userManager;

        protected VomoContext Vomo
        {
            get { return _vomo ?? (_vomo = VomoContext.Create()); }
        }

        protected ApplicationUserManager UserManager
        {
            get { return _userManager ?? (_userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>()); }
            set { _userManager = value; }
        }

        protected User LoggedInUser
        {
            get { return UserManager.FindById(User.Identity.GetUserId<int>()); }
        }

        public BaseController()
        {
            
        }
    }
}