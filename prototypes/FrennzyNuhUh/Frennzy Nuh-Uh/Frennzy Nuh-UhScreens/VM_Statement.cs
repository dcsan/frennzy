using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Frennzy_Nuh_UhScreens
{
    public class VM_Statement : INotifyPropertyChanged
    {
        public VM_Statement() { }

        public VM_Statement(bool isTrue, string text, string url)
        {
            Text = text;
            URL = url;
            IsTrue = isTrue;
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    PropertyChanged.Notify(() => Text);
                }
            }
        }

        private string _url;
        public string URL
        {
            get { return _url; }
            set
            {
                if (_url != value)
                {
                    _url = value;
                    PropertyChanged.Notify(() => URL);
                }
            }
        }

        private bool _isTrue;
        public bool IsTrue
        {
            get { return _isTrue; }
            set
            {
                if (_isTrue != value)
                {
                    _isTrue = value;
                    PropertyChanged.Notify(() => IsTrue);
                }
            }
        }

        private int _choiceNumber;
        public int ChoiceNumber
        {
            get { return _choiceNumber; }
            set
            {
                if (_choiceNumber != value)
                {
                    _choiceNumber = value;
                    PropertyChanged.Notify(() => ChoiceNumber);
                }
            }
        }
        

        public override string ToString()
        {
            return IsTrue.ToString() + " - " + Text + " (" + base.ToString() + ")";
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
