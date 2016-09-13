using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Core.Katas.Draughts;
using Core.Katas.Draughts.Helpers;

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

        public List<Piece> CurrentWhitePieces => CurrentBoard.WhitePieces().Where(p=> CurrentBoard.GetPossibleMoves(p).Any()).ToList();

        public List<Piece> CurrentBlackPieces => CurrentBoard.BlackPieces().Where(p => CurrentBoard.GetPossibleMoves(p).Any()).ToList();

        public BindingList<Mouve> MouvesHistory { get; }

        public Piece SelectedWhitePiece { get; set; }

        public List<Mouve> PossibleMouves => SelectedWhitePiece == null ? new List<Mouve>() : CurrentBoard.GetPossibleMoves(SelectedWhitePiece).ToList();

        public GameService()
        {
            MouvesHistory = new BindingList<Mouve>();
        }

        public void StartNewGame()
        {
            MouvesHistory.Clear();
            CurrentBoard = new Board();
            CurrentBoard.Add(WhitePieces);
            CurrentBoard.Add(BlackPieces);
            _bot = new Bot(CurrentBoard);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void PlayRound(Mouve mouve)
        {
            Board initialBoard = CurrentBoard.Clone();
            string message = $"W : {mouve}";

            if (mouve is TakingMouve)
            {
                ////IEnumerable<Mouve> mouves = CurrentBoard.Take(SelectedWhitePiece, mouve.Target);
                CurrentBoard.Take(SelectedWhitePiece, (Piece)mouve.Target);
            }
            else
            {
                SelectedWhitePiece.Square = new Square(mouve.Target.X, mouve.Target.Y);
            }

            MouvesHistory.Add(mouve);
        }

        public bool CanAct(Piece piece) => (piece != null) && CurrentBoard.GetPossibleMoves(piece).Any();

        public void PlayBotRound()
        {
            IEnumerable<Mouve> mouves = _bot.PlayTurn(Color.Black);

            foreach (Mouve mouve in mouves)
            {
                MouvesHistory.Add(mouve);
            }
        }
    }
}
