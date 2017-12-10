using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharaMaker
{
	public class AvilityPoint : NotifyChangedValue
	{
		string name;
		int basePoint, addPoint, sumPoint;

		public AvilityPoint(string _name, PropertyChangedEventHandler _handler = null)
		{
			name = _name;
			basePoint = addPoint = sumPoint = 0;
			if (_handler != null) PropertyChanged += _handler;
		}

		public string Name
		{
			get { return name; }
		}

		public int BasePoint
		{
			get { return basePoint; }
			set { basePoint = value; updatePoint(); NotifyChanged("BasePoint"); }
		}

		public int AddPoint
		{
			get { return addPoint; }
			set { addPoint = value; updatePoint(); NotifyChanged("AddPoint"); }
		}

		public int SumPoint
		{
			get { return sumPoint; }
			set { sumPoint = value; NotifyChanged("SumPoint"); }
		}

		private void updatePoint()
		{
			SumPoint = BasePoint + AddPoint;
		}
	}
}
