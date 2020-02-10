using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bookimage : MonoBehaviour
{
    GameManager gameManager;
    Image image;
    Text natext;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        image = GetComponent<Image>();
        natext = gameObject.transform.Find("Text").GetComponent<Text>();
        if (gameManager.characters[int.Parse(this.gameObject.name)].sum > 0)
        {
            image.sprite = gameManager.characters[int.Parse(this.gameObject.name)].image;
            natext.text = gameManager.characters[int.Parse(this.gameObject.name)].na;
        }
    }
}
