using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArcitexture.Application.Common.Mapping;
using CleanArcitexture.Application.Interfaces.Repositories;
using CleanArcitexture.Domain.Entities;
using CleanArcitexture.Shared;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArcitexture.Application.Features.Clubs.Queries.GetAllClubs
{
    public record GetAllClubsQuery:IRequest<Result<List<GetAllClubsDto>>>
    {
        internal class GetAllClubsQueryHandler:IRequestHandler<GetAllClubsQuery, Result<List<GetAllClubsDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetAllClubsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<Result<List<GetAllClubsDto>>> Handle(GetAllClubsQuery query, CancellationToken cancellationToken)
            {
                var clubs = await _unitOfWork.Repository<Club>().Entities.ProjectTo<GetAllClubsDto>(_mapper.ConfigurationProvider).ToListAsync();
                return await Result<List<GetAllClubsDto>>.SuccessAsync(clubs);
            }
        }
    }
}
