﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Abstract
{
    public interface IGameRepository
    {
        IEnumerable<Game> Games { get; }

        void SaveGame(Game game); //Not in SOLID!!!
        Game DeleteGame(int gameId);
    }
}
