namespace Core.Katas.PaintFiller
{
    public static class Filler
    {
        private static int _color;
        private static int _newColor;

        public static void FillArea(int[,] array, int i, int j, int newColor)
        {
            _newColor = newColor;
            _color = array[i, j];

            if (_newColor == _color) return;

            Fill(array, i, j);
        }

        private static void Fill(int[,] array, int i, int j)
        {
            if ((i < 0) || (j < 0) || (i >= array.GetLength(0)) || (j >= array.GetLength(1))) return;
            if (array[i, j] != _color) return;

            array[i, j] = _newColor;

            Fill(array, i + 1, j);
            Fill(array, i - 1, j);
            Fill(array, i, j + 1);
            Fill(array, i, j - 1);
        }
    }
}
