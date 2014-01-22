using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PomodoroKeeper.Common
{
	public class IntToIntx20Converter: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is int)
				return (int)value * 20;
			else
				return 0;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
