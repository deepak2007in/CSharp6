using System.ComponentModel;

namespace CSharp6
{
    public class EvilPlanViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private string evilGenius;
        public string OwningEvilGenius
        {
            get
            {
                return evilGenius;
            }
            set
            {
                if(value != evilGenius)
                {
                    evilGenius = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OwningEvilGenius)));
                }
            }
        }
    }
}