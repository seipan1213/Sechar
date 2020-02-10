using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCCharbox : UIBase
{
    GameManager gameManager;

    AudioSource audioSource;
    AudioClip defclick;

    public SCCharbox() : base("SCCharbox", UIGroup.Scene, UIPreset.BackVisible)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    public override void OnActive()
    {
        gameManager.collect = GameObject.Find("Box").GetComponent<RectTransform>();
        for (int i = 0; i < gameManager.id.Count; i++)
        {
            Debug.Log("初期");
            UIController.instance.AddFront(new SCChar(gameManager.id[i]));
        }
        while (gameManager.houtitime > 0 && gameManager.scchars.Count < gameManager.maxchar[gameManager.potstatus._cpacityLv])
        {
            Debug.Log("生成"+ gameManager.scchars.Count);
            gameManager.houtitime -= gameManager.char_time;
            if (gameManager.houtitime < 0)
            {
                gameManager.houtitime = 0;
            }
            gameManager.char_time = gameManager.char_every[gameManager.bartype] * gameManager._gespeed[gameManager.potstatus._vulnerLv];;
            UIController.instance.AddFront(new SCChar(gameManager.Choice()));
        }
        gameManager.houtitime = 0;
        gameManager.leavetime = 0;
        gameManager.id.Clear();
        gameManager.Setbar();
        gameManager.OutOb();
        scheduleUpdate = true;
    }

    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        gameManager.soundManager.defsound1();
        switch (name)
        {
            case "30m":
                {
                    UIController.instance.AddFront(new SCOr(0));
                    return true;
                }
            case "1h":
                {
                    UIController.instance.AddFront(new SCOr(1));
                    return true;
                }
            case "4h":
                {
                    UIController.instance.AddFront(new SCOr(2));
                    return true;
                }
            default:
                return false;
        }

    }
    public override void OnUpdate()
    {
        if (gameManager.char_time < 0 && gameManager.scchars.Count < gameManager.maxchar[gameManager.potstatus._cpacityLv])
        {
            Debug.Log("Update");
            UIController.instance.AddFront(new SCChar(gameManager.Choice()));
            gameManager.char_time = gameManager.char_every[gameManager.bartype] * gameManager._gespeed[gameManager.potstatus._vulnerLv]; ;
        }

    }
}
