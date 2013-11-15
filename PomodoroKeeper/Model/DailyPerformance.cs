/***********************************************************************
 * Module:  DailyPerformance.cs
 * Author:  Rudy
 * Purpose: Definition of the Class DailyPerformance
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PomodoroKeeper.Model
{
	public class DailyPerformance
	{
		private int StartedPoms { get; set; }

		private int EstimatedPoms { get; set; }

		private int CompletedPoms { get; set; }

		private int AbandonedPoms { get; set; }

		private int InternalInterrupts { get; set; }

		private int ExternalInterrupts { get; set; }

		private DateTime Date { get; set; }

	}
}