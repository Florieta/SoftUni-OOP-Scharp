using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class GameResult
    {
        public GameResult(Symbol winner, Board board)
        {
            Winner = winner;
            Board = board;
        }

        public Symbol Winner { get; }
        public Board Board { get; }
    }
}
