using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCGameTitle : UIBase
{
    GameManager gameManager;

    public SCGameTitle() : base("SCGameTitle", UIGroup.MainScene)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        gameManager.soundManager.defsound1();
        switch (name)
        {
            case "SCGameTitle":
                {
                    gameManager.scenes = 1;
                    UIController.instance.Replace(new UIBase[] { new SCHeader(), new SCHoneypot(), new SCCharbox(), new SCPoint() });
                    return true;
                }
        }
        return false;
    }
}
