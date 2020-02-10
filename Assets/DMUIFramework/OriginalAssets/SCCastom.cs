using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCCastom : UIBase
{
    GameManager gameManager;

    public SCCastom() : base("SCCastom", UIGroup.MainScene)
    {

    }
    public override IEnumerator OnLoaded()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.scenes = 2;
        yield break;
    }


}
