using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCIDSLv : UIBase
{
    GameManager gameManager;


    public SCIDSLv() : base("SCIDSLv", UIGroup.Scene, UIPreset.BackVisible)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        gameManager.soundManager.defsound1();
        if (name == "201")
        {
            UIController.instance.AddFront(new SCOr(2, 0));
            return true;
        }
        else if (name == "202")

        {
            UIController.instance.AddFront(new SCOr(2, 1));
            return true;
        }
        else if (name == "203" && gameManager.potflag[2, 1] == 1)
        {
            UIController.instance.AddFront(new SCOr(2, 2));
            return true;
        }
        else if (name == "204" && gameManager.potflag[2, 2] == 1)
        {
            UIController.instance.AddFront(new SCOr(2, 3));
            return true;
        }
        switch (name)
        {
            case "Back":
                {
                    UIController.instance.AddFront(new SCCastomBtn());
                    UIController.instance.Remove(this);
                    return true;
                }
            default:
                return false;
        }
    }
}
