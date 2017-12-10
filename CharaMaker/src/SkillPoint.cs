using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharaMaker
{
	class SkillPoint : NotifyChangedValue
	{
		string name;
		int basePoint, addPoint, usePoint, restPoint;

		public SkillPoint(string _name)
		{
			name = _name;
			basePoint = addPoint = usePoint = restPoint = 0;
		}

		public string Name
		{
			get { return name; }
		}

		public int BasePoint
		{
			get { return basePoint; }
			set { basePoint = value; updateRestValue(); NotifyChanged("BasePoint"); }
		}

		public int AddPoint
		{
			get { return addPoint; }
			set { addPoint = value; updateRestValue(); NotifyChanged("AddPoint"); }
		}

		public int UsePoint
		{
			get { return usePoint; }
			set { usePoint = value; updateRestValue(); NotifyChanged("UsePoint"); }
		}

		public int RestPoint
		{
			get { return restPoint; }
			set { restPoint = value; NotifyChanged("RestPoint"); }
		}

		private void updateRestValue()
		{
			RestPoint = BasePoint + AddPoint - UsePoint;
		}
	}
}
