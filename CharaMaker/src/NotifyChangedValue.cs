using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharaMaker
{
	public class NotifyChangedValue : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void NotifyChanged(String info)
		{
			var e = new PropertyChangedEventArgs(info);
			if (PropertyChanged != null) PropertyChanged(this, e);
		}
	}
}
