namespace TicTacToeAI
{
    public interface IAI
    {
        Point GetCurrentTurnAfterPLayer(int[,] desk);

        int GetTypeOfShape();
    }
}