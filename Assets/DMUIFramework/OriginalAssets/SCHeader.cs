using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCHeader : UIBase
{
    GameManager gameManager;

    public SCHeader() : base("SCHeader", UIGroup.Floater, UIPreset.BackVisible | UIPreset.BackTouchable)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        gameManager.soundManager.defsound1();
        switch (name)
        {
            case "Honeypot":
                {
                    if (gameManager.scenes != (int)(GameManager.SCENE.HONEY))
                    {
                        UIController.instance.Replace(new UIBase[] { new SCHoneypot(), new SCCharbox(), new SCPoint() }, new UIGroup[] { UIGroup.Scene });
                    }
                    return true;
                }
            case "Castom":
                {
                    if (gameManager.scenes != (int)(GameManager.SCENE.CASTOM))
                    {
                        UIController.instance.Replace(new UIBase[] { new SCCastom(), new SCCastomBtn(), new SCPoint() });
                    }
                    return true;
                }
            case "Data":
                {
                    if (gameManager.scenes != (int)(GameManager.SCENE.DATA))
                    {
                        UIController.instance.Replace(new UIBase[] { new SCDate(), new SCBook() }, new UIGroup[] { UIGroup.Scene });
                    }
                    return true;
                }
            case "Other":
                {
                    if (gameManager.scenes != (int)(GameManager.SCENE.OTHER))
                    {
                        UIController.instance.Replace(new UIBase[] { new SCOther(), new SCOtherBtn()});
                    }
                    return true;
                }

        }
        return false;
    }

}
