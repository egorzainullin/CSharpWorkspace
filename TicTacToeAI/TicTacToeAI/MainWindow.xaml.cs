using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToeAI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TicTacToeGrid.DataContext = game;
        }

        TicTacToeGameLogic game = new TicTacToeGameLogic();

        private void OnCellMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (game.IsGameEnded)
            {
                return;
            }
            var label = sender as Label;
            Point turn = TicTacToeGameLogic.StringToPointConvert(label.Tag.ToString());
            game.SetTurn(turn);
            CheckForWinning();
            if (game.IsGameEnded)
            {
                return;
            }
            game.WaitForBotTurn();
            CheckForWinning();
        }

        private void CheckForWinning()
        {
            if (game.SomeoneWin() == 1)
            {
                WinningLabel.Content = "Cross won";
                game.IsGameEnded = true;
            }
            if (game.SomeoneWin() == -1)
            {
                WinningLabel.Content = "Circle won";
                game.IsGameEnded = true;
            }
        }

        private void OnRestartButtonClick(object sender, RoutedEventArgs e)
        {
            game.Restart();
            game.IsGameEnded = false;
            WinningLabel.Content = "";
        }
    }
}
