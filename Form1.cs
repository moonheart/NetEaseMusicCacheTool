using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib.Id3v2;

namespace NetEaseMusicCacheTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var re = dialog.ShowDialog();
            if (re == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text.Trim()))
            {
                new Thread(() =>
                {
                    var reader = new Music163Reader(textBox1.Text.Trim());
                    reader.ReadLogEvent += Reader_ReadLogEvent;
                    reader.Start();
                })
                { IsBackground = true }.Start();
            }
        }

        private void Reader_ReadLogEvent(Music163Reader.ReadLogEventArgs e)
        {
            if (textBox2.IsDisposed)
                return;
            if (textBox2.InvokeRequired)
            {
                textBox2.Invoke(new MethodInvoker(() =>
                {
                    textBox2.AppendText($"{e.Artist} - {e.Title} - {e.Album}\r\n");
                }));
            }
            else
            {
                textBox2.AppendText($"{e.Artist} - {e.Title} - {e.Album}\r\n");
            }
        }
    }
}
