using Core.Katas.Draughts;

namespace DraughtsPlayer.Logic
{
    internal class BoardTransition
    {
        public Board InitialBoard { get; set; }

        public Board FinalBoard { get; set; }

        public string Description { get; set; }

        public BoardTransition(Board initialBoard, Board finalBoard, string description)
        {
            InitialBoard = initialBoard;
            FinalBoard = finalBoard;
            Description = description;
        }

        public override string ToString() => Description;
    }
}