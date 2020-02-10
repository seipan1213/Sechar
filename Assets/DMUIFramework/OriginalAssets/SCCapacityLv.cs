using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCCapacityLv : UIBase
{
    GameManager gameManager;

    public SCCapacityLv() : base("SCCapacityLv", UIGroup.Scene, UIPreset.BackVisible)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        gameManager.soundManager.defsound1();
        if (name == "101")
        {
            UIController.instance.AddFront(new SCOr(1, 0));
            return true;
        }
        else if (name == "102")
        {
            UIController.instance.AddFront(new SCOr(1, 1));
            return true;
        }
        else if (name == "103" && gameManager.potflag[1, 1] == 1)
        {
            UIController.instance.AddFront(new SCOr(1, 2));
            return true;
        }
        else if (name == "104" && gameManager.potflag[1, 2] == 1)
        {
            UIController.instance.AddFront(new SCOr(1, 3));
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
