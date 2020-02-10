using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCCastomBtn : UIBase
{
    GameManager gameManager;

    public SCCastomBtn() : base("SCCastomBtn", UIGroup.Scene, UIPreset.BackVisible)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        gameManager.soundManager.defsound1();

        switch (name)
        {
            //case "PotType":
            //    {
            //        UIController.instance.AddFront(new SCPotType());
            //        UIController.instance.Remove(this);
            //        return true;
            //    }
            //case "Potmold":
            //    {
            //        UIController.instance.AddFront(new SCPotmold());
            //        UIController.instance.Remove(this);
            //        return true;
            //    }
            //case "Vulner":
            //    {
            //        UIController.instance.AddFront(new SCVulner());
            //        UIController.instance.Remove(this);
            //        return true;
            //    }
            case "Pot":
                {
                    UIController.instance.AddFront(new SCPot());
                    UIController.instance.Remove(this);
                    return true;
                }
            case "CapacityLv":
                {
                    UIController.instance.AddFront(new SCCapacityLv());
                    UIController.instance.Remove(this);
                    return true;
                }
            case "IDSLv":
                {
                    UIController.instance.AddFront(new SCIDSLv());
                    UIController.instance.Remove(this);
                    return true;
                }
            case "VulnerLv":
                {
                    UIController.instance.AddFront(new SCVulnerLv());
                    UIController.instance.Remove(this);
                    return true;
                }
        }
        return false;
    }
}

