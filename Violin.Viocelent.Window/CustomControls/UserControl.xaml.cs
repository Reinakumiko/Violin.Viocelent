using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Violin.Viocelent.Window.EventParams;

namespace Violin.Viocelent.Window.CustomControls
{
	/// <summary>
	/// 用户控制面板
	/// </summary>
	public partial class UserControls : UserControl
	{
		/// <summary>
		/// 控件按钮被点击时触发的委托
		/// </summary>
		/// <param name="control"></param>
		/// <param name="args"></param>
		public delegate void OnControlButtonClicked(Control control, ControlButtonArgs args);
		public event OnControlButtonClicked OnClickPrevEventHandle;
		public event OnControlButtonClicked OnClickNextEventHandle;
		public event OnControlButtonClicked OnClickPlayEventHandle;

		public delegate void OnSliderClicked(Control control, SliderChangeArgs args);
		public event OnSliderClicked OnSliderClickEventHandle;


		public bool IsInPause { get; set; }

		public UserControls()
		{
			InitializeComponent();

			_next.Click += (obj, args) =>
			{
				OnClickNextEventHandle?.Invoke(_next, null);
			};

			_prev.Click += (obj, args) =>
			{
				OnClickPrevEventHandle?.Invoke(_prev, null);
			};

			_play.Click += (obj, args) =>
			{
				OnClickPlayEventHandle?.Invoke(_play, null);
			};

			_playProgress.ValueChanged += (obj, args) =>
			{
				OnSliderClickEventHandle?.Invoke(_playProgress, null);
			};
		}
	}
}
