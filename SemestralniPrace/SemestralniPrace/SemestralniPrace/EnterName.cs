using System;
using System.IO;
using System.Windows.Forms;

namespace SemestralniPrace
{
    public partial class EnterName : Form
    {
        public EnterName(int score)
        {
            InitializeComponent();
            label1.Text = score.ToString();
            CenterAll();
        }

        private void CenterAll()
        {
            label1.Left = Width / 2 - label1.Width / 2 - 8;
            textBox1.Left = Width / 2 - textBox1.Width / 2 - 8;
            button1.Left = Width / 2 - button1.Width / 2 - 8;
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (String.IsNullOrEmpty(label1.Text) || name == ""){
                name = "EMPTY";
            }
            int score = int.Parse(label1.Text);
            using StreamWriter file = new(@"files/score.txt", append: true);
            await file.WriteLineAsync($"{name};{score}");
            Close();
        }
    }
}
