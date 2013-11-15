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
		private int _pomNumBeforeLongBreak;
		private bool _isTickOn;
		private int _tickVolume;
		private int _languageIndex;

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
		public int PomNumBeforeLongBreak
		{
			get { return _pomNumBeforeLongBreak; }
			set
			{
				_pomNumBeforeLongBreak = value;
				OnPropertyChanged("PomNumBeforeLongBreak");
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
		public int LanguageIndex
		{
			get { return _languageIndex; }
			set
			{
				_languageIndex = value;
				OnPropertyChanged("LanguageIndex");
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
			PomNumBeforeLongBreak = 4;
			IsTickOn = true;
			TickVolume = 50;
			LanguageIndex = 0;
		}

		public string GetLanguageCode()
		{
			if (LanguageIndex == 0)
				return "en";
			else if (LanguageIndex == 1)
				return "zh-CN";
			else if (LanguageIndex == 2)
				return "zh-TW";

			return "en";
		}
	}
}
