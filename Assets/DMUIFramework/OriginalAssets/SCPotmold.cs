using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCPotmold : UIBase
{
    GameManager gameManager;


    public SCPotmold() : base("SCPotmold", UIGroup.Scene, UIPreset.BackVisible)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        gameManager.soundManager.defsound1();
        if (name == gameManager.potdate[1, 0])
        {
            UIController.instance.AddFront(new SCOr(1, 0));
            return true;
        }
        else if (name == gameManager.potdate[1, 1])
        {
            UIController.instance.AddFront(new SCOr(1, 1));
            return true;
        }
        else if (name == gameManager.potdate[1, 2])
        {
            UIController.instance.AddFront(new SCOr(1, 2));
            return true;
        }
        else if (name == gameManager.potdate[1, 3])
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