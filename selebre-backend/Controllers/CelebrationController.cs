using Microsoft.AspNetCore.Mvc;
using Selebre.Core.Celebration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace selebre_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CelebrationController : ControllerBase
    {
        private readonly ICelebrationService celebrationService;
        public CelebrationController(ICelebrationService celebrationService)
        {
            this.celebrationService = celebrationService;
        }

        
        // GET api/<CelebrationController>/5
        [HttpGet("myCelebration/{id}")]
        public bool Get(int id)
        {
            return this.celebrationService.IsCelebrationTodayForUser(id);
        }

    }
}
