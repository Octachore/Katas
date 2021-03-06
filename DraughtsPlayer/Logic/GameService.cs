﻿using Core.Katas.Draughts;
using Core.Katas.Draughts.Helpers;
using Core.Utils.Defense;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DraughtsPlayer.Logic
{
    internal class GameService : INotifyPropertyChanged
    {
        private Bot _bot;

        private static IEnumerable<Piece> WhitePieces => new[]
        {
            new Piece(0, 0, Color.White),
            new Piece(2, 0, Color.White),
            new Piece(4, 0, Color.White),
            new Piece(6, 0, Color.White),
            new Piece(8, 0, Color.White),
            new Piece(1, 1, Color.White),
            new Piece(3, 1, Color.White),
            new Piece(5, 1, Color.White),
            new Piece(7, 1, Color.White),
            new Piece(9, 1, Color.White),
            new Piece(0, 2, Color.White),
            new Piece(2, 2, Color.White),
            new Piece(4, 2, Color.White),
            new Piece(6, 2, Color.White),
            new Piece(8, 2, Color.White),
            new Piece(1, 3, Color.White),
            new Piece(3, 3, Color.White),
            new Piece(5, 3, Color.White),
            new Piece(7, 3, Color.White),
            new Piece(9, 3, Color.White)
        };

        private static IEnumerable<Piece> BlackPieces => new[]
        {
            new Piece(0, 6, Color.Black),
            new Piece(2, 6, Color.Black),
            new Piece(4, 6, Color.Black),
            new Piece(6, 6, Color.Black),
            new Piece(8, 6, Color.Black),
            new Piece(1, 7, Color.Black),
            new Piece(3, 7, Color.Black),
            new Piece(5, 7, Color.Black),
            new Piece(7, 7, Color.Black),
            new Piece(9, 7, Color.Black),
            new Piece(0, 8, Color.Black),
            new Piece(2, 8, Color.Black),
            new Piece(4, 8, Color.Black),
            new Piece(6, 8, Color.Black),
            new Piece(8, 8, Color.Black),
            new Piece(1, 9, Color.Black),
            new Piece(3, 9, Color.Black),
            new Piece(5, 9, Color.Black),
            new Piece(7, 9, Color.Black),
            new Piece(9, 9, Color.Black)
        };

        public event PropertyChangedEventHandler PropertyChanged;

        public Board CurrentBoard { get; private set; }

        public string CurrentBoardRepresentation => CurrentBoard.Print("_");

        public List<Piece> CurrentWhitePieces => CurrentBoard.GetWhitePieces().Where(p => CurrentBoard.GetPossibleMoves(p).Any()).ToList();

        public List<Piece> CurrentBlackPieces => CurrentBoard.GetBlackPieces().Where(p => CurrentBoard.GetPossibleMoves(p).Any()).ToList();

        public BindingList<Move> MovesHistory { get; }

        public Piece SelectedWhitePiece { get; set; }

        public List<Move> PossibleMoves => SelectedWhitePiece == null ? new List<Move>() : CurrentBoard.GetPossibleMoves(SelectedWhitePiece).ToList();

        public GameService()
        {
            MovesHistory = new BindingList<Move>();
        }

        public void StartNewGame()
        {
            MovesHistory.Clear();
            CurrentBoard = new Board();
            CurrentBoard.Add(WhitePieces);
            CurrentBoard.Add(BlackPieces);
            _bot = new Bot(CurrentBoard);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void PlayRound(Move move)
        {
            Guard.Requires(move != null, new ArgumentNullException(nameof(move)));

            if (move is TakingMove)
            {
                IEnumerable<Move> moves = _bot.PlayTakingMove((Piece)move.Origin, (Piece)move.Target);
                foreach (Move m in moves)
                {
                    MovesHistory.Add(m);
                }
            }
            else
            {
                SelectedWhitePiece.Square = new Square(move.Target.X, move.Target.Y);
                MovesHistory.Add(move);
            }
        }

        public bool CanAct(Piece piece) => (piece != null) && CurrentBoard.GetPossibleMoves(piece).Any();

        public void PlayBotRound()
        {
            IEnumerable<Move> moves = _bot.PlayTurn(Color.Black);

            foreach (Move move in moves)
            {
                MovesHistory.Add(move);
            }
        }
    }
}