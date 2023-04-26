using CleanArcitexture.Application.Interfaces.Repositories;
using CleanArcitexture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArcitexture.Persistence.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IGenericRepository<Player> _repository;
        public PlayerRepository(IGenericRepository<Player> repository)
        {
            _repository = repository;
        }
        public async Task<List<Player>> GetPlayesByClubAsync(int clubId)
        {
            return await _repository.Entities.Where(x => x.ClubId == clubId).ToListAsync();
        }
    }
}
