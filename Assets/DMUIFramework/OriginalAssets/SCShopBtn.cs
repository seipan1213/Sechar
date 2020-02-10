using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCOtherBtn : UIBase
{

    GameManager gameManager;

    public SCOtherBtn() : base("SCOtherBtn", UIGroup.Scene, UIPreset.BackVisible)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        gameManager.soundManager.defsound1();
        switch (name)
        {
            case "PotType":
                {
                    UIController.instance.AddFront(new SCPotType());
                    UIController.instance.Remove(this);
                    return true;
                }
            case "Potmold":
                {
                    UIController.instance.AddFront(new SCPotmold());
                    UIController.instance.Remove(this);
                    return true;
                }
            case "Vulner":
                {
                    UIController.instance.AddFront(new SCVulner());
                    UIController.instance.Remove(this);
                    return true;
                }
            case "Back":
                {
                    UIController.instance.Replace(new UIBase[] { new SCOtherBtn() });
                    return true;
                }

        }
        return false;
    }

}
