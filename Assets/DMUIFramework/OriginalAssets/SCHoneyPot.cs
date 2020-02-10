using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCHoneypot : UIBase
{
    GameManager gameManager;
    public SCHoneypot() : base("SCHoneypot", UIGroup.MainScene ,UIPreset.BackVisible)
    {

    }
    public override IEnumerator OnLoaded()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.scenes = 1;
        yield break;
    }
}
