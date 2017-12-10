using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharaMaker
{
	public class JobData
	{
		public string name, desc, effect;
		public string[] status;
		public SkillSet[] skillSets;

		public JobData(string _name, string _desc, string _effect, string _stateA, string _stateB, params SkillSet[] _skillSets)
		{
			name = _name;
			desc = _desc;
			effect = _effect;
			status = _stateB == null ? new string[] { _stateA } : new string[] { _stateA, _stateB };
			skillSets = _skillSets;
		}
		public JobData(string _name, string _desc, string _effect, string _state, params SkillSet[] _skillSets) : this(_name, _desc, _effect, _state, null, _skillSets) { }

		public string Name
		{
			get { return name; }
		}

		public string Text
		{
			get
			{
				string text = desc + "\n\n▽" + effect + "\n\n";
				foreach (var state in status)
				{
					if (state != status[0]) text += " / ";
					if (state == "EDU") text += "EDU*20";
					else text += "EDU*10+" + state + "*10";
				}

				text += "\n\n≪職業技能≫\n";
				foreach (var skillSet in skillSets)
				{
					if (skillSet.num != 0) text += "\n次の技能から" + skillSet.num + "つ選択\n";
					foreach (var skill in skillSet.skills)
					{
						text += "・" + skill + "\n";
					}
				}
				return text;
			}
		}
	}

	public class SkillSet
	{
		public int num;
		public string[] skills;

		public SkillSet(params string[] _skills)
		{
			num = 0;
			skills = _skills;
		}

		public SkillSet(int _num, params string[] _skills)
		{
			num = _num;
			skills = _skills;
		}
	}
}
