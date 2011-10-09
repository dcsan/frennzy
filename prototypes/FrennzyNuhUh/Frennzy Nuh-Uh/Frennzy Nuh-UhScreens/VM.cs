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
    public class VM : INotifyPropertyChanged
    {
        static public VM StaticVM = new VM();



        public VM()
        {
            VM_Player host = new VM_Player("HostBoy", GameStates.Initial, this, true);
            Phones.Add(new VM_Phone(host));
            Players.Add(host);

            Games.CollectionChanged += new NotifyCollectionChangedEventHandler(Games_CollectionChanged);

            VM_Player hiro = new VM_Player("Hiro", GameStates.AddPlayers, this);
            Phones.Add(new VM_Phone(hiro));
            Players.Add(hiro);

            //Players.Add(new VM_Player("n00b"));

            StatementDB.Add(new VM_Statement(true, "The Nobel Peace Prize medal depicts 3 naked men with their hands on each others shoulders.", "http://www.weirdfacts.com/facts/3118-nobel-prize.html"));
            StatementDB.Add(new VM_Statement(true, "Fortune cookies were actually invented in America.", "http://www.weirdfacts.com/facts/3119-fortune-cookies.html"));
            StatementDB.Add(new VM_Statement(true, "The cigarette lighter was invented before the match.", "http://www.weirdfacts.com/facts/3126-matches-and-lighters.html"));
            StatementDB.Add(new VM_Statement(true, "The chances of you dying on the way to get your lottery tickets is greater than your chances of winning.", ""));
            StatementDB.Add(new VM_Statement(true, "The longest recorded sneezing fit lasted 978 days.", "http://www.weirdfacts.com/facts/3253-sneeze-facts.html"));
            StatementDB.Add(new VM_Statement(true, "Dr. Ruth was trained as a sniper.", "http://en.wikipedia.org/wiki/Ruth_Westheimer"));
            StatementDB.Add(new VM_Statement(true, "Hot water freezes faster than cold water.", "http://en.wikipedia.org/wiki/Mpemba_effect"));
            StatementDB.Add(new VM_Statement(true, "The mortal remains of Charlie Chaplin were stolen and held for randsom.", "http://www.snopes.com/movies/actors/chaplin1.asp"));
            StatementDB.Add(new VM_Statement(true, "Japanese robbers sent a 'thank you' note to the bank after robbing it.", "http://www.snopes.com/crime/clever/thanks.asp"));
            StatementDB.Add(new VM_Statement(true, "Three streakers had their car stolen while running nude through a restaurant.", "http://www.snopes.com/crime/deserts/streaker.asp"));
            StatementDB.Add(new VM_Statement(true, "Mr. Ed was actually a zebra.", "http://www.snopes.com/lost/mistered.asp"));
            StatementDB.Add(new VM_Statement(true, "The California flag was supposed to have a pear, but due to a typo ended up with a 'bear'.", "http://www.snopes.com/lost/bearflag.asp"));
            StatementDB.Add(new VM_Statement(true, "The nursery rhyme \"Sing a Song of Sixpence\" was originally for secretly recruiting pirates.", "http://www.snopes.com/lost/sixpence.asp"));
            StatementDB.Add(new VM_Statement(true, "An insect-infested house was blown apart after the owner set off too many bug bombs.", "http://www.snopes.com/humor/follies/bugbomb.asp"));
            StatementDB.Add(new VM_Statement(true, "The Swedish Navy once mistook minks for enemy submarines.", "http://www.snopes.com/critters/gnus/slink.asp"));
            StatementDB.Add(new VM_Statement(true, "Snakes have been used as weapons in a hold-up.", "http://www.snopes.com/critters/gnus/snakerob.asp"));
            StatementDB.Add(new VM_Statement(true, "A number of unusual deaths have surrounded the cast of the Poltergeist films.", "http://www.snopes.com/movies/films/poltergeist.asp"));
            StatementDB.Add(new VM_Statement(true, "Kid finances college by soliciting one-cent donations.", "http://www.snopes.com/college/admin/cent.asp"));
            StatementDB.Add(new VM_Statement(true, "The temperature outside can be determined by counting the chirps a cricket makes.", "http://www.snopes.com/science/cricket.asp"));
            StatementDB.Add(new VM_Statement(true, "The middle name of Harry Truman is actually just the letter 'S'.", "http://www.snopes.com/history/american/truman.asp"));
            StatementDB.Add(new VM_Statement(false, "The phrase \"rule of thumb\" is derived from an old English law that stated that you couldn't beat your wife with anything wider than your thumb.", "http://www.weirdfacts.com/facts/3135-rule-of-thumb.html"));
            StatementDB.Add(new VM_Statement(false, "The name Jeep came from the abbreviation used in the army for the General Purpose\" vehicle or \"GP\".", "http://wwiijeepparts.com/Archives/WWIIJeepHistory.html"));
            StatementDB.Add(new VM_Statement(false, "The venomous 'two-striped telemonia spider lurks beneath toilet seats in public restrooms.", "http://www.snopes.com/horrors/insects/telamonia.asp"));
            StatementDB.Add(new VM_Statement(false, "Man insured cigars against fire, then tried to collect after smoking them.", "http://www.snopes.com/crime/clever/cigarson.asp"));
            StatementDB.Add(new VM_Statement(false, "Hair grows back darker and thicker after being shaved.", "http://www.snopes.com/oldwives/hairgrow.asp"));
            StatementDB.Add(new VM_Statement(false, "Chewing gum takes 7 years to be digested.", "http://www.snopes.com/oldwives/chewgum.asp"));
            StatementDB.Add(new VM_Statement(false, "Swimming less than an hour after eating can cause you to get cramps and drown.", "http://www.snopes.com/oldwives/hourwait.asp"));
            StatementDB.Add(new VM_Statement(false, "The Titanic was the first ship to send the 'SOS' distress call.", "http://www.snopes.com/history/titanic/sos.asp"));
            StatementDB.Add(new VM_Statement(false, "There is a sanctuary for dogs named 'Dog Island' off the coast of Florida.", "http://www.snopes.com/critters/crusader/dogisland.asp"));
            StatementDB.Add(new VM_Statement(false, "Coating the edges of an audio CD with a green marker notably improves the sound.", "http://www.snopes.com/music/media/marker.asp"));

            Players.CollectionChanged += new NotifyCollectionChangedEventHandler(Players_CollectionChanged);
        }

        void Games_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            PropertyChanged.Notify(() => CurrentGame);
        }

        void Players_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            PropertyChanged.Notify(() => PlayersReady);
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
                    PropertyChanged.Notify(() => PlayersReady);
                }
            }
        }

        private ObservableCollection<VM_Phone> _phones = new ObservableCollection<VM_Phone>();
        public ObservableCollection<VM_Phone> Phones
        {
            get { return _phones; }
            set
            {
                if (_phones != value)
                {
                    _phones = value;
                    PropertyChanged.Notify(() => Phones);
                    PropertyChanged.Notify(() => PlayersReady);
                }
            }
        }

        private List<VM_Statement> _statementDB = new List<VM_Statement>();
        public List<VM_Statement> StatementDB
        {
            get { return _statementDB; }
            set
            {
                if (_statementDB != value)
                {
                    _statementDB = value;
                    PropertyChanged.Notify(() => StatementDB);
                }
            }
        }

        public VM_Game CurrentGame
        {
            get
            {
                if (Games.Count > 0)
                    return Games[Games.Count - 1];

                return null;
            }
        }
        
        private ObservableCollection<VM_Game> _games = new ObservableCollection<VM_Game>();
        public ObservableCollection<VM_Game> Games
        {
            get { return _games; }
            set
            {
                if (_games != value)
                {
                    _games = value;
                    PropertyChanged.Notify(() => Games);
                }
            }
        }
        

        public bool PlayersReady
        {
            get
            {
                if (Players.Count < 2)
                    return false;

                bool ready = true;

                foreach (VM_Player player in Players)
                    if (!player.IsReady)
                        ready = false;

                return ready;
            }
        }

        public void StartGame()
        {
            Games.Add(new VM_Game(StatementDB, _r));
            PropertyChanged.Notify(() => CurrentGame);
            foreach (VM_Player player in Players)
                player.SpeakerChanged();
        }

        public void CheckPlayersReady()
        {
            PropertyChanged.Notify(() => PlayersReady);
        }

        public VM_Player Host
        {
            get
            {
                foreach (VM_Player player in Players)
                    if (player.IsHost)
                        return player;

                return null;
            }
        }

        private Random _r = new Random();

        public void AddPlayer()
        {
            if (Players.Count < 8)
                Players.Add(new VM_Player("Player " + (Players.Count + 1).ToString(), GameStates.JoinGame, VM.StaticVM));
        }

        public void RemovePlayer(VM_Player player)
        {
            RemovePhone(player);
            Players.Remove(player);
        }

        private void RemovePhone(VM_Player player)
        {
            VM_Phone playersPhone = GetPlayerPhone(player);

            if (playersPhone != null)
                Phones.Remove(playersPhone);
        }

        private VM_Phone GetPlayerPhone(VM_Player player)
        {
            foreach (VM_Phone phone in Phones)
                if (phone.Owner == player)
                    return phone;

            return null;
        }

        public void AddPhone(VM_Player player)
        {
            Phones.Add(new VM_Phone(player));
        }

        public void GoTo_AddPhone(VM_Player player)
        {
            NewPhone = new VM_Phone(player);
            Host.State = GameStates.AddPhone;
        }

        private VM_Phone _newPhone = new VM_Phone(new VM_Player("New Phone Guy", GameStates.AddPlayers, null));
        public VM_Phone NewPhone
        {
            get { return _newPhone; }
            set
            {
                if (_newPhone != value)
                {
                    _newPhone = value;
                    PropertyChanged.Notify(() => NewPhone);
                }
            }
        }

        public void AddNewPhone()
        {
            Phones.Add(NewPhone);
            Host.State = GameStates.AddPlayers;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
