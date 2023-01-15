namespace Caesar
{
    public partial class Form1 : Form
    {
        /*
         * Will add Display-Only option later on
         * 
         */

        public Form1()
        {
            InitializeComponent();
            shiftCounter.Value = 3;
        }

        OpenFileDialog ofd = new();
        SaveFileDialog sfd = new();

        private void RunButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                    MessageBox.Show(
                    "Please Select A File To Encrypt/Decrypt",
                    "No Source File",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!checkBox1.Checked) Caesar.RunE(textBox1.Text, textBox2.Text, shiftCounter.Value);
            else Caesar.RunD(textBox1.Text, textBox2.Text, shiftCounter.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ofd.Reset();
            ofd.Title = "Choose File To Encrypt/Decrypt";
            ofd.ShowDialog();
            String FileName = ofd.FileName;
            textBox1.Text = FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sfd.Reset();
            sfd.Title = "Output File Name";
            sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.ShowDialog();
            String FileName = sfd.FileName;
            textBox2.Text = FileName;
        }
    }
}