using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DM;

public class SCGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIController.instance.Implement(new PrefabLoader(), new Sounder(), new FadeCreator());
        UIController.instance.AddFront(new SCGameTitle());
    }
}
