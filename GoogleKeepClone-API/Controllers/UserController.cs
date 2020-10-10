using GoogleKeepClone_API.Helpers;
using GoogleKeepClone_API.Models;
using GoogleKeepClone_API.Services;
using GoogleKeepClone_API.UnitOfWork;
using System.Web.Http;
namespace GoogleKeepClone_API.Controllers
{
    public class UserController : ApiController
    {
        private JWTService _JWTService;
        private KeepCloneContext ctx;
        private UOW uow;
        public UserController()
        {
            _JWTService = new JWTService();
            ctx = new KeepCloneContext();
            uow = new UOW(ctx);
        }
        ~UserController()
        {
            ctx.Dispose();
        }

        //[JWTAuth]
        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var jwtToken = _JWTService.GenerateToken(new LoginModel() { Username = "waiyan", FBid = "1", Photo = "hi" });
            var refreshToken = _JWTService.GenerateRefreshToken("apk");
            
            return Ok(Request);
        }

        [JWTAuth]
        [HttpGet]
        [Route("api/user")]
        public IHttpActionResult test(string ip)
        {
            return Ok();
        }

    }
}
