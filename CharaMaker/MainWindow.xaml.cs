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
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace CharaMaker
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		static SkillData[] SKILL_DATAS = new SkillData[]{
			new SkillData("戦闘", "回避", "DEX*5"),
			new SkillData("戦闘", "応急手当", 25),
			new SkillData("戦闘", "キック", 25),
			new SkillData("戦闘", "パンチ", 50),
			new SkillData("戦闘", "頭突き", 10),
			new SkillData("戦闘", "組みつき", 25),
			new SkillData("戦闘", "投擲", 25),
			new SkillData("戦闘", "フェンシング", 20),
			new SkillData("戦闘", "サーベル", 15),
			new SkillData("戦闘", "ナイフ", 25),
			new SkillData("戦闘", "日本刀", 15),
			new SkillData("戦闘", "青竜刀", 10),
			new SkillData("戦闘", "薙刀", 10),
			new SkillData("戦闘", "杖", 25),
			new SkillData("戦闘", "鎖鎌", 5),
			new SkillData("戦闘", "弓", 10),
			new SkillData("戦闘", "火縄銃", 15),
			new SkillData("戦闘", "拳銃", 20),
			new SkillData("戦闘", "サブマシンガン", 15),
			new SkillData("戦闘", "ショットガン", 30),
			new SkillData("戦闘", "マシンガン", 15),
			new SkillData("戦闘", "ライフル", 25),
			new SkillData("戦闘", "砲", 1),
			new SkillData("戦闘", "グレネード・ランチャー", 25),

			new SkillData("探索", "鍵開け", 1),
			new SkillData("探索", "隠す", 15),
			new SkillData("探索", "隠れる", 10),
			new SkillData("探索", "聞き耳", 25),
			new SkillData("探索", "忍び歩き", 10),
			new SkillData("探索", "写真術", 10),
			new SkillData("探索", "精神分析", 1),
			new SkillData("探索", "追跡", 10),
			new SkillData("探索", "登攀", 40),
			new SkillData("探索", "図書館", 25),
			new SkillData("探索", "目星", 25),
			new SkillData("探索", "機械修理", 20),
			new SkillData("探索", "電気修理", 10),
			new SkillData("探索", "重機械操作", 1),
			new SkillData("探索", "乗馬", 5),
			new SkillData("探索", "水泳", 25),
			new SkillData("探索", "跳躍", 25),
			new SkillData("探索", "ナビゲート", 10),
			new SkillData("探索", "変装", 1),
			new SkillData("探索", "言いくるめ", 5),
			new SkillData("探索", "信用", 15),
			new SkillData("探索", "説得", 15),
			new SkillData("探索", "値切り", 5),

			new SkillData("知識", "医学", 5),
			new SkillData("知識", "オカルト", 5),
			new SkillData("知識", "科学", 1),
			new SkillData("知識", "クトゥルフ神話", 0),
			new SkillData("知識", "経理", 10),
			new SkillData("知識", "考古学", 1),
			new SkillData("知識", "コンピュータ", 1),
			new SkillData("知識", "心理学", 5),
			new SkillData("知識", "人類学", 1),
			new SkillData("知識", "生物学", 1),
			new SkillData("知識", "地質学", 1),
			new SkillData("知識", "電子工学", 1),
			new SkillData("知識", "天文学", 1),
			new SkillData("知識", "博物学", 10),
			new SkillData("知識", "物理学", 1),
			new SkillData("知識", "法律", 5),
			new SkillData("知識", "薬学", 1),
			new SkillData("知識", "歴史", 20),

			new SkillData("特殊", "武道：", 1),
			new SkillData("特殊", "母国語：", "EDU*5"),
			new SkillData("特殊", "その他の言語：", 1, false),
			new SkillData("特殊", "運転：", 20, false),
			new SkillData("特殊", "操縦：", 1, false),
			new SkillData("特殊", "制作：", 5, false),
			new SkillData("特殊", "芸術：", 5, false),
			new SkillData("特殊", "その他", 1, false),
		};

		static JobData[] JOB_DATAS = new JobData[]
		{
			new JobData("商店主/店員", "　コンビニや飲食店、販売店などさまざまな店舗の店員、または店主。あるいはネットショップ経営者など、経営学部の学生など。", "交渉の際、相手の<言いくるめ><値切り>に－10%ペナルティー","DEX", "APP", new SkillSet("言いくるめ", "聞き耳", "経理", "心理学", "信用", "値切り"), new SkillSet(1, "運転（自動車、二輪車）", "コンピューター"), new SkillSet(1, "商品知識として好きな技能")),
			new JobData("水産業従事者", "　沿岸漁業または遠洋漁業の漁師、養殖業者、水産加工業者、ダイバー、海女、水産大学生など。","CON+1", "DEX", new SkillSet("機械修理", "重機械操作", "水泳", "操縦（船舶）", "天文学", "ナビゲート", "博物学", "目星")),
			new JobData("農林業従事者", "　農家、酪農家、畜産業者、養蜂業者、林業者、ハンター、パークレンジャー、森林官、マタギなども含まれる。","CON+1またはSTR+1", "DEX", "STR", new SkillSet("応急手当", "機械修理", "重機械操作", "制作（農作物、畜産、養蜂など）", "追跡", "電気修理", "博物学"), new SkillSet(1, "杖", "ライフル", "ショットガン", "チェーンソー")),
			new JobData(" アニマルセラピスト", "　犬や猫などの動物との触れ合いを介して、精神的な障害を負った人々の治療に当たる。お年寄りを力づけたり、心を閉ざした子供へのセラピーが多い。現実世界ではボランティアにちかく、それなりの医療関係の資格を別に所持していることも多い。", "動物がなつきやすい。","APP", "POW", new SkillSet("聞き耳", "心理学", "精神分析", "生物学", "跳躍", "追跡", "博物学"), new SkillSet(1,"個人的な関心の技能")),
		};

		AvilityPoint strPoint, conPoint, powPoint, dexPoint, appPoint, sizPoint, intPoint, eduPoint;
		AvilityPoint hpPoint, mpPoint, sanPoint, ideaPoint, luckPoint, knowPoint;
		SkillPoint jobPoint, hobbyPoint;

		ObservableCollection<HoldingSkill> holdingSkills;
		JobData selectJob;
		Random random = new Random();


		public MainWindow()
		{
			InitializeComponent();
			var handler = new PropertyChangedEventHandler(basicStateChanged);

			strPoint = new AvilityPoint("STR", handler);
			conPoint = new AvilityPoint("CON", handler);
			powPoint = new AvilityPoint("POW", handler);
			dexPoint = new AvilityPoint("DEX", handler);
			appPoint = new AvilityPoint("APP", handler);
			sizPoint = new AvilityPoint("SIZ", handler);
			intPoint = new AvilityPoint("INT", handler);
			eduPoint = new AvilityPoint("EDU", handler);
			this.basicStatusGrid.ItemsSource = new[] { strPoint, conPoint, powPoint, dexPoint, appPoint, sizPoint, intPoint, eduPoint };

			hpPoint = new AvilityPoint("HP");
			mpPoint = new AvilityPoint("MP");
			sanPoint = new AvilityPoint("SAN");
			ideaPoint = new AvilityPoint("アイデア");
			luckPoint = new AvilityPoint("幸運");
			knowPoint = new AvilityPoint("知識");
			this.advancedStatusGrid.ItemsSource = new[] { hpPoint, mpPoint, sanPoint, ideaPoint, luckPoint, knowPoint };

			jobPoint = new SkillPoint("職業ポイント");
			hobbyPoint = new SkillPoint("趣味ポイント");
			this.skillPointGrid.ItemsSource = new[] { jobPoint, hobbyPoint };

			this.jobBox.ItemsSource = JOB_DATAS;
			this.jobBox.SelectedIndex = 0;

			var skillBoxList = new[] { this.skillBoxA, this.skillBoxB, this.skillBoxC, this.skillBoxD };
			string[] categorys = new string[] { "戦闘", "探索", "知識", "特殊" };
			for (int l = 0; l < skillBoxList.Length; l++)
			{
				var list = new List<object>();
				list.Add(new { Text = "＜" + categorys[l] + "技能＞" });
				foreach (var skill in SKILL_DATAS) if (skill.category == categorys[l]) list.Add(skill);
				skillBoxList[l].ItemsSource = list;
				skillBoxList[l].SelectedIndex = 0;
			}

			holdingSkills = new ObservableCollection<HoldingSkill>();
			this.holdingSkillGrid.ItemsSource = holdingSkills;
		}


		private int dice(int d) { return random.Next(d) + 1; }
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (sender == btnRandomState)
			{
				strPoint.BasePoint = dice(6) + dice(6) + dice(6);
				conPoint.BasePoint = dice(6) + dice(6) + dice(6);
				powPoint.BasePoint = dice(6) + dice(6) + dice(6);
				dexPoint.BasePoint = dice(6) + dice(6) + dice(6);
				appPoint.BasePoint = dice(6) + dice(6) + dice(6);
				sizPoint.BasePoint = dice(6) + dice(6) + 6;
				intPoint.BasePoint = dice(6) + dice(6) + 6;
				eduPoint.BasePoint = dice(6) + dice(6) + dice(6) + 3;
				return;
			}
			if(sender == btnRandomSkill)
			{
				// スキルを選出
				var selectedSkillList = new List<HoldingSkill>();
				var skillSets = selectJob.skillSets;
				foreach (var skillSet in skillSets)
				{
					int selectLimit = skillSet.num;

					// まず現状のスキルに持っているものに含まれるかをチェックする
					foreach(var skill in skillSet.skills)
					{
						var data = searchSkillData(skill);
						var holdingSkill = getHoldingSkill(data);
						if (holdingSkill != null)
						{
							if (selectLimit > 0) selectLimit--; 
							selectedSkillList.Add(holdingSkill);
						}
					}
					// 残りのスキルを算出する
					
				}

				return;
			}
		}

		private SkillData searchSkillData(string name)
		{
			foreach (var skill in SKILL_DATAS)
			{
				if (name.StartsWith(skill.name))
				{
					return skill;
				}
			}
			return new SkillData("特殊", "その他", 1, false);
		}

		private HoldingSkill getHoldingSkill(SkillData skill)
		{
			foreach (var hs in holdingSkills)
			{
				if (hs.Source == skill) return hs;
			}
			return null;
		}

		private void skillBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var skillBox = (sender as ComboBox);
			if (!(skillBox.SelectedItem is SkillData)) return;

			var skill = (skillBox.SelectedItem as SkillData);
			skillBox.SelectedIndex = 0;

			if (skill.check && getHoldingSkill(skill) != null) return;
			
			holdingSkills.Add(new HoldingSkill(skill, new PropertyChangedEventHandler(SkillPointChanged)));
			updateHoldingSkills();
		}

		private void updateHoldingSkills()
		{
			foreach (var hs in holdingSkills)
			{
				if (hs.Source.rule == null) continue;
				switch (hs.Source.rule)
				{
					case "DEX*5":
						hs.BasePoint = dexPoint.SumPoint * 5;
						break;

					case "EDU*5":
						hs.BasePoint = eduPoint.SumPoint * 5;
						break;
				}
			}
		}

		private void SkillPointChanged(object sender, PropertyChangedEventArgs e)
		{
			//Debug.WriteLine("ｐｐｐ"+e.PropertyName);
			if (e.PropertyName == "JobPoint")
			{
				int SumPoint = 0;
				foreach (var skill in holdingSkills) SumPoint += skill.JobPoint;
				jobPoint.UsePoint = SumPoint;
				return;
			}

			if (e.PropertyName == "HobbyPoint")
			{
				int SumPoint = 0;
				foreach (var skill in holdingSkills) SumPoint += skill.HobbyPoint;
				hobbyPoint.UsePoint = SumPoint;
				return;
			}
		}

		private void basicStateChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != "SumPoint") return;

			mpPoint.BasePoint = powPoint.SumPoint;
			sanPoint.BasePoint = powPoint.SumPoint * 5;
			luckPoint.BasePoint = powPoint.SumPoint * 5;
			hpPoint.BasePoint = (int)Math.Ceiling((conPoint.SumPoint + sizPoint.SumPoint) / 2.0f);
			ideaPoint.BasePoint = intPoint.SumPoint * 5;
			hobbyPoint.BasePoint = intPoint.SumPoint * 10;
	
			updateJobPoint();
			updateHoldingSkills();
		}

		private void updateJobPoint()
		{
			if (selectJob == null) return;
			int point = 0;
			foreach (var state in selectJob.status)
			{
				var ap = getAvilityPoint(state);
				if (ap == null) continue;
				int tmp = eduPoint.SumPoint * 10 + ap.SumPoint * 10;
				if (tmp > point) point = tmp;
			}
			jobPoint.BasePoint = point;
		}

		private AvilityPoint getAvilityPoint(string name)
		{
			switch (name)
			{
				case "STR": return strPoint;
				case "CON": return conPoint;
				case "POW": return powPoint;
				case "DEX": return dexPoint;
				case "APP": return appPoint;
				case "SIZ": return sizPoint;
				case "INT": return intPoint;
				case "EDU": return eduPoint;
			}
			return null;
		}

		private void jobBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var jobBox = (sender as ComboBox);
			selectJob = (jobBox.SelectedItem as JobData);
			this.jobText.Text = selectJob.Text;
			updateJobPoint();
		}
	}

	










	

}
