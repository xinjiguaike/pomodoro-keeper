using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.ApplicationSettings;
using PomodoroKeeper.PomodoroViews;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PomodoroKeeper.ControlsSample
{
	public sealed partial class PreferencePane : UserControl
	{
		private Popup pop = null;
		public PreferencePane()
		{
			this.InitializeComponent();

			this.Width = 360d;
			this.Height = Window.Current.Bounds.Height;//same high with the current window.  
			this.pop = new Popup();
			this.pop.Child = this;
			this.pop.IsLightDismissEnabled = true;

			// Localize the popup to the right of the window 
			pop.HorizontalOffset = Window.Current.Bounds.Width - this.Width;
			pop.VerticalOffset = 0d;

			// Present the animation 
			this.Transitions = new TransitionCollection();
			EdgeUIThemeTransition et = new EdgeUIThemeTransition();
			et.Edge = EdgeTransitionLocation.Right;
			this.Transitions.Add(et);

			this.DataContext = (Application.Current as App).LocalPomSettings;
		}

		/// <summary>  
		/// Show the control  
		/// </summary>  
		public void Show()
		{
			if (pop != null)
			{
				pop.IsOpen = true;
			}
		}

		/// <summary>  
		/// Hide the control  
		/// </summary>  
		public void Hide()
		{
			if (pop != null)
			{
				pop.IsOpen = false;
			}
		}

		private void OnBack(object sender, RoutedEventArgs e)
		{
			this.Hide();
			SettingsPane.Show();
		}

		//private void OnLanguageChanged(object sender, SelectionChangedEventArgs e)
		//{
		//	//(Application.Current as App).ResContext.QualifierValues["Language"] = (Application.Current as App).LocalPomSettings.GetLanguageCode();
		//	//(Application.Current as App).ResContext.Languages = new List<string>(new string[] { (Application.Current as App).LocalSettings.GetLanguageCode() });
			
		//	//TimerPage.pomTimer.SetPomContent((Application.Current as App).ResLoader);
		//}  
	}
}
