using CleanArcitexture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArcitexture.Application.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetPlayesByClubAsync(int clubId);
    }
}
