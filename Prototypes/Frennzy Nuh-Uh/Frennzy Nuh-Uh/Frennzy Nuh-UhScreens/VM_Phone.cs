using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Frennzy_Nuh_UhScreens
{
    public class VM_Phone : INotifyPropertyChanged
    {
        public VM_Phone(VM_Player host)
        {
            Owner = host;
        }

        private VM_Player _owner;
        public VM_Player Owner
        {
            get { return _owner; }
            set
            {
                if (_owner != value)
                {
                    _owner = value;
                    PropertyChanged.Notify(() => Owner);
                }
            }
        }

        private ObservableCollection<VM_Player> _players = new ObservableCollection<VM_Player>();
        public ObservableCollection<VM_Player> Players
        {
            get { return _players; }
            set
            {
                if (_players != value)
                {
                    _players = value;
                    PropertyChanged.Notify(() => Players);
                }
            }
        }        

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
