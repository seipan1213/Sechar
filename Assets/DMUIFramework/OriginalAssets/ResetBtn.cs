using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResetBtn : MonoBehaviour
{
    public void Onclick() {
        GameManager gamemanagaer = GameObject.Find("GameManager").GetComponent<GameManager>();
        gamemanagaer.Reset();
    }
}
