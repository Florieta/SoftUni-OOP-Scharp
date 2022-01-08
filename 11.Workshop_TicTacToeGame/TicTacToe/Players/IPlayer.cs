using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Players
{
    public interface IPlayer
    {
        Index Play(Board board, Symbol symbol);
    }
}
