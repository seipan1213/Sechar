using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCVulnerLv : UIBase
{
    GameManager gameManager;

    public SCVulnerLv() : base("SCVulnerLv", UIGroup.Scene, UIPreset.BackVisible)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        gameManager.soundManager.defsound1();
        if (name == "301")
        {
            UIController.instance.AddFront(new SCOr(3, 0));
            return true;
        }
        else if (name == "302")
        {
            UIController.instance.AddFront(new SCOr(3, 1));
            return true;
        }
        else if (name == "303" && gameManager.potflag[3, 1] == 1)
        {
            UIController.instance.AddFront(new SCOr(3, 2));
            return true;
        }
        else if (name == "304" && gameManager.potflag[3, 2] == 1)
        {
            UIController.instance.AddFront(new SCOr(3, 3));
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
