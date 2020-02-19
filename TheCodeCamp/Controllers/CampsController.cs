using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TheCodeCamp.Data;
using TheCodeCamp.Models;

namespace TheCodeCamp.Controllers
{
    public class CampsController : ApiController
    {
        private readonly ICampRepository repository;
        private readonly IMapper mapper;

        public CampsController(ICampRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await repository.GetAllCampsAsync();
                var mapperResult = mapper.Map<IEnumerable<CampModel>>(result);
                
                return Ok(mapperResult);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
