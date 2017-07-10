using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeAI
{
    public class TicTacToeGameLogic : INotifyPropertyChanged
    {
        public int[,] CurrentDeskValues = new int[3, 3];

        private string ConvertToShape(int value)
        {
            if (value == 1)
            {
                return "x";
            }
            if (value == -1)
            {
                return "0";
            }
            return "";
        }

        public string FirstCell => ConvertToShape(CurrentDeskValues[0, 0]);

        public string SecondCell => ConvertToShape(CurrentDeskValues[0, 1]);

        public string ThirdCell => ConvertToShape(CurrentDeskValues[0, 2]);

        public string FourthCell => ConvertToShape(CurrentDeskValues[1, 0]);

        public string FifthCell => ConvertToShape(CurrentDeskValues[1, 1]);

        public string SixthCell => ConvertToShape(CurrentDeskValues[1, 2]);

        public string SeventhCell => ConvertToShape(CurrentDeskValues[2, 0]);

        public string EighthCell => ConvertToShape(CurrentDeskValues[2, 1]);

        public string NinethCell => ConvertToShape(CurrentDeskValues[2, 2]);

        IAI bot = new AI();

        public bool TurnNumber = true;

        public bool IsGameEnded = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public TicTacToeGameLogic(int[,] desk)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    CurrentDeskValues[i, j] = desk[i, j];
                }
            }
        }

        public TicTacToeGameLogic()
        {
        }

        public bool IsTurnCorrect(Point value) => CurrentDeskValues[value.X, value.Y] == 0;

        public static Point StringToPointConvert(string points)
        {
            int firstCoor = Int32.Parse(points.Substring(0, points.IndexOf(' ')));
            int secondCoor = Int32.Parse(points.Substring(points.IndexOf(' ') + 1));
            return new Point(firstCoor, secondCoor);
        }

        private int GorisontalWinning()
        {
            int currentMaxWithSign = 0;
            for (int i = 0; i < 3; i++)
            {
                int currentLineValue = CurrentDeskValues[i, 0] + CurrentDeskValues[i, 1] + CurrentDeskValues[i, 2];
                if (Math.Abs(currentLineValue) > Math.Abs(currentMaxWithSign))
                {
                    currentMaxWithSign = currentLineValue;
                }
            }
            return currentMaxWithSign;
        }

        private int VerticalWinning()
        {
            int currentMaxWithSign = 0;
            for (int i = 0; i < 3; i++)
            {
                int currentLineValue = CurrentDeskValues[0, i] + CurrentDeskValues[1, i] + CurrentDeskValues[2, i];
                if (Math.Abs(currentLineValue) > Math.Abs(currentMaxWithSign))
                {
                    currentMaxWithSign = currentLineValue;
                }
            }
            return currentMaxWithSign;
        }

        private int DiagonalWinning()
        {
            int firstDiagonal = CurrentDeskValues[0, 0] + CurrentDeskValues[1, 1] + CurrentDeskValues[2, 2];
            int secondDiagonal = CurrentDeskValues[0, 2] + CurrentDeskValues[1, 1] + CurrentDeskValues[2, 0];
            return Math.Abs(firstDiagonal) > Math.Abs(secondDiagonal) ? firstDiagonal : secondDiagonal;
        }

        public int SomeoneWin()
        {
            if (GorisontalWinning() == 3 || VerticalWinning() == 3 || DiagonalWinning() == 3)
            {
                return 1;
            }
            if (GorisontalWinning() == -3 || VerticalWinning() == -3 || DiagonalWinning() == -3)
            {
                return -1;
            }
            return 0;
        }

        public static int SomeoneWin(int[,] CurrentDeskValues)
        {
            var game = new TicTacToeGameLogic(CurrentDeskValues);
            return game.SomeoneWin();
        }

        public void Restart()
        {
            TurnNumber = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    CurrentDeskValues[i, j] = 0;
                }
            }
            OnPropertyChanged("FirstCell");
            OnPropertyChanged("SecondCell");
            OnPropertyChanged("ThirdCell");
            OnPropertyChanged("FourthCell");
            OnPropertyChanged("FifthCell");
            OnPropertyChanged("SixthCell");
            OnPropertyChanged("SeventhCell");
            OnPropertyChanged("EighthCell");
            OnPropertyChanged("NinethCell");
        }

        public Point GetAITurn()
        {
            var turn = bot.GetCurrentTurnAfterPLayer(CurrentDeskValues);
            return turn;
        }

        public void WaitForBotTurn()
        {
            var turn = GetAITurn();
            SetTurn(turn);
        }

        public bool SetTurn(Point turn)
        {
            int type = TurnNumber ? 1 : -1;
            if (turn == null)
            {
                return false;
            }
            if (IsTurnCorrect(turn))
            {
                CurrentDeskValues[turn.X, turn.Y] = type;
                TurnNumber = !TurnNumber;
            }
            else
            {
                return false;
            }
            int numberOfCell = turn.X * 3 + turn.Y + 1;
            switch(numberOfCell)
            {
                case 1:
                    OnPropertyChanged("FirstCell");
                    break;
                case 2:
                    OnPropertyChanged("SecondCell");
                    break;
                case 3:
                    OnPropertyChanged("ThirdCell");
                    break;
                case 4:
                    OnPropertyChanged("FourthCell");
                    break;
                case 5:
                    OnPropertyChanged("FifthCell");
                    break;
                case 6:
                    OnPropertyChanged("SixthCell");
                    break;
                case 7:
                    OnPropertyChanged("SeventhCell");
                    break;
                case 8:
                    OnPropertyChanged("EighthCell");
                    break;
                case 9:
                    OnPropertyChanged("NinethCell");
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}
