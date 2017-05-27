using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Krka2
{
    public partial class FindPair : Form
    {
        public FindPair()
        {
            InitializeComponent();
            InitializeArray();
            CreateButtons();
        }

        private const int n = 4;

        private Button[,] buttons = new Button[n, n];

        private int[,] values = new int[n, n];

        private Button firstButton;

        private int alreadyChecked = 0;

        private void CreateButtons()
        {
            if (n % 2 != 0)
            {
                throw new FormatException("incorrect n");
            }
            this.Size = new Size(n * 90 + 50, n * 30 + 50);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Name = values[i, j].ToString();
                    buttons[i, j].Text = "";
                    buttons[i, j].Size = new Size(80, 20);
                    buttons[i, j].Location = new Point(90 * i, 30 * j);
                    this.Controls.Add(buttons[i, j]);
                    buttons[i, j].Click += new EventHandler(OnButtonClick);
                }
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.Text = "";
            if (firstButton != null)
            {
                firstButton.Text = "";
            }
            if (firstButton == null)
            {
                button.Text = button.Name;
                firstButton = button;
                return;
            }
            firstButton.Text = button.Text;
            if (firstButton.Name == button.Name)
            {
                alreadyChecked += 2;
                button.Text = button.Name;
                firstButton.Enabled = false;
                button.Enabled = false;
                firstButton = null;
            }
            else
            {
                button.Text = button.Name;
                firstButton = null;
            }
            if (alreadyChecked == n * n)
            {
                buttons = null;
                end.Text = "end";
            }
        }

        private void InitializeArray()
        {
            values = GameInit.InitalizeArray(n);
        }
    }
}
