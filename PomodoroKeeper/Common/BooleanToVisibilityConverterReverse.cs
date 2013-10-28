using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace PomodoroKeeper.Common
{
    public sealed class BooleanToVisibilityConverterReverse : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool bModel = (bool)value;
            return bModel ? Visibility.Collapsed : Visibility.Visible;
        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
