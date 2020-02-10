using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castamimage : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;
    Image image;
    Text natext;
    int type, num;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        image = GetComponent<Image>();
        natext = gameObject.transform.Find("Text").GetComponent<Text>();
        //natext.text = (int.Parse(this.gameObject.name) % 100).ToString();
        type = int.Parse(this.gameObject.name) / 100;
        num = int.Parse(this.gameObject.name) % 100 - 1;

    }
    void Update()
    {
        if (num == 0)
        {
            image.sprite = gameManager.potimage;
        }
        else if (gameManager.potflag[type, num - 1] == 1)
        {
            image.sprite = gameManager.potimage;
        }
        switch (type)
        {
            case 0:
                if (gameManager.potstatus._pot == num)
                    image.color = Color.red;
                else image.color = Color.cyan;
                break;
            case 1:
                if (gameManager.potstatus._cpacityLv == num)
                    image.color = Color.red;
                else image.color = Color.cyan;
                break;
            case 2:
                if (gameManager.potstatus._idsLv == num)
                    image.color = Color.red;
                else image.color = Color.cyan;

                break;

            case 3:
                if (gameManager.potstatus._vulnerLv == num)
                    image.color = Color.red;
                else image.color = Color.cyan;
                break;

        }
    }
}
