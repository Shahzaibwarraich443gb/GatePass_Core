using GatePass_DBContext;
using GatePass_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GatePass_Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly AppDBContext _context;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, AppDBContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel obj)
        {
            try
            {
                if (!_context.company.Any(x => x.CompanyKey == obj.companyKey))
                {
                    return BadRequest(new { message = "incorrect key" });
                }
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser { UserName = obj.email, Email = obj.email, PhoneNumber = obj.phoneNumber };
                    var res = await userManager.CreateAsync(user, obj.password);
                    if (res.Succeeded)
                    {
                        UserCompanyModel model = new UserCompanyModel()
                        {
                            CompanyId = _context.company.Where(x => x.CompanyKey == obj.companyKey).FirstOrDefault().CompanyId,
                            userId = user.Id
                        };

                        UserNamingModel model2 = new UserNamingModel()
                        {
                            userId = user.Id,
                            fullName = obj.fullName
                        };
                        _context.userCompany.Add(model);
                        _context.userFullName.Add(model2);
                        _context.SaveChanges();
                        return Ok(new { message = "Successful" });
                        //await signInManager.SignInAsync(user, false); //parameters = (user to login, isCookie)
                    }
                    else
                    {
                        return BadRequest(new { message = "validation error", errors = res.Errors });
                    }
                }
                else
                {
                    return BadRequest(new { message = "Failure" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel obj)
        {
            try
            {
                var res = await signInManager.PasswordSignInAsync(obj.email, obj.password, false, false);
                if (res.Succeeded)
                {
                    var userData = _context.Users.Where(x => x.Email == obj.email).FirstOrDefault();
                    var companyId = _context.userCompany.Where(x => x.userId == userData.Id).FirstOrDefault().CompanyId;
                    var userDataModel = new
                    {
                        token = userData.Id,
                        email = userData.Email,
                        fullName = _context.userFullName.Where(x => x.userId == userData.Id).FirstOrDefault().fullName,
                        companyName = _context.company.Where(x => x.CompanyId == companyId).FirstOrDefault().CompanyName
                    };
                    return Ok(new { message = "Successful", userData = userDataModel});
                }
                else
                {
                    return BadRequest(new { message = "Email or Password is Incorrect ! " });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
