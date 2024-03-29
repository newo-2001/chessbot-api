﻿using Chessbot.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessbot.Domain.Interfaces
{
    public interface IChessPlayer
    {
        public Task<Move> Move(IReadonlyStateProvider stateProvider);
    }
}
