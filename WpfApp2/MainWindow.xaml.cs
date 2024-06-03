using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace WpfApp2;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ButtonOpenOnClick(object sender, RoutedEventArgs e)
    {
        var fileDialog = new OpenFileDialog
        {
            DefaultExt = ".txt",
            Filter = "Текстовые документы (.txt) | *.txt"
        };

        fileDialog.ShowDialog();

        if (!File.Exists(fileDialog.FileName))
        {
            MessageBox.Show("Файл не выбран");
            return;
        }
        
        var text = File.ReadAllText(fileDialog.FileName);

        if (string.IsNullOrEmpty(text))
        {
            MessageBox.Show("Файл пуст");
            return;
        }

        TextBoxInput.Text = File.ReadAllText(fileDialog.FileName);
    }

    private void ButtonSaveOnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(TextBoxInput.Text))
        {
            MessageBox.Show("Нельзя сохранить пустой файл");
            return;
        }
        
        var fileDialog = new SaveFileDialog
        {
            DefaultExt = ".txt",
            Filter = "Текстовые документы (.txt) | *.txt"
        };
        
        if (!(bool)fileDialog.ShowDialog()!)
        {
            return;
        }
        
        File.WriteAllText(fileDialog.FileName, TextBoxInput.Text);
    }
}