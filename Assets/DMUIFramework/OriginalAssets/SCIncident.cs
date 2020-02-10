using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCIncident : UIBase
{
    GameManager gameManager;

    public SCIncident() : base("SCIncident", UIGroup.System, UIPreset.BackVisible | UIPreset.BackTouchable)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        gameManager.soundManager.defsound1();
        switch (name)
        {
            case "repair":
                gameManager.sumpoint /= 2;
                UIController.instance.Remove(this);
                gameManager.badtime = 0;
                gameManager.incident = false;
                gameManager.bad = false;

                return true;
            default:
                return false;
        }
    }
}
