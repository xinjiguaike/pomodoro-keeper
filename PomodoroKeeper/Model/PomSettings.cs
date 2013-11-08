using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroKeeper.Model
{
    public class PomSettings : INotifyPropertyChanged
    {
        private int _pomIndex;
        private int _breakIndex;
        private int _longBreakIndex;
        private int _pomNumBeforeBreak;
        private bool _isTickOn;
        private int _tickVolume;

        public int PomIndex
        {
            get { return _pomIndex; }
            set 
            {
                _pomIndex = value;
                OnPropertyChanged("PomIndex");
            }
        }
        public int BreakIndex
        {
            get { return _breakIndex; }
            set
            {
                _breakIndex = value;
                OnPropertyChanged("BreakIndex");
            }
        }

        public int LongBreakIndex
        {
            get { return _longBreakIndex; }
            set
            {
                _longBreakIndex = value;
                OnPropertyChanged("LongBreakIndex");
            }
        }
        public int PomNumBeforeBreak
        {
            get { return _pomNumBeforeBreak; }
            set
            {
                _pomNumBeforeBreak = value;
                OnPropertyChanged("PomNumBeforeBreak");
            }
        }
        public bool IsTickOn
        {
            get { return _isTickOn; }
            set
            {
                _isTickOn = value;
                OnPropertyChanged("IsTickOn");
            }
        }
        public int TickVolume
        {
            get { return _tickVolume; }
            set
            {
                _tickVolume = value;
                OnPropertyChanged("TickVolume");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public PomSettings()
        {
            PomIndex = 1;
            BreakIndex = 0;
            LongBreakIndex = 1;
            PomNumBeforeBreak = 4;
            IsTickOn = true;
            TickVolume = 50;
        }
    }
}
