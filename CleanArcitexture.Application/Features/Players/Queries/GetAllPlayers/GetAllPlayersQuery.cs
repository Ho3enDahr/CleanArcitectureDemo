using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArcitexture.Application.Interfaces.Repositories;
using CleanArcitexture.Domain.Entities;
using CleanArcitexture.Shared;
using CleanArcitexture.Shared.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArcitexture.Application.Features.Players.Queries.GetAllPlayers
{
    public record GetAllPlayersQuery: IRequest<Result<List<GetAllPlayersDto>>>
    {
        internal class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, Result<List<GetAllPlayersDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public GetAllPlayersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<Result<List<GetAllPlayersDto>>> Handle(GetAllPlayersQuery query, CancellationToken cancellationToken)
            {
                var players = await _unitOfWork.Repository<Player>().Entities
                       .ProjectTo<GetAllPlayersDto>(_mapper.ConfigurationProvider)
                       .ToListAsync(cancellationToken);

                return await Result<List<GetAllPlayersDto>>.SuccessAsync(players);
            }
        }
       
    }
}
