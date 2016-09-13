namespace Core.Katas.Draughts
{
    /// <summary>
    /// represents a position on a board.
    /// </summary>
    public interface IPosition
    {
        /// <summary>
        /// gets the horizontal coordinate.
        /// </summary>
        int X { get; }

        /// <summary>
        /// Gets the vertical coordinate.
        /// </summary>
        int Y { get; }
    }
}