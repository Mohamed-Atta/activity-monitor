using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Globalization;
using System.IO;

namespace WindowsEventLogging
{
    public partial class Form1 : Form
    {
        int h, m, s, ms;
        CultureInfo ci = CultureInfo.InvariantCulture;

        public Form1()
        {
            InitializeComponent();
            ReadLog();
            SetFontAndColors();
            labelDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            setTimer(EvaluateDuration(DateTime.Now));
            dataGridView.Rows.Clear();
        }

        private List<string> ReadLog()
        {
            string line;
            List<string> lines = new List<string>();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString();
            System.IO.StreamReader file = new System.IO.StreamReader(path + @"\log.txt");

            while ((line = file.ReadLine()) != null)
                lines.Add(line);

            file.Close();
            
            return lines;
        }

        private string ParseLine(string input, string startMarker, string endMarker)
        {
            int pFrom = input.IndexOf(startMarker) + startMarker.Length;
            int pTo = input.LastIndexOf(endMarker);
            string result = input.Substring(pFrom, pTo - pFrom);
            return result;
        }

        private void SetFontAndColors()
        {
            this.dataGridView.DefaultCellStyle.Font = new Font("Tahoma", 12);
            this.dataGridView.DefaultCellStyle.ForeColor = Color.Blue;
            this.dataGridView.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridView.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            this.dataGridView.DefaultCellStyle.SelectionBackColor = Color.Black;
        }

        private TimeSpan EvaluateDuration(DateTime date) 
        {
            TimeSpan Total = TimeSpan.Zero;
            List<string> todayLines = new List<string>();
            List<string> allLines = new List<string>();
            List<string> todayTimeStamps = new List<string>();
            List<DateTime> todayTimeStampsDateTime = new List<DateTime>();
            List<int> flags = new List<int>();


            allLines = ReadLog();

            foreach (string line in allLines)
                if (line.Contains(date.ToShortDateString()))
                    todayLines.Add(line);

            foreach (string todayLine in todayLines)
                todayTimeStamps.Add(ParseLine(todayLine, "{", "}"));

            foreach (string item in todayTimeStamps)
                todayTimeStampsDateTime.Add(DateTime.ParseExact(item, "HH:mm", System.Globalization.CultureInfo.InvariantCulture));

            foreach (string item in todayLines)
            {
                if (item.Contains("Program started at") || item.Contains("I returned to my desk"))
                    flags.Add(1);
                else
                    flags.Add(0);
            }

            for (int i = 0; i < flags.Count - 1; i++)
            {
                if (flags[i] == 1 && flags[i + 1] == 0)
                {
                    Total += (todayTimeStampsDateTime[i + 1] - todayTimeStampsDateTime[i]);
                }
            }
            this.dataGridView.Rows.Add(date.ToShortDateString(), Total.ToString());
            return Total;
        }

        private void buttonToday_Click(object sender, EventArgs e)
        {
            TimeSpan todayTimeSpan = TimeSpan.Zero;
            todayTimeSpan = EvaluateDuration(dateTimePickerDay.Value);
        }

        private void buttonDuration_Click(object sender, EventArgs e)
        {
            TimeSpan totalSpan = TimeSpan.Zero;
            TimeSpan tempSpan = TimeSpan.Zero;
            DateTime[] dateTimes = new DateTime[] { };
            List<TimeSpan> accurateTimeSpan = new List<TimeSpan>();
            int length = 0;

            if (dateTimePickerStart.Value < dateTimePickerEnd.Value)
            {
                dateTimes  = Enumerable.Range(0, 1 + dateTimePickerEnd.Value.Subtract(dateTimePickerStart.Value).Days)
                    .Select(offset => dateTimePickerStart.Value.AddDays(offset)).ToArray();
                foreach (DateTime datetime in dateTimes)
                {
                    tempSpan = EvaluateDuration(datetime);
                    totalSpan += tempSpan;
                    accurateTimeSpan.Add(tempSpan);
                }
            }
            else
            {
                MessageBox.Show("Please enter end date after starting date!");
            }

            foreach (TimeSpan timeSpan in accurateTimeSpan)
            {
                if (timeSpan != TimeSpan.Zero)
                    length++;
                    
            }

            if(length != 0)
                labelStatic.Text = string.Format("Average activity from" + Environment.NewLine + " {0} to {1} is {2}",
                dateTimePickerStart.Value.ToShortDateString(),
                dateTimePickerEnd.Value.ToShortDateString(),
                TimeSpan.FromTicks(totalSpan.Ticks / length).ToString());
            else
                labelStatic.Text = string.Format("Average activity from" + Environment.NewLine + " {0} to {1} is Zero",
                dateTimePickerStart.Value.ToShortDateString(),
                dateTimePickerEnd.Value.ToShortDateString());

            
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                ms += 1;
                if (ms == 10)
                {
                    ms = 0;
                    s += 1;
                }
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                } 
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }
                labelTimer.Text = string.Format("{0}:{1}:{2}",
                    h.ToString().PadLeft(2, '0'),
                    m.ToString().PadLeft(2, '0'),
                    s.ToString().PadLeft(2, '0'));
            }));
        }

        static void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                //I left my desk
                LogTimeStamps(DateTime.Now, "I left my desk at");
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                //I returned to my desk
                LogTimeStamps(DateTime.Now, "I returned to my desk at");
            }
        }

        static void LogTimeStamps(DateTime timeStamp, string state)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + @"\log.txt";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(state + " {" + timeStamp.ToShortTimeString() + "} " + "[" + timeStamp.ToShortDateString() + "]");
                }
            }
            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(state + " {" + timeStamp.ToShortTimeString() + "} " + "[" + timeStamp.ToShortDateString() + "]");
            }
        }

        public void setTimer(TimeSpan timeSpan) 
        {
            string timeSpanString = timeSpan.ToString();

            if (timeSpanString.Substring(0, 1) == "0")
                h = Int32.Parse(timeSpanString.Substring(1, 1));
            else
                h = Int32.Parse(timeSpanString.Substring(0, 2));

            if (timeSpanString.Substring(3, 1) == "0")
                m = Int32.Parse(timeSpanString.Substring(4, 1));
            else
                m = Int32.Parse(timeSpanString.Substring(3, 2));

            if (timeSpanString.Substring(6, 1) == "0")
                s = Int32.Parse(timeSpanString.Substring(7, 1));
            else
                s = Int32.Parse(timeSpanString.Substring(6, 2));

            timer.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogTimeStamps(DateTime.Now, "Computer shut down or program terminated at");
        }
    }
}
