using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NuiWindowCreator.NuiProperties
{
    public class NuiProperty : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public string Description { get; set; }

        public NuiProperty(string description)
        {
            Description = description;
        }
    }
}