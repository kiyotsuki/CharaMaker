using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharaMaker
{
	class HoldingSkill : NotifyChangedValue
	{
		string name, type;
		int basePoint, jobPoint, hobbyPoint, addPoint, sumPoint;
		SkillData source;
		
		public HoldingSkill(SkillData _source, PropertyChangedEventHandler _handler)
		{
			source = _source;
			name = source.name;
			type = source.category;
			basePoint = sumPoint = source.point;
			jobPoint = hobbyPoint = 0;
			if (_handler != null) PropertyChanged += _handler;
		}
		
		public SkillData Source
		{
			get { return source; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; NotifyChanged("Name"); }
		}

		public string Type
		{
			get { return type; }
			set { type = value; NotifyChanged("Type"); }
		}

		public int BasePoint
		{
			get { return basePoint; }
			set { basePoint = value; updateSumPoint(); NotifyChanged("BasePoint"); }
		}

		public int JobPoint
		{
			get { return jobPoint; }
			set { jobPoint = value; updateSumPoint(); NotifyChanged("JobPoint"); }
		}

		public int HobbyPoint
		{
			get { return hobbyPoint; }
			set { hobbyPoint = value; updateSumPoint(); NotifyChanged("HobbyPoint"); }
		}

		public int AddPoint
		{
			get { return addPoint; }
			set { addPoint = value; updateSumPoint(); NotifyChanged("AddPoint"); }
		}

		public int SumPoint
		{
			get { return sumPoint; }
			set { sumPoint = value; NotifyChanged("SumPoint"); }
		}

		private void updateSumPoint()
		{
			SumPoint = BasePoint + JobPoint + HobbyPoint + AddPoint;
		}
	}
}
