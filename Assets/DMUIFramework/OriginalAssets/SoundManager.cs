using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] AudioClip defclick1, defclick2, bgm;
    internal AudioSource audioSourceSE,audioSourceBGM;
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audioSourceSE = audioSources[0];
        audioSourceBGM = audioSources[1];

        bgm = Resources.Load("Sound/bgm", typeof(AudioClip)) as AudioClip;
        audioSourceBGM.clip = bgm;
        audioSourceBGM.loop = true;
        audioSourceBGM.Play();
        if (PlayerPrefs.HasKey("oldtime"))
        {
            audioSourceSE.volume = PlayerPrefs.GetFloat("SEvolume");
            audioSourceBGM.volume = PlayerPrefs.GetFloat("BGMvolume");
        }
    }

    public void defsound1()
    {
        audioSourceSE.PlayOneShot(defclick1);
    }
    public void defsound2()
    {
        audioSourceSE.PlayOneShot(defclick2);
    }
}
