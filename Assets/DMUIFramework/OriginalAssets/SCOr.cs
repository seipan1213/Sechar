using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DM;

public class SCOr : UIBase
{
    GameManager gameManager;

    int type;
    int type2;
    Text text;
    int _or = 0;
    public SCOr(int t, int level) : base("SCOr", UIGroup.Dialog, UIPreset.BackVisible)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        type = t;
        type2 = level;
    }
    public SCOr(int t) : base("SCOr", UIGroup.Dialog, UIPreset.BackVisible)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _or = 1;
        type = t;

    }

    public override void OnActive()
    {
        text = GameObject.Find("Buytext").GetComponent<Text>();
        if (_or == 0)
        {
            if (gameManager.potflag[type, type2] == 0)
            {
                text = GameObject.Find("Buytext").GetComponent<Text>();
                text.text = string.Format("価格は{0}です。購入しますか", gameManager.potprice[type, type2]);
            }
        }else if (_or == 1)
        {
            text.text = string.Format("{0}セキュキャラが集まってきます。価格は{1}です。使用しますか？", gameManager.bartext[type], gameManager.barprice[type]);
        }
    }
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {

        gameManager.soundManager.defsound1();
        switch (name)
        {
            case "OK":
                {
                    if (_or == 0)
                    {
                        if (gameManager.potflag[type, type2] == 0)
                        {
                            if (gameManager.sumpoint >= gameManager.potprice[type, type2])
                            {
                                gameManager.sumpoint -= gameManager.potprice[type, type2];
                                Debug.Log(gameManager.sumpoint);
                                gameManager.potflag[type, type2] = 1;
                            }
                            else
                            {
                                text.text = "ポイント不足です";
                                root.Find("OK").gameObject.SetActive(false);
                                return true;
                            }
                        }

                        if (type == 0)
                        {
                            gameManager.potstatus._pot = type2;
                        }
                        else if (type == 1)
                        {
                            gameManager.potstatus._cpacityLv = type2;
                        }
                        else if (type == 2)
                        {
                            gameManager.potstatus._idsLv = type2;
                        }
                        else
                        {
                            gameManager.potstatus._vulnerLv = type2;
                        }
                    }
                    else
                    {
                        if (gameManager.sumpoint >= gameManager.barprice[type])
                        {
                            gameManager.sumpoint -= gameManager.barprice[type];
                            gameManager.Timebar(type);
                            Debug.Log(gameManager.sumpoint);
                        }
                        else
                        {
                            text.text = "ポイント不足です";
                            root.Find("OK").gameObject.SetActive(false);
                            return true;
                        }

                    }
                    UIController.instance.Back();
                    return true;
                }
            case "NO":
                {
                    UIController.instance.Back();
                    return true;
                }

            default:
                return false;
        }

    }
}
