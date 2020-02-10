using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DM;

public class SCBook : UIBase
{

    int pages = 1;
    GameManager gameManager;
    RectTransform panel;
    public SCBook() : base("SCBook", UIGroup.Scene, UIPreset.BackVisible)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public override IEnumerator OnLoaded()
    {
        panel = root.Find("Panel/page").GetComponent<RectTransform>();
        yield break;
    }
    public override bool OnClick(string name, GameObject gameObject, PointerEventData pointer, SE se)
    {
        switch (name)
        {
            case "0":
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "10":
            case "11":
                if (gameManager.characters[int.Parse(name)].sum > 0)
                {
                    UIController.instance.AddFront(new SCCDetail(this, int.Parse(name)));
                    gameManager.soundManager.defsound1();
                }
                return true;
            

            case "Next":
                {
                    if (pages < 3)
                    {
                        gameManager.soundManager.defsound1();
                        pages++;
                        Page(pages);
                    }
                    return true;
                }
            case "Back":
                {
                    if (pages > 1)
                    {
                        gameManager.soundManager.defsound1();
                        pages--;
                        Page(pages);
                    }
                    return true;
                }
            default:

                return false;
        }
    }
    private void Page(int p)
    {
        panel.anchoredPosition = new Vector3(-800 * (p - 1), 0, 0);
    }
}
