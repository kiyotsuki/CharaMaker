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
using Microsoft.Win32;
using System.IO;

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
			
			new SkillData("特殊", "クトゥルフ神話", 0),
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

new JobData("商店主/店員", "　コンビニや飲食店、販売店などさまざまな店舗の店員、または店主。あるいはネットショップ経営者など、経営学部の学生など。", "交渉の際、相手の<言いくるめ><値切り>に－10%ペナルティー。", "DEX", "APP",new SkillSet("言いくるめ", "聞き耳", "経理", "心理学", "信用", "値切り"), new SkillSet(1,"運転（自動車、二輪車）", "コンピューター"), new SkillSet(1,"商品知識として好きな技能")),

new JobData("水産業従事者", "　沿岸漁業または遠洋漁業の漁師、養殖業者、水産加工業者、ダイバー、海女、水産大学生など。", "CON+1。", "DEX",new SkillSet("機械修理", "重機械操作", "水泳", "操縦（船舶）", "天文学", "ナビゲート", "博物学", "目星")),

new JobData("農林業従事者", "　農家、酪農家、畜産業者、養蜂業者、林業者、ハンター、パークレンジャー、森林官、マタギなども含まれる。", "CON+1またはSTR+1。", "DEX","STR",new SkillSet("応急手当", "機械修理", "重機械操作", "制作（農作物、畜産、養蜂など）", "追跡", "電気修理", "博物学"), new SkillSet(1,"杖", "ライフル", "ショットガン", "チェーンソー")),

new JobData("メンタルセラピスト", "　人の心の傷を癒す人。企業カウンセラー、スクールカウンセラー、院内セラピストなど。メンタルケア心理士などとも。", "自分の患者に対する<説得>に+20%ボーナス。", "EDU",new SkillSet("言いくるめ", "芸術（絵画、楽器演奏、歌唱、アロマなど）", "信用", "心理学", "精神分析", "説得", "法律", "ほかの言語（英語、ドイツ語など）")),

new JobData(" アニマルセラピスト", "　犬や猫などの動物との触れ合いを介して、精神的な障害を負った人々の治療に当たる。お年寄りを力づけたり、心を閉ざした子供へのセラピーが多い。現実世界ではボランティアにちかく、それなりの医療関係の資格を別に所持していることも多い。", "動物がなつきやすい。", "POW","APP",new SkillSet("聞き耳", "心理学", "精神分析", "生物学", "跳躍", "追跡", "博物学"), new SkillSet(1,"個人的な関心の技能")),

new JobData("医師", "　医学・薬学に携わる者。内科・外科・精神科などの専門家医、薬剤師、看護師、介護士、臨床技師、救急救命士、大学あるいは民間企業の研究者、医学生・看護学生など。", "<信用>に+10%ボーナス。", "EDU",new SkillSet("医学", "応急手当", "経理", "信用", "生物学", "説得", "薬学", "ほかの言語（英語、ラテン語、ドイツ語）")),

new JobData(" 看護師", "　医師を補助し、医師の指示を受けながら患者の治療や世話をする。国家資格が必要で、男女を問わない。英語でも男女を問わず「ナース（nurse）」である。看護師は医師以上に患者と接触し、精神的な支えとなりうることから、患者の秘密を知る機会もあるだろう。", "<信用>技能値に＋10%ボーナス。患者に対する<説得>に＋10％ボーナス。", "EDU",new SkillSet("化学", "生物学", "応急手当", "言いくるめ/説得", "薬学", "心理学", "聞き耳", "目星")),

new JobData(" 救急救命士", "　救急車などに搭乗して救命活動を行う。現場や救急車内で傷病者に対し、人工呼吸や心臓マッサージ、酸素投与などのさまざまな応急処置を施すこともあるが、許される処置は資格によって範囲が異なる（救急過程や救命士の資格などがある）。119番通報によって事故現場、火災現場、傷病人のいる場所に真っ先に駆けつけることも多く、ほかの職業の人々以上に超常的な現象に遭遇する機会もあるだろう。", "人間や自然界の動物の死体などを見ても正気度ポイントを失わない。ただし、超自然的な原因で死に至ったことが分かれば通常通り正気度ポイントを失う。", "DEX",new SkillSet("医学", "応急手当", "化学", "鍵開け", "機械修理", "電気修理", "登攀")),

new JobData("形成外科医", "　形成外科は体の表面のケガや異常を治療するもので、ヤケドあとやアザを取り除いたり、失われた部位の再建手術なども行う。整形外科は骨や筋肉の異常や障害を治療するもので、一般の認識とは異なり、美容外科は形成外科はの一部である。形成（美容）外科医の下には、不思議な形のあざに悩んでいたり皮膚がうろこ状になっていたりする患者が訪れるかもしれない。", "APP+1。", "DEX",new SkillSet("医学", "応急手当", "経理", "心理学", "説得", "値切り", "薬学", "ほかの言語（英語）")),

new JobData("外科医、歯科医", "　医学・薬学に携わる者。内科・外科・精神科などの専門家医、薬剤師、看護師、介護士、臨床技師、救急救命士、大学あるいは民間企業の研究者、医学生・看護学生など。","DEX+1　", "DEX",new SkillSet("医学", "応急手当", "経理", "信用", "生物学", "説得", "薬学", "ほかの言語（英語）")),

new JobData("精神科医", "　精神に関わる疾患の診療を専門とする医師。アメリカでは専門の免許が必要だが、日本では通常の医師免許を持っていればよい。現代では精神疾患を抱える患者の数も増加しており、精神科医の数も増加しつつある。精神科医の患者には、神話存在によって正気を失った人々もいるかもしれない。精神科医である探索者は徐々に患者たちの体験の真実を知ることになるだろう。", "１件の狂気において<精神分析>ロールに失敗しても、環境を整えたり投薬を行なったりすることで再度<精神分析>のロールを行うことができる。", "EDU","APP",new SkillSet("医学", "化学", "心理学", "精神分析生物学", "説得", "薬学", "ほかの言語")),

new JobData("闇医者", "　自分の信念あるいは利益のために法や条例に従わずに医術を用いる医師。普通、正規の医師であったものが、何かしらの事件（クトゥルフ神話に関係するものだったかもしれない）を経験して闇の世界に身を投じた場合が多い。裏世界とつながりを持つうちに、武器の技能やメスを<投擲>する技能に長じることもあるかもしれない。", "不十分な器具や設備でも、有り合わせの器具で十分な応急手当ができる。", "EDU","DEX",new SkillSet("医学", "応急手当", "経理", "説得", "法律", "薬学", "ほかの言語"), new SkillSet(1,"個人的な関心の技能1つ")),

new JobData("海上保安官", "　領海と排他的経済水域を監視する海上保安庁に所属する国家公務員。日本の領海と排他的経済水域を合わせた面積は447万km2に及び、これは世界第6位の広さとなる。この広大な海を警戒する巡視船に搭乗した探索者はさまざまな海の怪異に遭遇するに違いない。", "<目星>に+10%ボーナス。", "DEX","STR",new SkillSet("機械修理", "重機械操作", "信用", "操縦（船舶）", "登攀", "ナビゲート", "法律", "サバイバル（海）")),

new JobData("科学捜査研究員", "　警察などの法執行機関で、科学的な手法で証拠物件を集める。ここでは鑑識員、犯罪現場フォトグラファーなどもこれに含めることにする。彼らが事件現場に残された超自然的物証を目にすることもあるかもしれない。", "人間や自然界の動物の死体などを見ても正気度ポイントを失わない。ただし、超自然的な原因で死に至ったことが分かれば通常通り正気度ポイントを失う。", "DEX",new SkillSet("医学", "化学", "コンピューター", "写真術", "人類学", "生物学", "法律", "薬学")),

new JobData("山岳救助隊員", "　近づくことが困難な場所に行って遭難者を救助する。遭難現場は険峻で接近が困難な場所であることが予想され、おそらく天候も最悪であろう。極限状態で探索者が見たものは、人間の目が触れえぬ存在が残した遺構、あるいは存在そのものなのかもしれない。", "高所恐怖症でない限り、高所で恐怖を感じることはない。", "DEX","STR",new SkillSet("応急手当", "聞き耳", "跳躍", "追跡", "登攀", "ナビゲート", "サバイバル（山）", "ほかの言語")),

new JobData("消防士", "　消防士は主に火災を鎮めることを任務として自治体に雇われている公務員だ。通常三交代制で24時間の勤務、24時間の待機、24時間の非番を繰り返す。勤務時には食事、睡眠、休憩も消防署内でとる。火災や爆発現場に出動した消防士が、恐るべき事実に触れることもままある。", "STR+1またはCON+1。炎に対する恐怖心を克服している。", "DEX","STR",new SkillSet("運転（自動車）", "応急手当", "回避", "機械修理", "重機械操作", "跳躍", "投擲", "登攀")),

new JobData("作家", "　物語を創作することで身を立てる人。小説家、翻訳家、ゲーム・映画・演劇などの脚本家、漫画原作者、文学部の学生など。", "作品の得意分野（歴史、SF、法廷、心理サスペンスなど）としている技能に+10%ボーナス。", "EDU",new SkillSet("オカルト", "芸術（トリビア知識、詩的表現など）", "心理学", "説得", "図書館", "ほかの言語（英語など）", "母国語", "歴史")),

new JobData("芸術家", "　画家、彫刻家、陶芸家、書家、漫画家、カメラマン、各種デザイナー、映画監督、美大・芸大の学生など。", "専門とする分野の<芸術>または<制作>技能に+10%ボーナス。","DEX","POW",new SkillSet("言いくるめ", "説得", "芸術（任意）/制作（任意）", "心理学", "目星", "歴史/博物学"), new SkillSet(3,"コンピューター", "写真術", "生物学", "天文学", "芸術（任意）/制作（任意）")),

new JobData("ダンサー", "　ダンサー、バックダンサー、バレエダンサー、前衛舞踏家など。もしかしたら、素手の接近戦技能にも長じているかもしれない。", "<芸術（ダンス）>に+10%ボーナス。<回避>に+10%ボーナス。","DEX","POW",new SkillSet("回避", "芸術（ダンス）", "忍び歩き", "跳躍", "登攀", "目星"), new SkillSet(1,"個人的な関心の技能"), new SkillSet(1,"個人的な関心の技能")),

new JobData("デザイナー", "　webデザイナー/クリエイターなど商業デザインを行う人々。芸術より制作寄りの職業かもしれない。", "流行に敏感。感受性が高く、絵画や彫刻などに込められた暗喩に気づきやすい。", "EDU","POW",new SkillSet("言いくるめ/説得", "芸術（任意）/制作（任意）", "コンピューター", "心理学", "図書館", "目星"), new SkillSet(1,"個人的な関心の技能"), new SkillSet(1,"個人的な関心の技能")),

new JobData("ファッション系芸術家", "　ファッション・デザイナー、ファッション・コーディネーター、メイクアップ・アーティスト、エステティシャン、ネイルアーティストなど。", "流行に敏感。相手の服装を見ただけで、社会的地位や収入などがわかる。さりげないアクセサリーの価値もわかる。","DEX","POW",new SkillSet("言いくるめ/説得", "芸術（任意）/制作（任意）", "心理学", "値切り", "変装", "目星"), new SkillSet(1,"個人的な関心の技能"), new SkillSet(1,"個人的な関心の技能")),

new JobData("警察、刑事", "　専任捜査官（刑事）、交番勤務、地域課・交通課職員、機動隊員、交通機動隊（白バイ隊）、警察官僚、警察学校の学生など。", "制服を着ているか、警察手帳を提示すれば<信用>と<説得>に+20%ボーナス。ただし、何らかの理由で警察に敵意を抱いている者に対してはその限りではない。","EDU","STR",new SkillSet("聞き耳", "心理学", "説得", "追跡", "法律", "目星"), new SkillSet(1,"運転（自動車、二輪車）", "信用", "組みつき", "武道（柔道）", "日本刀", "拳銃", "杖")),

new JobData("陸上自衛隊", "　戦闘兵科には普通科（歩兵）、機甲科（戦車、装甲車）、特科（砲兵）、施設科（工兵）などがある。直接戦闘に参加しない支援兵科には通信科、輸送科、化学科、衛生科、警務科、情報科などがある。", "幹部自衛官（士官）は軍事や先頭に関する<説得>に+10%、その他の自衛官（下士官・兵）はSTR+1またはCON+1。", "EDX","STR",new SkillSet("応急手当", "回避", "隠れる", "サバイバル（山/砂漠）"), new SkillSet(1,"任意の近接職技能"), new SkillSet(1,"任意の火器技能"), new SkillSet(2, "機械修理", "忍び歩き", "水泳", "登攀", "ほかの言語", "パラシュート", "重機械操作", "砲")),

new JobData("海上自衛隊（艦上勤務）", "　海上自衛隊は大小の各種護衛艦を保有しており、航海、通信、電測、情報、射撃などの職種の隊員が艦上で任務に就いている。海上保安庁と同様、海上自衛隊も海洋の怪異に遭遇するかもしれない。", "幹部自衛官（士官）は軍事や先頭に関する<説得>に+10%、その他の自衛官（下士官・兵）はSTR+1またはCON+1。", "EDX","STR",new SkillSet("応急手当", "重機械操作", "水泳", "操縦（ボート）", "ナビゲート", "サバイバル（海）"), new SkillSet(2, "機械修理", "電気修理"), new SkillSet(1,"任意の近接技能"), new SkillSet(1,"任意の火器技能", "砲")),

new JobData("パイロット", "　飛行機を操縦する人。旅客機操縦士、輸送機操縦士、自家用機操縦士、航空自衛官など。", "異性に対してAPP+1。", "DEX",new SkillSet("機械修理", "重機械操作", "電気修理", "操縦（民間プロペラ機、民間ジェット、定期旅客機、ジェット戦闘機、ヘリコプター、飛行船）", "天文学", "ナビゲート", "物理学", "ほかの言語（英語その他）")),

new JobData("自衛隊パイロット（陸空海）", "　さまざまな航空機のうち戦闘機、大型機、ヘリコプターは専用の<操縦>技能を必要とする（キーパーは技能値を２分の１にして専門外の航空機を操縦させてもよい）。小型機はどの<操縦>技能を用いても操縦できることとする。オスプレイのようなティルトローター機は<操縦（ヘリコプター）>で扱うこととする。", "幹部自衛官（士官）は軍事や先頭に関する<説得>に+10%、その他の自衛官（下士官・兵）はSTR+1またはCON+1。", "DEX",new SkillSet("機械修理", "重機械操作", "操縦（戦闘機、大型機、ヘリコプター等）", "電気修理", "天文学", "ナビゲート", "パラシュート"), new SkillSet(1,"個人的な関心の技能")),

new JobData("民間軍事会社メンバー", "　金銭で雇われている兵士であり、正規の軍隊の代わりに治安維持や戦闘任務を行う。事実上、憲兵と同じ。国際法上、戦闘員とは認められておらず、捕虜となる権利などもない。リスクが大きいなどの理由で正規の軍隊が嫌がる任務や特殊な任務を引き受けるうちに超常的な事件に遭遇するかもしれない。", "<人類学>に＋10%ボーナス。", "DEX","STR",new SkillSet("回避", "隠れる", "忍び歩き", "水泳/登攀"), new SkillSet(1,"任意の近接技能"), new SkillSet(1,"任意の火器技能")),

new JobData("DEX系アスリート", "　テニス選手、野球選手、サッカー選手などの俊敏性を重視するスポーツ選手や、エアロ、ヨガ、スポーツ・トレーナーなどが含まれる。", "CON、STR、SIZ、DEXのいずれかに＋１。EDUに－1。", "DEX",new SkillSet("回避", "芸能（任意のスポーツ競技）", "跳躍", "投擲", "登攀"), new SkillSet(3,"応急手当", "乗馬", "水泳", "こぶし/パンチ", "キック", "組みつき", "武道（任意）", "日本刀", "薙刀", "杖", "弓", "アーチェリー", "拳銃", "ライフル", "ショットガン", "忍び歩き")),

new JobData("STR系アスリート", "　力士、レスラーなど肉体の力を重視するスポーツ選手など。", "CON、STR、SIZ、DEXのいずれかに＋１。EDUに－1。", "STR",new SkillSet("回避", "芸能（任意のスポーツ競技）", "跳躍", "投擲", "登攀"), new SkillSet(3,"応急手当", "乗馬", "水泳", "こぶし/パンチ", "キック", "組みつき", "武道（任意）", "日本刀", "薙刀", "杖", "弓", "アーチェリー", "拳銃", "ライフル", "ショットガン")),

new JobData("CON系アスリート", "　長距離走選手など、耐久力を重視するスポーツ選手など。", "CON、STR、SIZ、DEXのいずれかに＋１。EDUに－1。","CON",new SkillSet("回避", "芸能（任意のスポーツ競技）", "跳躍", "投擲", "登攀"), new SkillSet(3,"応急手当", "乗馬", "水泳", "こぶし/パンチ", "キック", "組みつき", "武道（任意）", "日本刀", "薙刀", "杖", "弓", "アーチェリー", "拳銃", "ライフル", "ショットガン")),

new JobData("ドライバー", "　自動車運転を仕事にする人。タクシー運転手、バス運転手、トラック運転手、大富豪のお抱え運転手、バイク便、レーサーなど。", "熟練の「スタント」行為を成功させることができる。衝突や横転を比較的制御しながら安全に行なうこともできる。", "DEX",new SkillSet("運転（自動車、二輪車）", "機械修理", "聞き耳", "重機械操作", "電気修理", "ナビゲート", "値切り", "目星")),

new JobData("ボートレーサー", "　小型のモーターボートを高速で操縦することができる。", "熟練の「スタント」行為を成功させることができる。衝突や横転を比較的制御しながら安全に行なうこともできる。", "DEX",new SkillSet("運転（モーターボート）", "機械修理", "聞き耳", "重機械操作", "電気修理", "ナビゲート", "値切り", "目星")),

new JobData("古物研究家", "　値打ちのある珍しい古物を収集・研究・分類する人。古書店・骨董品店主、博物館学芸員、図書館司書、民間の郷土史家、美大・考古学部の学生など。", "古物に関する<言いくるめ>と<説得>に+10%ボーナス。", "EDU",new SkillSet("芸術（任意）", "コンピューター", "制作（古書修復、古美術修復など）", "図書館", "値切り", "ほかの言語（英語、漢文、ラテン語など）", "目星", "歴史")),

new JobData("大学教授", "　大学や企業の研究機関で専門分野の研究に従事する人、あるいはその学生や助手（院生）など。", "<信用>+10%ボーナス。大学の関係者に対しては+20%ボーナス。", "EDU",new SkillSet("信用", "心理学", "説得", "図書館", "値切り", "ほかの言語（英語など）"), new SkillSet(2, "医学", "化学", "考古学", "人類学", "生物学", "地質学", "電子工学", "天文学", "博物学", "物理学", "法律", "歴史")),

new JobData("冒険家教授", "　研究室にこもりがちな大学教授の中にあって、遺跡や野生動物などの調査のために野外を駆け回るタイプの学者である。知力と体力を兼ね備えている。インディー・ジョーンズがこの職業の代表。", "研究分野における<目星>に+20%のボーナス。", "DEX","CON",new SkillSet("応急手当", "説得", "跳躍", "登攀", "図書館", "ほかの言語"), new SkillSet(1,"専門の技能"), new SkillSet(1,"専門の技能")),

new JobData("ジャーナリスト", "　真実を報道する人。新聞記事、通信社員。雑誌記事、雑誌編集者、テレビ・リポーター、報道アナウンサー、ニュースブロガー、経済学部の学生など。", "真実が隠蔽された報道を目ざとく見分けることができる。", "EDU",new SkillSet("言いくるめ", "写真術", "心理学", "説得", "図書館", "母国語", "ほかの言語（英語）", "歴史")),

new JobData("評論家", "　専門分野を決める（例：経済、政、スポーツ、軍事、料理など）。テレビや雑誌などのメディアで、専門分野に関する意見を述べる。", "専門分野における<説得>に＋10%ボーナス。", "EDU",new SkillSet("信用", "心理学", "説得", "図書館", "値切り", "母国語"), new SkillSet(2,"専門分野")),

new JobData("ディレッタント", "　資産家の趣味人。士官化の教養人。大企業の会長、ビルオーナー、投資家など。", "<信用>に+10%ボーナス。地元のさまざま同好会やクラブの会員だったり、コネがある。", "EDU", "APP",new SkillSet("運転（自動車）", "芸術（音楽、美術、文学、ダンス、何かのスポーツ）", "信用", "図書館", "法律", "ほかの言語（英語など）"), new SkillSet(2, "乗馬", "写真術", "操縦（航空機、船舶）", "拳銃", "ライフル", "ショットガン", "武道（任意）")),

new JobData("ミュージシャン", "　音楽に生きる人。ロックバンド、ストリートミュージシャン、シンガーソングライター、作詞家、作曲家、音楽プロデューサー、クラシック音楽家、音楽科の学生など。", "パフォーマンスを行ない、専門の<芸術>または<制作>に成功したら、<言いくるめ>と<説得>に+10%ボーナス。ファンに対してさらに+10%ボーナス。", "DEX",new SkillSet("言いくるめ", "聞き耳", "芸術（歌唱、何かの楽器演奏）", "制作（作詞、作曲）", "説得", "心理学", "値切り", "ほかの言語（英語など）")),

new JobData("アイドル、音楽タレント", "　音楽を主としているが、“ミュージシャン”と異なり、音楽の芸術性よりダンスなどのパフォーマンスや若さなど、斬体のイメージで人気を得るタレント。年齢が高くなると「元アイドル」などと呼ばれる。", "ファンに対して<説得>に+20%ボーナス。","APP",new SkillSet("言いくるめ", "芸術（歌唱）", "芸術（ダンス）", "心理学", "説得", "変装"), new SkillSet(1,"個人的な関心の技能"), new SkillSet(1,"個人的な関心の技能")),

new JobData("アナウンサー", "　テレビ、ラジオ、web、イベントなどでアナウンスを行う。アナウンス技術のほかにタレント性が必要とされることも多い。", "本心を隠すのがうまい。相手の<心理学>に－10％のボーナス。", "EDU","APP",new SkillSet("言いくるめ", "信用", "心理学", "説得", "芸術（アナウンス）", "図書館", "母国語"), new SkillSet(1,"個人的な関心の技能")),

new JobData("コメディアン", "　舞台やテレビで活躍する。演出や台本などをすべて自分で考えなければならないことが多い。", "<言いくるめ>に+10%ボーナス。", "DEX",new SkillSet("言いくるめ", "聞き耳", "心理学", "芸術（物語）", "芸術（演劇）", "変装"), new SkillSet(1,"個人的な関心の技能"), new SkillSet(1,"個人的な関心の技能")),

new JobData("タレント", "　テレビ・映画・演劇を主な活動の舞台とする芸能人。アイドル、俳優、声優、イベント司会者、マジシャン、ダンサー、モデル、レースクイーンなど。", "ファンに対して<説得>に+20%ボーナス。テレビ局の人間にコネがある。芸能人に顔が広い。", "EDU",new SkillSet("言いくるめ", "聞き耳", "信用", "心理学", "説得", "芸術（何かの楽器演奏、歌唱、ダンス、演技、司会など）", "変装", "ほかの言語（英語）")),

new JobData("スポーツタレント", "　体を張った芸をするコメディアンなど。", "CON+1または<回避>に+10%ボーナス。EDU－1。", "CON","STR",new SkillSet("言いくるめ", "心理学", "芸術（演劇）", "跳躍/登攀", "変装"), new SkillSet(1,"任意の素手の近接戦技能"), new SkillSet(1,"個人的な関心の技能"), new SkillSet(1,"個人的な関心の技能")),

new JobData("テレビ・コメンテーター", "　テレビ、ラジオ、web、イベントなどでテーマに即した意見や解説を述べる。視聴者や聴衆の受けが良くないと指名されなくなる。", "本心を隠すのがうまい。相手の<心理学>に－10％のボーナス。", "EDU","APP",new SkillSet("言いくるめ", "聞き耳", "信用", "心理学", "説得", "図書館", "値切り"), new SkillSet(1,"個人的な関心の技能")),

new JobData("ネットタレント", "　インターネットに動画や音楽を配信し、視聴者の人気を集める。手法や扱う分野によって、実況者、歌い手、踊り手、ボカロPなどさまざまなタイプに分かれる。", "APP+1またはCON+1。ネット上のうわさ話に関する<図書館>に+10%ボーナス。", "DEX",new SkillSet("芸術（歌唱、演劇、ダンス、楽器演奏など）", "コンピューター", "心理学", "説得", "電気修理"), new SkillSet(1,"個人的な関心の技能"), new SkillSet(1,"個人的な関心の技能"), new SkillSet(1,"個人的な関心の技能")),

new JobData("プロデューサー、マネージャー", "　テレビ番組制作者や、タレントの付き人などのマスコミ関係者。", "テレビ局にコネを持っており、自由に出入りできる。うまくすれば、有名人も近づける。","POW",new SkillSet("言いくるめ", "運転（自動車）", "隠れる", "聞き耳", "忍び歩き", "値切り", "法律"), new SkillSet(1,"個人的な関心の技能")),

new JobData("執事/メイド", "　使用人として雇われる人々。ゲート上、専業主婦もこの職業に含まれることとする。", "主人のそばに控えていれば、主人の<言いくるめ>と<信用>に+10%ボーナス。", "EDU",new SkillSet("言いくるめ/説得", "応急手当", "聞き耳", "芸術/制作（ワインの鑑定、料理、裁縫、掃除など）", "経理", "心理学", "目星", "ほかの言語")),

new JobData("法律家", "　法に携わる人。弁護士、公認会計士、税理士、司法書士、行政書士、弁理士、公証人、法学者、法科の学生など。", "<信用>および<法律>に+10%ボーナス。", "EDU",new SkillSet("言いくるめ", "経理", "信用", "心理学", "説得", "図書館", "値切り", "法律")),

new JobData("ビジネスマン", "　営業マン、事務員、金融業者、企業コンサルタント、通訳、秘書、経営・商業科の学生など。", "<経理>に+10%ボーナス。", "EDU",new SkillSet("言いくるめ", "経理", "コンピューター", "信用", "説得", "値切り", "法律", "ほかの言語（英語、その他ビジネス相手の国の言語）")),

new JobData("セールスマン", "　ビジネスマンのなかでも直接顧客と相対して、品物やサービスを売り込む人々。会社や個人宅を手当たり次第に回る人もいれば、大口の顧客やスポンサーにプレゼンテーションを行う人々もいる。また、カウンターで来客に商品やサービスを進める人々もこの職業に含まれるだろう。商品は日常に扱うものから不動産や金融商品までさまざまであり、サービスの種類も通信、衣食住、広告などの多岐にわたる。", "自分の商材に関する<言いくるめ>と<説得>に+10%ボーナス。", "POW","APP",new SkillSet("言いくるめ", "運転（自動車）", "芸術（演技）", "経理", "心理学", "説得", "値切り"), new SkillSet(1,"個人的な関心の技能")),

new JobData("ホスト、ホステス", "　ゲーム上、この職業は風俗業にとどまらず、対面で接客し、客の要望を満たすさまざまな職業を含むものとする。ホスト、ホステス、ウエーター、ウエートレス。コンセルジュ、テーマパーク・スタッフなどがこの職業に含まれる。", "勤務時など、完璧な身だしなみを整えている際はAPP+2（技能ポイントは増えない）。", "POW","APP",new SkillSet("言いくるめ", "回避", "聞き耳", "経理", "心理学", "説得", "値切り", "目星")),

new JobData("エンジニア", "　自動車・航空機・工業機械や電気部品の設計技術者、機関士、整備士。建物や橋梁の設計建築士、高専・工業高校・工科大学学生など。", "自分の専門分野の構造物や製品であれば、歴史上古いものでも遺構、遺物、図面などから、その構造設計思想などを理解することができる。", "EDU",new SkillSet("機械修理", "コンピューター", "重機械操作", "電気修理", "図書館", "物理学", "ほかの言語（英語）"), new SkillSet(1,"化学", "物質学", "電気工学")),

new JobData("コンピューター技術者", "　プログラマー、システムエンジニア、ネットワーク管理者、ゲームクリエイター、ハッカー、クラッカー、高専・工業高校・工科大学の学生など。", "<コンピューター>に+10%ボーナス。", "EDU",new SkillSet("言いくるめ", "経理", "コンピューター", "電気修理", "電子工業", "図書館", "物理学", "ほかの言語（英語、その他）")),

new JobData("メカニック", "　この職業は特別な訓練、つまり弟子、徒弟、見習いなどとして働きながら学ぶ期間を必要とするすべての種類の職人が含まれる。大工、石工、配管工、電子工、機械工、機械修理工などはすべて熟練の職人の資格を持つ。", "自分の専門分野の構造物や商品であれば、一通り見れば、その構造や不自然な点に気づくことができる。", "EDU",new SkillSet("芸術/制作（大工、溶接、配管など）", "登攀", "運転（自動車）", "電気修理", "機械修理", "重機械操作"), new SkillSet(1,"個人的な関心の技能"), new SkillSet(1,"個人的な関心の技能")),

new JobData("料理人", "　コック、板前、パティシエ、ショコラティエ、ソムリエなど。", "専門のサービスを提供し、かつ芸術/制作（料理）に成功すれば、<信用><説得>などに+10%ボーナス。", "DEX",new SkillSet("化学", "芸術/制作（料理）", "生物学", "博物学", "目星", "ほかの言語", "歴史（特に料理関係）"), new SkillSet(1,"肉切り包丁", "小型ナイフ", "小さい棍棒")),

new JobData("ギャンブラー", "　公営ギャンブルだけでなく、犯罪組織が主催する違法なギャンブルに手を染めた人々。", "ギャンブルの際、<幸運>に+10%ボーナス。", "DEX","APP",new SkillSet("言いくるめ", "隠す", "聞き耳", "芸術（演劇）", "経理", "心理学", "目星"), new SkillSet(1,"個人的な関心の技能")),

new JobData("暴力団組員", "　いわゆるヤクザ。極道者。ジャパニーズ・マフィアの構成員。", "EDU－1、STR＋1。", "DEX","STR",new SkillSet("言いくるめ", "隠す", "芸術（刺青彫り、イカサマ）", "心理学", "値切り", "目星"), new SkillSet(2, "隠す", "こぶし/パンチ", "キック", "組みつき", "武道（任意）", "日本刀", "ナイフ", "拳銃")),

new JobData("経済犯罪者", "　詐欺、証券通貨の偽造などの犯罪を働く人々。", "年収が＋50%アップ。", "EDU",new SkillSet("言いくるめ", "経理", "コンピューター", "信用", "心理学", "説得", "値切り", "法律")),

new JobData("ストリート・ローグ", "　不良、チーマー、カラーギャング、フラッパー、ギャルなど、ファッションや行動様式は善良なる一般市民のものから逸脱しているものの、犯罪者ではない人々。基本的に若者。", "地元の裏道や地元の裏のルールに精通している。", "DEX","STR",new SkillSet("言いくるめ", "隠れる", "心理学", "目星"), new SkillSet(4, "芸術（ダンス）", "芸術（ファッション）", "跳躍", "投擲", "登攀", "変装", "ナイフ"), new SkillSet(1,"任意の素手の戦闘技能")),

new JobData("放浪者", "　住所を定めず各地を放浪する人々。バックパッカー、自転車旅行者、旅打ちギャンブラー、屋台のテキ屋、出稼ぎ労働者、お遍路さんなど。", "子供に対する<言いくるめ>と<心理学>に+10%ボーナス。", "DEX","APP",new SkillSet("言いくるめ", "隠れる", "聞き耳", "忍び歩き", "心理学", "値切り", "目星"), new SkillSet(1,"運転（自動車、二輪車）", "芸術（ギャンブル）", "ほかの言語（英語など）")),

new JobData("ネット犯罪者", "　ハッキングの技術やウィルスなどを使い、対象のネットワークに侵入、データを奪取や書き換えを行なう。", "CON－1。ネット上のうわさ話に関する<図書館>と制作（コンピューター・ウィルス）に+10%ボーナス。", "EDU",new SkillSet("コンピューター", "心理学", "芸術（ハッキング）", "制作（コンピューター・ウィルス）", "図書館", "法律"), new SkillSet(1,"個人的な関心の技能"), new SkillSet(1,"個人的な関心の技能")),

new JobData("用心棒", "　戦闘能力を買われて雇われる一匹オオカミ的アウトロー。戦闘のために高い近接戦技能もしくは火器技能を持っている。護衛のためにやとわれれば用心棒だが、襲撃のためい雇われればヒットマンと呼ばれる。", "人間や自然界の動物の死体などを見ても正気度ポイントを失わない。ただし、超自然的な原因で死に至ったことが分かれば通常通り正気度ポイントを失う。", "DEX","STR",new SkillSet("鍵開け", "隠れる", "忍び歩き", "心理学", "追跡", "変装"), new SkillSet(1,"任意の近接戦技能"), new SkillSet(1,"任意の火器技能")),

new JobData("私立探偵", "　私的に雇われて調査する人。探偵社員、興信所職員、保険調査員など。", "隠密行動が得意。<隠れる>に+10%ボーナス。", "DEX","STR",new SkillSet("言いくるめ", "鍵開け", "心理学", "追跡", "図書館", "法律", "目星"), new SkillSet(1,"聞き耳", "写真術", "値切り", "こぶし/パンチ")),

new JobData("公選職", "　自治体の長や議員、国会議員など。", "<信用>に+10%ボーナス。自分の選挙区であれば+20%ボーナス。", "APP",new SkillSet("言いくるめ", "聞き耳", "芸術（握手）", "心理学", "説得", "法律", "歴史", "母国語")),

new JobData("自宅警備隊", "　いわゆるニートと呼ばれる人々だが、自宅にこもってコンピューターに向かって仕事をしている人々もこれに含まれるかもしれない。（例：デイトレーダー）", "CON－1。ネット上のうわさ話に関する<図書館>に+20%ボーナス。", "EDU",new SkillSet("隠れる", "聞き耳", "コンピューター", "忍び歩き", "図書館"), new SkillSet(1,"個人的な関心の技能"), new SkillSet(1,"個人的な関心の技能"), new SkillSet(1,"個人的な関心の技能")),

new JobData("人間山脈", "　体の大きさを武器に体を張った仕事をする人々。ガタイが良く、歓迎されざる人々を威圧できるため、ボディーガード、SP、付き人、黒服などの仕事に就く。危険な仕事をさけたい場合は、フードファイターやタレント業に就くこともある。", "SIZ+1。<回避><隠れる><忍び歩き>に－20%ペナルティー。", "SIZ",new SkillSet("投擲", "武道"), new SkillSet(2, "素手の近接戦技能"), new SkillSet(1,"個人的な関心の技能"), new SkillSet(1,"個人的な関心の技能"), new SkillSet(1,"個人的な関心の技能")),

new JobData("ビデオ・ゲーム・テスター", "　コンシューマー・ゲームなどのテストプレイヤー。", "仕事で携わったゲームのファンに対して<言いくるめ>と<信用>に+10%ボーナス。", "DEX",new SkillSet("言いくるめ", "聞き耳", "芸術（ゲーム）", "コンピューター", "電気修理", "値切り"), new SkillSet(2, "個人的な関心の技能")),

new JobData("ビデオ・ジャーナリスト", "　自分でビデオを回し自分でネットにアップするジャーナリスト。さまざま事件現場や、時には戦場にまで出掛けて取材を行なう。", "自分のビデオの視聴者に対する<言いくるめ>と<心理学>に+10%ボーナス。", "DEX",new SkillSet("言いくるめ", "隠す", "写真術", "電気修理", "法律", "目星"), new SkillSet(2, "運転（自動車）", "隠れる", "ナビゲート")),

new JobData("宗教家", "　信仰に生きる人。僧侶、尼僧、神職、巫女、新婦、牧師修道女、易者、宗教学部・哲学部の学生など。", "支援者に対する<信用>に+10%ボーナス。", "EDU",new SkillSet("オカルト", "聞き耳", "経理", "心理学", "説得", "図書館", "歴史"), new SkillSet(1,"言いくるめ", "信用", "ほかの言語（漢文、梵語、ラテン語など）")),

new JobData("ゴーストハンター", "　さまざまな測定機器具をつかって超自然的に挑み、その真実を解明しようとする。特殊なカメラやガイガーカウンターなどの装置を創意工夫で超自然用に改造したりもするが、その効果は定かではない。", "超常現象に関する<目星>に+10%ボーナス。", "DEX","EDU",new SkillSet("オカルト", "化学", "機械修理", "写真術", "生物学", "説得", "電気修理", "物理学")),

new JobData("超心理学者", "　オカルト現象を化学的に解明しようとする研究者。または超心理学に傾倒している心理学部の学生。", "オカルトを信じている人に対する<言いくるめ><説得>に+10%ボーナス。", "EDU",new SkillSet("オカルト", "人類学", "写真術", "心理学", "精神分析", "図書館", "ほかの言語（英語、ラテン語など）", "歴史")),

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
			if(sender == btnAddJobSkill)
			{
				var tmpList = new List<string>();
				var skillSets = selectJob.skillSets;
				foreach (var skillSet in skillSets)
				{
					foreach (var skillName in skillSet.skills)
					{
						tmpList.Add(skillName);
					}
				}
				for (int l = 0; l < 100; l++)
				{
					int r = random.Next(tmpList.Count);
					var skillName = tmpList[r];
					var skill = searchSkillData(skillName);
					if (skill == null) continue;
					if (addHoldingSkill(skill, skillName)) break;
				}
				return;
			}
			if(sender == btnAddHobbySkill)
			{
				for (int l = 0; l < 100; l++)
				{
					int r = random.Next(SKILL_DATAS.Length);
					var skill = SKILL_DATAS[r];
					if (skill.category == "特殊") continue;
					if (addHoldingSkill(skill)) break;
				}
				return;
			}
			if(sender == btnSaveForText)
			{
				var dialog = new SaveFileDialog();
				dialog.Title = "ファイルを開く";
				dialog.Filter = "テキストファイル(*.txt)|*.txt";
				if (dialog.ShowDialog() == true)
				{
					using (Stream fileStream = dialog.OpenFile())
					using (StreamWriter sr = new StreamWriter(fileStream))
					{
						string text = "[クトゥルフTRPG 2015]\n";

						text += "\n名称\t基礎\t可算\t合計\n";
						var basicStatus = (basicStatusGrid.ItemsSource as AvilityPoint[]);
						foreach (var state in basicStatus)
						{
							text += state.Name + "\t\t" + state.BasePoint + "\t\t" + state.AddPoint + "\t\t" + state.SumPoint + "\n";
						}

						text += "\n名称\t基礎\t可算\t合計\n";
						var advancedStatus = (advancedStatusGrid.ItemsSource as AvilityPoint[]);
						foreach (var state in advancedStatus)
						{
							text += state.Name + "\t" + state.BasePoint + "\t\t" + state.AddPoint + "\t\t" + state.SumPoint + "\n";
						}
						
						text += "\n職業：" + selectJob.name + "\n" + jobText.Text;

						text += "\n名称\t\t\t初期値\t追加値\t利用値\n";
						text += jobPoint.Name + "\t" + jobPoint.BasePoint + "\t\t" + jobPoint.AddPoint + "\t\t" + jobPoint.UsePoint + "\n";
						text += hobbyPoint.Name + "\t" + hobbyPoint.BasePoint + "\t\t" + hobbyPoint.AddPoint + "\t\t" + hobbyPoint.UsePoint + "\n";

						text += "\n種別\t名称\t\t\t初期値\t職業値\t趣味値\t加算値\t合計値\n";
						foreach (var hs in holdingSkills)
						{
							text += hs.Type + "\t" + hs.Name + "\t\t\t" + hs.BasePoint + "\t\t" + hs.JobPoint + "\t\t" + hs.HobbyPoint + "\t\t" + hs.AddPoint + "\t\t" + hs.SumPoint + "\n";
						}

						sr.Write(text);
					}
				}
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
			return null;
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
			addHoldingSkill(skill);
		}

		private bool addHoldingSkill(SkillData skill, string name = null)
		{
			if (skill.check && getHoldingSkill(skill) != null) return false;
			var holdingSkill = new HoldingSkill(skill, new PropertyChangedEventHandler(SkillPointChanged));
			if(name != null) holdingSkill.Name = name;
			holdingSkills.Add(holdingSkill);
			updateHoldingSkills();
			return true;
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
			knowPoint.BasePoint = eduPoint.SumPoint * 5;

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
