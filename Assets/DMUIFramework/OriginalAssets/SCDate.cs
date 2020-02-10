using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DM;
using UnityEngine.EventSystems;

public class SCDate : UIBase
{
    GameManager gameManager;

    public SCDate() : base("SCData", UIGroup.MainScene, UIPreset.BackVisible)
    {

    }
    public override IEnumerator OnLoaded()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.scenes = 3;
        yield break;
    }

}
