using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace secondLab
{
    public partial class MainWindow : Form
    {
        private string pathOpen = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            MaximizeBox = false;
            saveFileDialog.Filter = @"Text files(*.txt)|*.txt"; // фильтр файлов при сохранении 
            comboBoxCipher.SelectedIndex = 0;
            comboBoxMode.SelectedIndex = 0;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxInput.Text))
            {
                if (comboBoxCipher.Text == @"Атбаш" && comboBoxMode.Text == @"Зашифровать")
                {
                    var process = new Atbash();
                    var result = process.Encode(textBoxInput.Text);
                    textBoxResult.Text = result;
                }

                if (comboBoxCipher.Text == @"Атбаш" && comboBoxMode.Text == @"Расшифровать")
                {
                    var process = new Atbash();
                    var result = process.Decode(textBoxInput.Text);
                    textBoxResult.Text = result;
                }

                if (comboBoxCipher.Text == @"ROT13" && comboBoxMode.Text == @"Зашифровать")
                {
                    var process = new Rot13();
                    var result = process.Encode(textBoxInput.Text);
                    textBoxResult.Text = result;
                }

                if (comboBoxCipher.Text == @"ROT13" && comboBoxMode.Text == @"Расшифровать")
                {
                    var process = new Rot13();
                    var result = process.Decode(textBoxInput.Text);
                    textBoxResult.Text = result;
                }
            }
            else if(string.IsNullOrEmpty(pathOpen))
            {
                MessageBox.Show(@"Вы ввели пустую строку. Попробуйте еще раз.",
                    @"Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            if (!string.IsNullOrEmpty(textBoxInput.Text)) 
            {
                SaveInputToolStripMenuItem.Enabled = true;  
            }

            if (!string.IsNullOrEmpty(textBoxResult.Text)) 
            {
                SaveResToolStripMenuItem.Enabled = true;
            }
        }

        private void InputFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                pathOpen = string.Empty;
                return; // обработка закрытия окна выбора файла
            }
            pathOpen = openFileDialog.FileName;
            var text = File.ReadAllText(pathOpen);
            textBoxInput.Text = text;
            pathOpen = string.Empty;
        }

        private void SaveInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saving = new SaveData();
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return; // обработка закрытия окна сохранения введенных данных
            var filenameSaveEnteredData = saveFileDialog.FileName;// получение имени файла 
            saving.SaveEnteredData(filenameSaveEnteredData, textBoxInput.Text);
        }

        private void SaveResToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saving = new SaveData(); // создание объекта класса SaveData
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return; // обработка закрытия окна сохранения результатов
            var filenameSaveRes = saveFileDialog.FileName; // получение имени файла 
            saving.SaveResults(filenameSaveRes, textBoxInput.Text, textBoxResult.Text); // сохранение результатов
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var infoWindow = new About();
            if (!Application.OpenForms.OfType<About>().Any())
            {
                infoWindow.Show();
                infoWindow.Focus();
            }
        }
    }
}
