namespace WatchApp
{
    partial class WatchForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerForUpdatingTime = new System.Windows.Forms.Timer(this.components);
            this.hourLabel = new System.Windows.Forms.Label();
            this.minuteLabel = new System.Windows.Forms.Label();
            this.secondCounterLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerForUpdatingTime
            // 
            this.timerForUpdatingTime.Interval = 1000;
            this.timerForUpdatingTime.Tick += new System.EventHandler(this.OntimerForUpdatingTimeTick);
            // 
            // hourLabel
            // 
            this.hourLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hourLabel.AutoSize = true;
            this.hourLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hourLabel.Location = new System.Drawing.Point(3, 0);
            this.hourLabel.Name = "hourLabel";
            this.hourLabel.Size = new System.Drawing.Size(196, 182);
            this.hourLabel.TabIndex = 1;
            this.hourLabel.Text = "16";
            this.hourLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // minuteLabel
            // 
            this.minuteLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minuteLabel.AutoSize = true;
            this.minuteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minuteLabel.Location = new System.Drawing.Point(245, 0);
            this.minuteLabel.Name = "minuteLabel";
            this.minuteLabel.Size = new System.Drawing.Size(178, 182);
            this.minuteLabel.TabIndex = 2;
            this.minuteLabel.Text = "43";
            this.minuteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // secondCounterLabel
            // 
            this.secondCounterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secondCounterLabel.AutoSize = true;
            this.secondCounterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondCounterLabel.Location = new System.Drawing.Point(202, 0);
            this.secondCounterLabel.Margin = new System.Windows.Forms.Padding(0);
            this.secondCounterLabel.Name = "secondCounterLabel";
            this.secondCounterLabel.Size = new System.Drawing.Size(40, 182);
            this.secondCounterLabel.TabIndex = 3;
            this.secondCounterLabel.Text = ":";
            this.secondCounterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.61905F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.85714F));
            this.tableLayoutPanel1.Controls.Add(this.hourLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.minuteLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.secondCounterLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(426, 153);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(426, 182);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // WatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 182);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(426, 153);
            this.Name = "WatchForm";
            this.Text = "Watch";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerForUpdatingTime;
        private System.Windows.Forms.Label hourLabel;
        private System.Windows.Forms.Label minuteLabel;
        private System.Windows.Forms.Label secondCounterLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

