using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DM;

public class SCOther : UIBase
{
    GameManager gameManager;

    public SCOther() : base("SCOther", UIGroup.MainScene)
    {

    }
    public override IEnumerator OnLoaded()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.scenes = 4;
        yield break;
    }

}
