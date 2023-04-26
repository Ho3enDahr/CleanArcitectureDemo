using CleanArcitexture.Domain.Common;
using CleanArcitexture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArcitexture.Application.Features.Players.Commands.CreatePlayer
{
    public class PlayerCreatedEvent:BaseEvent
    {
        public Player Player { get; }
        public PlayerCreatedEvent(Player player)
        {
            Player = player;
        }
    }
}
