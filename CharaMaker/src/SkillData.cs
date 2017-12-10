using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharaMaker
{
	class SkillData
	{
		public bool check;
		public string category, name, rule;
		public int point;

		public SkillData(string _category, string _name, int _point) : this(_category, _name, _point, true, null) { }
		public SkillData(string _category, string _name, int _point, bool _check) : this(_category, _name, _point, _check, null) { }
		public SkillData(string _category, string _name, string _rule) : this(_category, _name, 0, true, _rule) { }
		public SkillData(string _category, string _name, int _point, bool _check, string _rule)
		{
			category = _category;
			name = _name;
			point = _point;
			check = _check;
			rule = _rule;
		}

		public string Text
		{
			get
			{
				if (rule != null) return name + "(" + rule + ")";
				else return name + "(" + point + ")";
			}
		}
	}
}
