using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCCDetail : UIBase
{
    UIPart m_uip;
    int num;
    GameManager gameManager;

    public SCCDetail(UIPart uip, int num) : base("SCCDetail", UIGroup.Dialog, UIPreset.BackVisible | UIPreset.BackTouchable)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_uip = uip;
        this.num = num;
    }
    public override void OnActive()
    {
        gameManager.OutDetail(num);

    }
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        gameManager.soundManager.defsound1();
        switch (name)
        {
            case "OK":
                UIController.instance.Remove(this);
                return true;
            default:
                return false;
        }
    }
    //public override void OnDestroy()
    //{
    //    UIController.instance.DetachParts(m_ui, new List<UIPart>() { m_uip });
    //}
}
