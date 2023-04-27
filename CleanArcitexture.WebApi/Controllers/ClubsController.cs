using CleanArcitexture.Application.Features.Clubs.Queries.GetAllClubs;
using CleanArcitexture.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArcitexture.WebApi.Controllers
{
   
    public class ClubsController : ApiControllerBase
    {
        private readonly IMediator _mediatR;

        public ClubsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllClubsDto>>>> Get()
        {
            return await _mediatR.Send(new GetAllClubsQuery());
        }
    }
}
