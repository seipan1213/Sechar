using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCPot : UIBase
{
    GameManager gameManager;


    public SCPot() : base("SCPot", UIGroup.Scene, UIPreset.BackVisible)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        gameManager.soundManager.defsound1();
        if (name == "1")
        {
            UIController.instance.AddFront(new SCOr(0, 0));
            return true;
        }
        else if (name == "2")
        {
            UIController.instance.AddFront(new SCOr(0, 1));
            return true;
        }
        else if (name == "3" && gameManager.potflag[0, 1] == 1)
        {
            UIController.instance.AddFront(new SCOr(0, 2));
            return true;
        }
        else if (name == "4" && gameManager.potflag[0, 2] == 1)
        {
            UIController.instance.AddFront(new SCOr(0, 3));
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
