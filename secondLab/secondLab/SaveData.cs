using System;
using System.IO;
using System.Windows.Forms;

namespace secondLab
{
    class SaveData
    {
        public void SaveEnteredData(string path, string text)
        {
            File.WriteAllText(path, string.Empty);
            File.AppendAllText(path, text);
            MessageBox.Show(@"Данные сохранены",
            @"Информация");
        }
        public void SaveResults(string path, string text, string result)
        {
            File.WriteAllText(path, string.Empty);
            File.AppendAllText(path, @"Вы ввели следующий текст: " + text + Environment.NewLine);
            File.AppendAllText(path,
                @"Результат шифрования/дешифрования " + result +
                Environment.NewLine);
            MessageBox.Show(@"Результаты сохранены",
                @"Информация");
        }
    }
}
