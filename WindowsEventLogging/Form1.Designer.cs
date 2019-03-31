namespace WindowsEventLogging
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonToday = new System.Windows.Forms.Button();
            this.buttonDuration = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnActivity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelStatic = new System.Windows.Forms.Label();
            this.labelAverage = new System.Windows.Forms.Label();
            this.dateTimePickerDay = new System.Windows.Forms.DateTimePicker();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonToday
            // 
            this.buttonToday.Location = new System.Drawing.Point(12, 34);
            this.buttonToday.Name = "buttonToday";
            this.buttonToday.Size = new System.Drawing.Size(143, 60);
            this.buttonToday.TabIndex = 0;
            this.buttonToday.Text = "Show Activity During Specific Day";
            this.buttonToday.UseVisualStyleBackColor = true;
            this.buttonToday.Click += new System.EventHandler(this.buttonToday_Click);
            // 
            // buttonDuration
            // 
            this.buttonDuration.Location = new System.Drawing.Point(12, 128);
            this.buttonDuration.Name = "buttonDuration";
            this.buttonDuration.Size = new System.Drawing.Size(143, 60);
            this.buttonDuration.TabIndex = 1;
            this.buttonDuration.Text = "Show Activity During Specific Duration";
            this.buttonDuration.UseVisualStyleBackColor = true;
            this.buttonDuration.Click += new System.EventHandler(this.buttonDuration_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(12, 194);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(143, 20);
            this.dateTimePickerStart.TabIndex = 2;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(12, 220);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(143, 20);
            this.dateTimePickerEnd.TabIndex = 3;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDay,
            this.ColumnActivity});
            this.dataGridView.Location = new System.Drawing.Point(161, 34);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(240, 206);
            this.dataGridView.TabIndex = 4;
            // 
            // ColumnDay
            // 
            this.ColumnDay.HeaderText = "Day";
            this.ColumnDay.Name = "ColumnDay";
            // 
            // ColumnActivity
            // 
            this.ColumnActivity.HeaderText = "Activity";
            this.ColumnActivity.Name = "ColumnActivity";
            // 
            // labelStatic
            // 
            this.labelStatic.AutoSize = true;
            this.labelStatic.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatic.Location = new System.Drawing.Point(12, 257);
            this.labelStatic.Name = "labelStatic";
            this.labelStatic.Size = new System.Drawing.Size(73, 19);
            this.labelStatic.TabIndex = 5;
            this.labelStatic.Text = "Average:";
            // 
            // labelAverage
            // 
            this.labelAverage.AutoSize = true;
            this.labelAverage.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAverage.Location = new System.Drawing.Point(19, 304);
            this.labelAverage.Name = "labelAverage";
            this.labelAverage.Size = new System.Drawing.Size(0, 19);
            this.labelAverage.TabIndex = 6;
            // 
            // dateTimePickerDay
            // 
            this.dateTimePickerDay.Location = new System.Drawing.Point(12, 102);
            this.dateTimePickerDay.Name = "dateTimePickerDay";
            this.dateTimePickerDay.Size = new System.Drawing.Size(143, 20);
            this.dateTimePickerDay.TabIndex = 7;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.Location = new System.Drawing.Point(299, 246);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(102, 23);
            this.buttonClear.TabIndex = 8;
            this.buttonClear.Text = "Clear Display";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimer.Location = new System.Drawing.Point(457, 102);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(161, 39);
            this.labelTimer.TabIndex = 9;
            this.labelTimer.Text = "00:00:00";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(429, 53);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(0, 19);
            this.labelDate.TabIndex = 10;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 346);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.dateTimePickerDay);
            this.Controls.Add(this.labelAverage);
            this.Controls.Add(this.labelStatic);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.buttonDuration);
            this.Controls.Add(this.buttonToday);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Activity Monitor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonToday;
        private System.Windows.Forms.Button buttonDuration;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnActivity;
        private System.Windows.Forms.Label labelStatic;
        private System.Windows.Forms.Label labelAverage;
        private System.Windows.Forms.DateTimePicker dateTimePickerDay;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Timer timer;

    }
}

