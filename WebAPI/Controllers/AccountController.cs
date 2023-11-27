using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOS;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork uow;
        public AccountController(IUnitOfWork uow)
        {
            this.uow = uow;   
        }

        //api/account/login

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDTO loginReq)
        {
            var user = await uow.UserRepository.Authenticate(loginReq.UserName, loginReq.Password);

            if(user == null)
            {
                return Unauthorized();
            }

            var loginRes = new LoginResDTO();
            loginRes.UserName = user.Username;
            loginRes.Token = "Token to be genereated";
            return Ok(loginRes);
        }
    }
}