using CareerManagement.Entities;
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
        [Route("{username}")]
        public async Task<string> Get(string username)
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(1));

                var user = await careerStore.FindByUsername(username);

                return username;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                throw ex;
            }
        }

        private readonly CareerStore careerStore;
        private readonly ILogger logger;
    }
}
