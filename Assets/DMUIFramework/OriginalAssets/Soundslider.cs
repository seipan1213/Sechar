using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soundslider : MonoBehaviour
{
    GameManager gameManager;
    Slider bgmsl, sesl;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bgmsl = transform.Find("BGMSlider").GetComponent<Slider>();
        sesl = transform.Find("SESlider").GetComponent<Slider>();
        bgmsl.value = gameManager.soundManager.audioSourceBGM.volume;
        sesl.value = gameManager.soundManager.audioSourceSE.volume;
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.soundManager.audioSourceSE.volume = sesl.value;
        gameManager.soundManager.audioSourceBGM.volume = bgmsl.value;
    }
}
