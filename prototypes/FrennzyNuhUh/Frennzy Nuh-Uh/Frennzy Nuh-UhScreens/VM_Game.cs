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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Frennzy_Nuh_UhScreens
{
    public class VM_Game : INotifyPropertyChanged
    {
        public VM_Game(List<VM_Statement> statementDB, Random r)
        {
            _r = r;
            _statementDB = statementDB;
            PlayGame();
        }

        private int _numberOfRounds = 0;
        public int NumberOfRounds
        {
            get { return _numberOfRounds; }
            set
            {
                if (_numberOfRounds != value)
                {
                    _numberOfRounds = value;
                    PropertyChanged.Notify(() => NumberOfRounds);
                }
            }
        }

        private ObservableCollection<VM_Round> _rounds = new ObservableCollection<VM_Round>();
        public ObservableCollection<VM_Round> Rounds
        {
            get { return _rounds; }
            set
            {
                if (_rounds != value)
                {
                    _rounds = value;
                    PropertyChanged.Notify(() => Rounds);
                }
            }
        }

        public int CurrentRoundNum { get { return Rounds.Count; } }

        public VM_Round CurrentRound
        {
            get
            {
                if (Rounds.Count > 0)
                    return Rounds[Rounds.Count - 1];

                return null;
            }
        }

        private Random _r;
        private void PlayGame()
        {
            Rounds.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Rounds_CollectionChanged);

            if (VM.StaticVM.Players.Count >= 5)
                NumberOfRounds = VM.StaticVM.Players.Count;
            else
                NumberOfRounds = VM.StaticVM.Players.Count * 2;

            NextRound();
        }

        private void Rounds_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            PropertyChanged.Notify(() => CurrentRoundNum);
            PropertyChanged.Notify(() => CurrentRound);
        }

        public void NextRound()
        {
            if (CurrentRoundNum < NumberOfRounds)
            {
                VM_Player nextSpeaker = GetNextSpeaker();
                VM_Round newRound = new VM_Round(nextSpeaker, ChooseSpeakerOptions());

                Rounds.Add(newRound);
                newRound.GoTo_SpeakerChooses();
            }
            else
                GoTo_FinalResults();
        }

        private void GoTo_FinalResults()
        {
            foreach (VM_Player player in VM.StaticVM.Players)
                player.State = GameStates.FinalResults;
        }


        private int _lastSpeaker = -1;
        private VM_Player GetNextSpeaker()
        {
            _lastSpeaker++;

            if (_lastSpeaker >= VM.StaticVM.Players.Count)
                _lastSpeaker = 0;

            return VM.StaticVM.Players[_lastSpeaker];
        }

        private ObservableCollection<VM_Statement> ChooseSpeakerOptions()
        {
            ObservableCollection<VM_Statement> speakerOptions = new ObservableCollection<VM_Statement>();
            int falseSpot = _r.Next(3);

            if (falseSpot == 0)
                speakerOptions.Add(GetRandomFalse(_r));
            else
                speakerOptions.Add(GetRandomTrue(_r));

            if (falseSpot == 1)
                speakerOptions.Add(GetRandomFalse(_r));
            else
                speakerOptions.Add(GetRandomTrue(_r));

            if (falseSpot == 2)
                speakerOptions.Add(GetRandomFalse(_r));
            else
                speakerOptions.Add(GetRandomTrue(_r));

            for (int i = 0; i < speakerOptions.Count; i++)
                speakerOptions[i].ChoiceNumber = i + 1;

            return speakerOptions;
        }

        private List<VM_Statement> _statementDB;

        private List<VM_Statement> _trueStatements
        {
            get
            {
                List<VM_Statement> trueStatements = new List<VM_Statement>();

                foreach (VM_Statement statement in _statementDB)
                    if (statement.IsTrue && !_usedTrueStatements.Contains(statement))
                        trueStatements.Add(statement);

                if (trueStatements.Count < 2)
                {
                    _usedTrueStatements.Clear();
                    return _trueStatements;
                }

                return trueStatements;
            }
        }
        private List<VM_Statement> _usedTrueStatements = new List<VM_Statement>();
        private VM_Statement GetRandomTrue(Random r)
        {
            VM_Statement s = _trueStatements[r.Next(_trueStatements.Count)];
            _usedTrueStatements.Add(s);
            return s;
        }

        private List<VM_Statement> _falseStatements
        {
            get
            {
                List<VM_Statement> falseStatements = new List<VM_Statement>();
                foreach (VM_Statement statement in _statementDB)
                    if (!statement.IsTrue && !_usedFalseStatements.Contains(statement))
                        falseStatements.Add(statement);

                if (falseStatements.Count < 1)
                {
                    _usedFalseStatements.Clear();
                    return _falseStatements;
                }

                return falseStatements;
            }
        }
        private List<VM_Statement> _usedFalseStatements = new List<VM_Statement>();
        private VM_Statement GetRandomFalse(Random r)
        {
            VM_Statement s = _falseStatements[r.Next(_falseStatements.Count)];
            _usedFalseStatements.Add(s);
            return s;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
