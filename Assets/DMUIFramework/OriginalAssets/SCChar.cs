using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DM;

public class SCChar : UIBase
{
    GameManager gameManager;

    SCMove move;
    public int type;
    float life;

    public SCChar(int t) : base("SC" + t, UIGroup.Dialog, UIPreset.BackVisible | UIPreset.BackTouchable)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        type = t;
        life = gameManager.characters[type].life;
        Debug.Log(gameManager.scchars.Count+"  " +t);
        life -= gameManager.badtime;
        if (life <= 0)
        {
            UIController.instance.Remove(this);
        }
        else
        {
            gameManager.charsAdd(this);
        }
    }

    public override IEnumerator OnLoaded()
    {
        scheduleUpdate = true;
        root.localScale = Vector3.one * 2.5f;
        yield break;
    }
    public override void OnActive()
    {
        move = root.GetComponent<SCMove>();
    }
    public override void OnUpdate()
    {
        life -= Time.deltaTime;
        if (life <= 0)
        {
            UIController.instance.Remove(this);
        }


    }
    //public override bool OnDrag(string name, GameObject gameObject, PointerEventData pointer)
    //{
    //    gameManager.audioSource.PlayOneShot(gameManager.defclick);
    //    gameManager.Pluspoint(type);
    //    move.Startco(this);
    //    return true;
    //}
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        gameManager.soundManager.defsound1();
        move.Startco(this);
        return true;
    }
    public override void OnDestroy()
    {
        Debug.Log("消えちゃった");
        gameManager.Pluspoint(type);
        gameManager.scchars.Remove(this);
    }

    //public void FlyOrb()
    //{
    //    RectTransform rect = root.GetComponent<RectTransform>();

    //    // オーブの軌跡設定
    //    Vector3[] path = {
    //        new Vector3(rect.localPosition.x * 4.0f, 300f, 0f),
    //        new Vector3(0f, 250f, 0f),
    //    };

    //    // DOTweenを使ったアニメ作成
    //    rect.DOLocalPath(path, 0.5f, PathType.CatmullRom).SetEase(Ease.OutQuad);
    //    // 同時にサイズも変更 
    //    rect.DOScale(new Vector3(0.5f, 0.5f, 0f), 0.5f);
    //}


}
