namespace Visualisation
{
    partial class FormVisualisation
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.panelFrame = new System.Windows.Forms.Panel();
            this.comboBoxSorting = new System.Windows.Forms.ComboBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelCurrentArray = new System.Windows.Forms.Label();
            this.labelNextArray = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.numericUpDownDelay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStart.Location = new System.Drawing.Point(229, 506);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(79, 21);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Начать";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panelFrame
            // 
            this.panelFrame.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelFrame.BackColor = System.Drawing.Color.Black;
            this.panelFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFrame.Location = new System.Drawing.Point(0, 0);
            this.panelFrame.Name = "panelFrame";
            this.panelFrame.Size = new System.Drawing.Size(500, 500);
            this.panelFrame.TabIndex = 2;
            // 
            // comboBoxSorting
            // 
            this.comboBoxSorting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxSorting.FormattingEnabled = true;
            this.comboBoxSorting.Items.AddRange(new object[] {
            "Bubble sort",
            "Heap sort",
            "Selection sort",
            "Shell sort",
            "Quick sort",
            "Comb sort",
            "Insertion sort",
            "Shaker sort"});
            this.comboBoxSorting.Location = new System.Drawing.Point(12, 506);
            this.comboBoxSorting.Name = "comboBoxSorting";
            this.comboBoxSorting.Size = new System.Drawing.Size(211, 21);
            this.comboBoxSorting.TabIndex = 3;
            this.comboBoxSorting.Text = "Выберите алгоритм сортировки";
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.Location = new System.Drawing.Point(290, 603);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(190, 26);
            this.labelTime.TabIndex = 6;
            this.labelTime.Text = "Время:";
            // 
            // labelInfo
            // 
            this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfo.Location = new System.Drawing.Point(9, 530);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(226, 26);
            this.labelInfo.TabIndex = 7;
            this.labelInfo.Text = "Ожидание...";
            // 
            // labelCurrentArray
            // 
            this.labelCurrentArray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrentArray.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCurrentArray.Location = new System.Drawing.Point(9, 553);
            this.labelCurrentArray.Name = "labelCurrentArray";
            this.labelCurrentArray.Size = new System.Drawing.Size(468, 22);
            this.labelCurrentArray.TabIndex = 8;
            this.labelCurrentArray.Text = "Текущий массив:";
            // 
            // labelNextArray
            // 
            this.labelNextArray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNextArray.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNextArray.Location = new System.Drawing.Point(9, 578);
            this.labelNextArray.Name = "labelNextArray";
            this.labelNextArray.Size = new System.Drawing.Size(468, 22);
            this.labelNextArray.TabIndex = 9;
            this.labelNextArray.Text = "Следующий массив:";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(314, 507);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(166, 20);
            this.textBoxAmount.TabIndex = 10;
            this.textBoxAmount.Text = "Введите число элементов";
            this.textBoxAmount.Click += new System.EventHandler(this.textBoxAmount_Click);
            // 
            // numericUpDownDelay
            // 
            this.numericUpDownDelay.Location = new System.Drawing.Point(395, 530);
            this.numericUpDownDelay.Name = "numericUpDownDelay";
            this.numericUpDownDelay.Size = new System.Drawing.Size(85, 20);
            this.numericUpDownDelay.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(265, 530);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Задержка (ms):";
            // 
            // FormVisualisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 638);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownDelay);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.labelNextArray);
            this.Controls.Add(this.labelCurrentArray);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.comboBoxSorting);
            this.Controls.Add(this.panelFrame);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormVisualisation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Визуализация алгоритмов сортировки";
            this.Load += new System.EventHandler(this.FormVisualisation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Panel panelFrame;
        private System.Windows.Forms.ComboBox comboBoxSorting;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelCurrentArray;
        private System.Windows.Forms.Label labelNextArray;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.NumericUpDown numericUpDownDelay;
        private System.Windows.Forms.Label label1;
    }
}

