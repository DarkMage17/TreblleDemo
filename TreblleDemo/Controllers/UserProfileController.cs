using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TreblleDemo.Models;

namespace TreblleDemo.Controllers
{
    [Authorize]
    [Route("API/UserProfile")]
    public class UserProfileController : ApiController
    {
        // GET: api/UserProfile
        public string Get(string userName)
        {
            using(var context = new UserProfileDBContext())
            {
                var query = context.Users.FirstOrDefault(x => x.UserName == userName);
                if (query == null)
                    return null;
                return query.ProfileImage;
            }
        }

        // POST: api/UserProfile
        public IHttpActionResult Post([FromBody] UserProfileModel userProfile)
        {
            using (var context = new UserProfileDBContext())
            {
                var result = context.Users.SingleOrDefault(u => u.UserName == userProfile.UserName);
                if(result != null)
                {
                    result.ProfileImage = userProfile.ProfileImage;
                    context.SaveChanges();
                }
                return Ok();
            }
        }
    }
}
