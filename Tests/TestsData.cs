using Core.Katas.Draughts;

namespace Tests
{
    public static class TestsData
    {
        public static class Kata
        {
            public static class Draughts
            {
                public static class BoardExtensions
                {
                    public static class PrintBoard
                    {
                        private static Board _board1;
                        private static string _board1Representation;

                        private static Board _board2;
                        private static string _board2Representation;

                        private static Board _board3;
                        private static string _board3Representation;

                        public static object[] Data
                        {
                            get
                            {
                                InitBoards();
                                return new object[]
                                       {
                                           new object[] {_board1, _board1Representation},
                                           new object[] {_board2, _board2Representation},
                                           new object[] {_board3, _board3Representation}
                                       };
                            }
                        }

                        private static void InitBoards()
                        {
                            _board1 = new Board();
                            _board1Representation = "..........\r\n..........\r\n..........\r\n..........\r\n..........\r\n..........\r\n..........\r\n..........\r\n..........\r\n..........\r\n";

                            _board2 = new Board();
                            _board2.Add(new Piece(0, 0, Color.White));
                            _board2Representation = "..........\r\n..........\r\n..........\r\n..........\r\n..........\r\n..........\r\n..........\r\n..........\r\n..........\r\nW.........\r\n";

                            _board3 = new Board();
                            var pieces = new[]
                                         {
                                             new Piece(0, 0, Color.White),
                                             new Piece(4, 4, Color.White),
                                             new Piece(3, 9, Color.White),
                                             new Piece(2, 7, Color.White),
                                             new Piece(8, 6, Color.White),
                                             new Piece(9, 0, Color.White),
                                             new Piece(5, 3, Color.Black),
                                             new Piece(9, 3, Color.Black),
                                             new Piece(0, 4, Color.Black),
                                             new Piece(9, 2, Color.Black),
                                             new Piece(7, 7, Color.Black),
                                             new Piece(0, 3, Color.Black)
                                         };
                            _board3.Add(pieces);
                            _board3Representation = "...W......\r\n..........\r\n..W....B..\r\n........W.\r\n..........\r\nB...W.....\r\nB....B...B\r\n.........B\r\n..........\r\nW........W\r\n";
                        }
                    }
                }
            }
        }
    }
}