using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DM;

public class GameManager : MonoBehaviour
{
    public PotStatus potstatus;
    public List<character> characters = new List<character>();
    public int sumpoint = 0;

    public float savebarvalue;
    public float savebarmax;
    public int bartype;

    public float badtime = 0;
    public float char_time = 0;

    public int[,] potflag = { { 1, 0, 0, 0 },
                              { 1, 0, 0, 0 },
                              { 1, 0, 0, 0 },
                              { 1, 0, 0, 0 }};


    public Text pointtext;
    internal string[,] potdate = { { "Webアプリ" ,"Webサーバー","メールサーバー","DNS"},
                                 { "サーバー" ,"一般利用者のPC","スマホ","Webカメラ"},
                                 {"Heartbleed","SSHowDowN","Drupalgeddon 2.0","Certifi-gate"} };


    internal int[,] potprice =   { {100,100,100,100},
                                 { 100,100,100,100},
                                 { 100,100,100,100},
                                 { 100,100,100,100}};

    private string[,] chardate = { {"フィッシング","いつも目の前にあるご飯によだれを垂らしている。（人々を、偽のwebサイトに誘導し個人情報を盗んでいくよ）" },
                                   { "バックドア" ,"いつも同じ扉を出入りしているよ。（一度侵入したところにバックドアを仕掛けて、いつでも侵入できるようにするよ）" },
                                   { "辞書攻撃","いつも自分で書いた辞書を持ち歩いて、困ったときにいつも読んでいる。（辞書の言葉を使用して、パスワードを攻略する）"},
                                   { "ワーム","いつも分身して自分を増やしているよ、でも増やしすぎて体が小さくなっている。（感染するとシステムを破壊し、自身で生き、自身で増殖する）"},
                                   {"トロイの木馬","木馬に乗りこなす子、いつか本物の馬に乗れることを夢見ている。（無害なソフトウェアに見せかけた、何らかのきっかけにより悪意のある活動をするように仕組まれているプログラム"},
                                   { "キーロガー","キーボードが好きでいつもキーボードのことを考えている。（パソコンやキーボードの操作の内容を記録するためのソフトウェア等の総称)"},
                                   { "ハッカー","悪の心を持ちすぎて、顔が崩れてしまった。とりあえずｺﾜｲ。（公開しないシステムの内部に不当に自分の技術でもぐり込んで、いたずらをしたり情報を盗んだりシステムを麻痺(まひ)させる人。）"},
                                   { "ショルダーハッキング","人の画面が気になって、いつも後ろから覗いてくる。（他人がパスワードや暗証番号を入力しているところを、肩越しに盗み見ること。ソーシャルエンジニアリングの一種）"},
                                   {"踏み台攻撃","いつも踏み台の上に居座っている。ほかにすることもないのでただただ突っ立っている。(セキュリティー対策の甘いサイトに不正侵入し、他サイトの攻撃の中継サイトとして利用すること。)"} ,
                                   {"なりすまし","ペンギンの皮をかぶったせきゅ君、割となじんでいる。(第三者が本来の利用者になりすまして不正な行為を働くこと)" },
                                   {"ブルートフォースアタック","なんかとてつもなく強い魔法を放とうとしている。何がでるかは本人ですらわからない。(アカウント・パスワードを解読するため、考えられる全てのパターンを試すこと)" } };

    private Sprite[] charimage;
    private Image dtimage;
    private Text dttext, sumtext, nametext, numtext, unittext;
    public int scenes = 0;

    Text[] typetext = new Text[3];

    Slider slider;
    bool onflag;
    float ontime = 0;
    int bad_every = 600;
    public bool bad;

    int t = 0;

    public bool incident = false;

    public List<GameObject> savechar = new List<GameObject>();

    SaveDate savedate;

    string oldtime = "oldtime";

    internal float leavetime = 0;
    internal float houtitime = 0;
    public List<SCChar> scchars = new List<SCChar>();
    public List<int> id = new List<int>();

    

    public RectTransform collect;
    internal int[] barprice = { 100, 0, 50 };
    internal string[] bartext = { "30分間", "1時間", "4時間" };
    internal int[] char_every = { 4, 10, 20 };
    private int[] _probability = { 100, 50, 30, 20, 10, 5, 1 };
    internal int[] maxchar = { 10, 12, 14, 16, 18, 20, 22, 24 };
    internal float[] _gespeed = { 1, 0.9f, 0.8f, 0.7f, 0.6f, 0.5f };

    private int jikan = 1;//時間経過倍率

    internal Sprite potimage;

    public SoundManager soundManager;
    public enum SCENE
    {
        HONEY = 1,
        CASTOM = 2,
        DATA = 3,
        OTHER = 4
    }
    void Start()
    {
        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("Reset"))
        {
            PlayerPrefs.DeleteAll();
        }
        soundManager = GetComponent<SoundManager>();
        //出現テーブルの初期化
        //ポット状態の初期化
        potstatus = new PotStatus(0, 0, 0, 0);

        potimage = Resources.Load("100", typeof(Sprite)) as Sprite;

        //キャラ画像の初期化
        charimage = new Sprite[chardate.Length / 2];
        charimage[0] = Resources.Load("1", typeof(Sprite)) as Sprite;
        charimage[1] = Resources.Load("2", typeof(Sprite)) as Sprite;
        charimage[2] = Resources.Load("3", typeof(Sprite)) as Sprite;
        charimage[3] = Resources.Load("4", typeof(Sprite)) as Sprite;
        charimage[4] = Resources.Load("5", typeof(Sprite)) as Sprite;
        charimage[5] = Resources.Load("6", typeof(Sprite)) as Sprite;
        charimage[6] = Resources.Load("7", typeof(Sprite)) as Sprite;
        charimage[7] = Resources.Load("8", typeof(Sprite)) as Sprite;
        charimage[8] = Resources.Load("9", typeof(Sprite)) as Sprite;
        charimage[9] = Resources.Load("10", typeof(Sprite)) as Sprite;
        charimage[10] = Resources.Load("11", typeof(Sprite)) as Sprite;

        //キャラの設定            rare度, ポイント, number, 名前,詳細,        画像        生存時間 出現Pot
        characters.Add(new character(0, 1, 1, chardate[0, 0], chardate[0, 1], charimage[0], 1000, 0));
        characters.Add(new character(1, 3, 2, chardate[1, 0], chardate[1, 1], charimage[1], 1000, 0));
        characters.Add(new character(2, 5, 3, chardate[2, 0], chardate[2, 1], charimage[2], 1000, 0));
        characters.Add(new character(3, 10, 4, chardate[3, 0], chardate[3, 1], charimage[3], 1000, 0));
        characters.Add(new character(4, 20, 5, chardate[4, 0], chardate[4, 1], charimage[4], 1000, 0));
        characters.Add(new character(5, 30, 6, chardate[5, 0], chardate[5, 1], charimage[5], 1000, 0));
        characters.Add(new character(6, 50, 7, chardate[6, 0], chardate[6, 1], charimage[6], 1000, 0));
        characters.Add(new character(7, 100, 8, chardate[7, 0], chardate[7, 1], charimage[7], 1000, 0));
        characters.Add(new character(0, 300, 9, chardate[8, 0], chardate[8, 1], charimage[8], 1000, 1));
        characters.Add(new character(0, 500, 10, chardate[9, 0], chardate[9, 1], charimage[9], 1000, 2));
        characters.Add(new character(0, 1000, 11, chardate[10, 0], chardate[10, 1], charimage[10], 1000, 3));

        //ロードするとこ
        if (PlayerPrefs.HasKey("SEvolume"))
        {
            savedate = new SaveDate(potstatus, characters, sumpoint, savebarvalue, savebarmax, bartype, badtime, char_time, id, potflag);
            leavetime = (int)(DateTime.Now.Ticks / (10000000) - long.Parse(PlayerPrefs.GetString(oldtime)));
            Debug.Log("Time:" + leavetime);
            savedate = loadPlayerData();
            potstatus = savedate.potstatus;
            characters.Clear();
            characters = savedate.characters;
            sumpoint = savedate.sumpoint;
            bartype = savedate.bartype;
            badtime = savedate.badtime;
            char_time = savedate.char_time;
            id = savedate.charevery;


            savebarvalue = savedate.savebarvalue;
            savebarmax = savedate.savebarmax;

            Debug.Log(savebarvalue + "   " + leavetime);
            savebarvalue -= leavetime;

            if (savebarvalue > 0)
            {
                houtitime = leavetime;
            }
            else
            {
                houtitime = savebarvalue;
                badtime = leavetime - savebarvalue;
            }
            Debug.Log(houtitime);
        }
        else//初期の処理
        {
            Debug.Log("new");
            savedate = new SaveDate(potstatus, characters, sumpoint, savebarvalue, savebarmax, bartype, badtime, char_time, id, potflag);
        }
        sumpoint = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        if (onflag)
        {
            slider.value -= ontime;
            ontime = 0;
            badtime = 0;
            char_time -= Time.deltaTime;
            slider.value -= Time.deltaTime*jikan;//時間経過
            if (slider.value <= 0 || (int)SCENE.HONEY != scenes)
            {
                savebarvalue = slider.value;
                savebarmax = slider.maxValue;
                slider.gameObject.SetActive(false);
                onflag = false;
            }
        }
        else
        {
            badtime += Time.deltaTime;
        }
        if (badtime > bad_every)
        {
            BadChange();
        }
        if (!incident && bad && (int)SCENE.HONEY == scenes)
        {
            UIController.instance.AddFront(new SCIncident());
            incident = true;
        }
        if ((int)SCENE.HONEY != scenes)
        {
            ontime += Time.deltaTime;
        }
        Output();
    }

    public void Pluspoint(int p)
    {
        sumpoint += characters[p].point;
        characters[p].sum++;
    }

    private void Output()
    {
        if (scenes != (int)(SCENE.DATA) && scenes != 0 && scenes != (int)(SCENE.OTHER))
        {
            if (pointtext != null)
            {
                pointtext.text = "Point:" + sumpoint.ToString();
            }
            else 
            {
                pointtext = GameObject.Find("Point").GetComponent<Text>();
            }
            if (scenes == (int)(SCENE.HONEY))
            {
                if (typetext[0] != null)
                {
                    typetext[0].text = potstatus.type;
                    typetext[1].text = potstatus.mold;
                    typetext[2].text = potstatus.vulner;
                }
                else
                {
                    typetext[0] = GameObject.Find("type").GetComponent<Text>();
                    typetext[1] = GameObject.Find("mold").GetComponent<Text>();
                    typetext[2] = GameObject.Find("vulner").GetComponent<Text>();
                }
            }
        }
    }
    public void OutDetail(int num)
    {
        if (dtimage == null)
        {
            dtimage = GameObject.Find("dtimage").GetComponent<Image>();
            numtext = GameObject.Find("num").GetComponent<Text>();
            unittext = GameObject.Find("unit").GetComponent<Text>();
            dttext = GameObject.Find("detail").GetComponent<Text>();
            sumtext = GameObject.Find("sum").GetComponent<Text>();
            nametext = GameObject.Find("name").GetComponent<Text>();
        }
        dtimage.sprite = characters[num].image;
        dttext.text = characters[num].detail;
        unittext.text = characters[num].point.ToString();
        numtext.text = "No" + characters[num].number;
        nametext.text = characters[num].na;
        sumtext.text = characters[num].sum.ToString();
    }
    public int Choice()
    {
        int sum = 0;
        var num = new List<int>();
        foreach (var v in characters)
        {
            if (_probability.Length - 1 >= v.rare && v._pottype == potstatus._pot)
            {
                sum += _probability[v.rare];
                num.Add(v.number - 1);
            }
        }
        float rand = UnityEngine.Random.Range(0, sum);
        sum = 0;
        foreach(var v in num)
        {
            sum += _probability[characters[v].rare];
            if (sum > rand)
            {
                return v;
            }
        }
        return 0;
    }
    public void Setbar()
    {
        slider = GameObject.Find("Timebar").GetComponent<Slider>();
        slider.maxValue = savebarmax;
        slider.value = savebarvalue;
        if (slider.value <= 0)
        {
            slider.gameObject.SetActive(false);
        }
        else
        {
            slider.gameObject.SetActive(true);
            onflag = true;
        }
    }

    public void Timebar(int t)
    {
        float ti;
        bartype = t;
        char_time = char_every[bartype] * _gespeed[potstatus._vulnerLv];
        switch (t)
        {
            case 0:
                ti = 60 * 0.5f * 60;
                break;
            case 1:
                ti = 60 * 60;
                break;
            case 2:
                ti = 60 * 4 * 60;
                break;
            default:
                ti = 60 * 60;
                break;
        }
        slider.gameObject.SetActive(true);
        slider.maxValue = ti;
        slider.value = ti;
        onflag = true;
    }
    public void BadChange()
    {
        float rand = UnityEngine.Random.Range(0, 10);
        badtime = 0;
        if (10 >= rand)
        {
            bad = true;
            return;
        }
    }

    public void SetOb(GameObject gm)
    {
        savechar.Add(gm);
        gm.SetActive(false);
    }

    public void OutOb()
    {
        foreach (GameObject gm in savechar)
        {
            gm.SetActive(true);
        }
        savechar.Clear();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString(oldtime, (DateTime.Now.Ticks / 10000000).ToString());
        PlayerPrefs.SetFloat("SEvolume", soundManager.audioSourceSE.volume);
        PlayerPrefs.SetFloat("BGMvolume", soundManager.audioSourceBGM.volume);
        PlayerPrefs.Save();
        savebarvalue = slider.value;
        savebarmax = slider.maxValue;
        id.Clear();
        for (int i = 0; i < scchars.Count; i++)
        {
            id.Add(scchars[i].type);

            Debug.Log(id[i]);
        }
        savedate = new SaveDate(potstatus, characters, sumpoint, savebarvalue, savebarmax, bartype, badtime, char_time, id, potflag);
        savePlayerData(savedate);
        Debug.Log("save");
    }
    public void savePlayerData(SaveDate sv)
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(sv);

        writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }
    public SaveDate loadPlayerData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "/savedata.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<SaveDate>(datastr);
    }

    public void charsAdd(SCChar c)
    {
        scchars.Add(c);
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Reset", 1);
    }
}
[Serializable]
public class character
{
    public int rare;
    public int point;
    public int number;
    public int sum = 0;
    public string na;
    public string detail;
    public Sprite image;
    public float life;
    public int _pottype;
    public character(int r, int p, int n, string na, string detail, Sprite image, float life,int _pottype)
    {
        rare = r;
        point = p;
        number = n;
        this.na = na;
        this.detail = detail;
        this.image = image;
        this.life = life;
        this._pottype = _pottype;
    }
}

[Serializable]
public class PotStatus
{
    public string type;
    public string mold;
    public string vulner;
    public int _pot;
    public int _vulnerLv;
    public int _cpacityLv;
    public int _idsLv;
    public PotStatus(int _pot,int _vulnerLv,int _cpacityLv,int _idsLv)
    {
        this._pot = _pot;
        this._vulnerLv= _vulnerLv;
        this._cpacityLv = _cpacityLv;
        this._idsLv = _idsLv;
    }
}
[Serializable]
public class SaveDate{

    public PotStatus potstatus;
    public List<character> characters = new List<character>();
    public int sumpoint = 0;
    public float savebarvalue;
    public float savebarmax;
    public int bartype;
    public float badtime = 0;
    public float char_time = 0;
    public List<int> charevery;
    public int[,] potflag;
    public SaveDate(PotStatus potstatus, List<character> characters, int sumpoint, 
                    float savebarvalue, float savebarmax, int bartype, float badtime, float char_time, List<int> charevery, int[,] potflag)
    {
        this.potstatus = potstatus;
        this.characters = characters;
        this.sumpoint = sumpoint;
        this.savebarvalue = savebarvalue;
        this.savebarmax = savebarmax;
        this.bartype = bartype;
        this.badtime = badtime;
        this.char_time = char_time;
        this.charevery = charevery;
        this.potflag = potflag;
    }

}
