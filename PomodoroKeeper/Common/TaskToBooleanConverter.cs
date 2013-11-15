using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PomodoroKeeper.Common
{
	class TaskToBooleanConverter: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (null != value)
				return true;
			else
				return false;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
