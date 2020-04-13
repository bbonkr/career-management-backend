using CareerManagement.Entities;
using CareerManagement.Models;
using CareerManagement.Web.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CareerController : ControllerBase
    {
        public CareerController(
            CareerStore careerStore,
            ILogger<CareerController> logger)
        {
            this.careerStore = careerStore;
            this.logger = logger;
        }

        [HttpGet]
        [Route("{username?}")]
        public async Task<IActionResult> Get(string username)
        {
            if (String.IsNullOrWhiteSpace(username))
            {
                return StatusCode(400, new HttpResponseMessageModel(400, "유효한 요청이 아닙니다."));
            }

            try
            {
                var user = await careerStore.FindByUsername(username);
                
                if(user == null)
                {
                    return StatusCode(404, new HttpResponseMessageModel(404, "데이터를 찾을 수 없습니다."));
                }

                //return  Ok(user);
                return StatusCode(200, new HttpResponseWithDataModel<User> { Data = user });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return StatusCode(500, new HttpResponseMessageModel(500, "요청 처리중 예외가 발생했습니다."));
            }
        }

        private readonly CareerStore careerStore;
        private readonly ILogger logger;
    }
}
