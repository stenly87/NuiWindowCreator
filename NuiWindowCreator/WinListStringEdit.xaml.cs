using NuiWindowCreator.NuiProperties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NuiWindowCreator
{
    /// <summary>
    /// Логика взаимодействия для WinListStringEdit.xaml
    /// </summary>
    public partial class WinListStringEdit : Window, INotifyPropertyChanged
    {
        private StringEntry selectedValue;

        public ObservableCollection<StringEntry> Values { get; set; }
        public StringEntry SelectedValue
        {
            get => selectedValue;
            set
            {
                selectedValue = value;
                SignalChanged();
            }
        }
        public WinListStringEdit(ObservableCollection<StringEntry> values)
        {
            InitializeComponent();
            DataContext = this;
            Values = new ObservableCollection<StringEntry>( values);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void SignalChanged([CallerMemberName] string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        private void DeleteSelectedRow(object sender, RoutedEventArgs e)
        {
            Values.Remove(SelectedValue);
            SelectedValue = null;
        }

        private void SaveAndClose(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void AddNewRow(object sender, RoutedEventArgs e)
        {
            StringEntry newRow = new StringEntry { Value = "new row" };
            Values.Add(newRow);
            SelectedValue = newRow;
        }

        private void AddFromClipboard(object sender, RoutedEventArgs e)
        {
            var chars = new char[] { '\r', '\n'};
            var rows = Clipboard.GetText().Split(chars, StringSplitOptions.RemoveEmptyEntries);
            foreach (var row in rows)
                Values.Add(new StringEntry { Value = row });
        }

        private void DeleteAllRow(object sender, RoutedEventArgs e)
        {
            Values.Clear();
        }
    }
}
