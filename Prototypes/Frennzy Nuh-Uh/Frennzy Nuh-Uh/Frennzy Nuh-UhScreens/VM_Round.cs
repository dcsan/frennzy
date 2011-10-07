using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Frennzy_Nuh_UhScreens
{
    public enum RoundStates
    {
        SpeakerChooses,
        SpeakerReads,
        ListenersVote,
        WaitForResults,
        Results
    }

    public class VM_Round : INotifyPropertyChanged
    {
        public VM_Round(VM_Player speaker, ObservableCollection<VM_Statement> options)
        {
            Speaker = speaker;
            Options = options;
        }

        private RoundStates _state = RoundStates.SpeakerChooses;
        public RoundStates State
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    PropertyChanged.Notify(() => State);
                }
            }
        }
        

        private VM_Player _speaker;
        public VM_Player Speaker
        {
            get { return _speaker; }
            set
            {
                if (_speaker != value)
                {
                    _speaker = value;
                    PropertyChanged.Notify(() => Speaker);
                }
            }
        }

        private ObservableCollection<VM_Statement> _options = new ObservableCollection<VM_Statement>();
        public ObservableCollection<VM_Statement> Options
        {
            get { return _options; }
            set
            {
                if (_options != value)
                {
                    _options = value;
                    PropertyChanged.Notify(() => Options);
                }
            }
        }

        private VM_Statement _choice;
        public VM_Statement Choice
        {
            get { return _choice; }
            set
            {
                if (_choice != value)
                {
                    _choice = value;
                    PropertyChanged.Notify(() => Choice);
                    PropertyChanged.Notify(() => ChoiceText);
                }
            }
        }

        public string ChoiceText
        {
            get
            {
                if (Choice != null)
                    return Choice.Text;
                else
                    return "Not yet defined.";
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
