using System;
using System.Windows.Forms;

namespace WatchApp
{
    public partial class WatchForm : Form
    {
        /// <summary>
        /// Инициализирует форму <see cref="WatchForm"/>
        /// Устанавливает текущее время, включает таймер
        /// </summary>
        public WatchForm()
        {
            InitializeComponent();
            SetCurrentTime();
            timerForUpdatingTime.Enabled = true;
        }

        /// <summary>
        /// Поле, необходимое для мигания двоеточия
        /// </summary>
        private bool SecondCounter;

        /// <summary>
        /// Показывает текущее время
        /// </summary>
        private void SetCurrentTime()
        {
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            string tempString = " ";
            if (SecondCounter)
            {
                tempString = ":";
            }
            hourLabel.Text = hour.ToString();
            if (minute < 10)
            {
                minuteLabel.Text = "0" + minute;
            }
            else
            {
                minuteLabel.Text = minute.ToString();
            }
            secondCounterLabel.Text = tempString;
            SecondCounter = !SecondCounter;
        }

        /// <summary>
        /// Событие, необходимое для обновления значения времени
        /// </summary>
        /// <param name="sender">Объект-отправитель</param>
        /// <param name="e">Данные события</param>
        private void OntimerForUpdatingTimeTick(object sender, EventArgs e)
        {
            SetCurrentTime();
            timerForUpdatingTime.Enabled = true; ;
        }
    }
}
