using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Frennzy_Nuh_UhScreens
{
    public enum GameStates
    {
        Initial,
        AddPlayers,
        AddPhone,
        SpeakerChooses,
        SpeakerReads,
        ListenersVote,
        Results,
        WaitForResults
    }

    public class VM_Player : INotifyPropertyChanged
    {
        public VM_Player(string name, GameStates state, VM vm)
        {
            Name = name;
            State = state;

            if (vm != null)
            {
                _vm = vm;
                _vm.SubscribeToChange(() => _vm.Speaker, SpeakerChanged);
                _vm.SubscribeToChange(() => _vm.SpeakerChoice, SpeakerChoiceChanged);
                _vm.Phones.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Phones_CollectionChanged);
            }
        }

        public VM_Player(string name, GameStates state, VM vm, bool isHost)
            : this(name, state, vm)
        {
            IsHost = isHost;
        }

        private void SpeakerChanged(VM vm)
        {
            PropertyChanged.Notify(() => IsSpeaker);
            PropertyChanged.Notify(() => ResultLine);
        }

        private void SpeakerChoiceChanged(VM vm)
        {
            PropertyChanged.Notify(() => ResultLine);
        }

        private void Phones_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            PropertyChanged.Notify(() => HasPhone);
        }

        private string _name = "player name";
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    PropertyChanged.Notify(() => Name);
                    PropertyChanged.Notify(() => ResultLine);
                }
            }
        }

        private GameStates _state;
        public GameStates State
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

        private bool _isHost;
        public bool IsHost
        {
            get { return _isHost; }
            set
            {
                if (_isHost != value)
                {
                    _isHost = value;
                    PropertyChanged.Notify(() => IsHost);
                }
            }
        }

        public bool IsSpeaker { get { return VM.Speaker == this; } }
        
        public bool HasPhone 
        {
            get
            {
                foreach (VM_Phone phone in VM.Phones)
                    if (phone.Owner == this)
                        return true;

                return false;
            }
        }

        public Control Visual;

        private VM _vm;
        public VM VM { get { return _vm; } }

        public string ResultLine
        {
            get 
            {
                if (VM.StaticVM.Speaker == this)
                {
                    if (VM.StaticVM.SpeakerChoice.IsTrue)
                        return Name + " was honest!";
                    else
                        return Name + " flat out lied!";
                }
                else
                {
                    if (VM.StaticVM.SpeakerChoice.IsTrue == Vote)
                        return Name + " guessed right!";
                    else
                        return Name + " guessed wrong.";
                }
            }
        }

        private int _roundScore = 0;
        public int RoundScore
        {
            get { return _roundScore; }
            set
            {
                if (_roundScore != value)
                {
                    _roundScore = value;
                    PropertyChanged.Notify(() => RoundScore);
                    PropertyChanged.Notify(() => ResultLine);
                }
            }
        }
        
        private int _score = 0;
        public int Score
        {
            get { return _score; }
            set
            {
                if (_score != value)
                {
                    _score = value;
                    PropertyChanged.Notify(() => Score);
                    PropertyChanged.Notify(() => ResultLine);
                }
            }
        }

        private bool _vote;
        public bool Vote
        {
            get { return _vote; }
            set
            {
                if (_vote != value)
                {
                    _vote = value;
                    PropertyChanged.Notify(() => Vote);
                    PropertyChanged.Notify(() => ResultLine);
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
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Name + " (" +  base.ToString() + ")";
        }
    }
}
