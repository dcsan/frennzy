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

        private List<VM_Player> _votedList = new List<VM_Player>();

        public void StartVoting()
        {
            foreach (VM_Player player in VM.StaticVM.Players)
                player.State = GameStates.ListenersVote;
        }

        public void EnterVote(VM_Player player, bool vote)
        {
            player.Vote = vote;
            player.State = GameStates.WaitForResults;
            _votedList.Add(player);
            EndRound();
        }

        public void EndRound()
        {
            if (_votedList.Count >= VM.StaticVM.Players.Count - 1)
            {
                foreach (VM_Player player in VM.StaticVM.Players)
                {
                    if (!player.IsSpeaker)
                    {
                        if (player.Vote == Choice.IsTrue)
                            player.Score++;
                        else if (Choice.IsTrue)
                            Speaker.Score++;
                        else
                            Speaker.Score += 2;
                    }

                    player.State = GameStates.Results;
                }
            }
        }


        public void GoTo_SpeakerChooses()
        {
            foreach (VM_Player player in VM.StaticVM.Players)
                player.State = GameStates.SpeakerChooses;
        }

        public void GoTo_SpeakerReads(VM_Statement choice)
        {
            Choice = choice;
            Speaker.State = GameStates.SpeakerReads;
            //foreach (VM_Player player in VM.StaticVM.Players)
            //    player.State = GameStates.SpeakerReads;
        }

        private void GoTo_ListenersVote()
        {
            foreach (VM_Player player in VM.StaticVM.Players)
                player.State = GameStates.ListenersVote;
        }

        private void GoTo_WaitForResults()
        {
            foreach (VM_Player player in VM.StaticVM.Players)
                player.State = GameStates.WaitForResults;
        }

        private void GoTo_Results()
        {
            foreach (VM_Player player in VM.StaticVM.Players)
                player.State = GameStates.Results;
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
