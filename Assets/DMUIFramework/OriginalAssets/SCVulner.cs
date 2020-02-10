using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCVulner : UIBase
{
    GameManager gameManager;


    public SCVulner() : base("SCVulner", UIGroup.Scene, UIPreset.BackVisible)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        gameManager.soundManager.defsound1();
        if (name == gameManager.potdate[2, 0])
        {
            UIController.instance.AddFront(new SCOr(2, 0));
            return true;
        }
        else if (name == gameManager.potdate[2, 1])
        {
            UIController.instance.AddFront(new SCOr(2, 1));
            return true;
        }
        else if (name == gameManager.potdate[2, 2])
        {
            UIController.instance.AddFront(new SCOr(2, 2));
            return true;
        }
        else if (name == gameManager.potdate[2, 3])
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
