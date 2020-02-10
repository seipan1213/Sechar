using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DM;
public class SCCMove : MonoBehaviour
{

    private Animator Anim;

    float count = 1;
    Vector2 navpoint;
    bool isnav = false;
    private float rad;
    Vector2 target;
    private Vector2 speed = new Vector2(2, 2);
    int rand;
    RectTransform rect;
    float Direction;

    GameManager gameManager;
    SCChar ch;
    public bool istouch = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Anim = this.gameObject.transform.GetComponent<Animator>();
        rect = GetComponent<RectTransform>();
        rect.localPosition = new Vector2(Random.Range(200, 650), Random.Range(300, 650));

    }

    void FixedUpdate()
    {
        if (istouch)
        {
            Collection();
            return;
        }
        if ((int)GameManager.SCENE.HONEY != gameManager.scenes)
        {
            gameManager.SetOb(this.gameObject);
        }
        count -= Time.deltaTime;
        if (count < 0 && !isnav)
        {
            rand = Random.Range(0, 2);
            if (rand == 0)
            {
                isnav = true;
                target = new Vector2(Random.Range(200, 650), Random.Range(300, 650));
                rad = Mathf.Atan2(target.y - rect.localPosition.y, target.x - rect.localPosition.x);
            }
            count = 1;
        }
        if (isnav)
        {
            navpoint = rect.localPosition;
            navpoint.x += speed.x * Mathf.Cos(rad);
            navpoint.y += speed.y * Mathf.Sin(rad);
            rect.localPosition = new Vector2(navpoint.x, navpoint.y);
            Direction = target.x - rect.localPosition.x;
            if (Vector2.Distance(rect.localPosition, target) < 1) 
            {
                isnav = false;
                count = 1;
            }
            Anim.speed = 1.0f;
            Anim.SetFloat("x", Direction);

        }
        else
        {
            Anim.SetFloat("y", -1);

        }
    }
    public void Collection()
    {
        navpoint = rect.anchoredPosition;
        navpoint.x += speed.x * Mathf.Cos(rad);
        navpoint.y += speed.y * Mathf.Sin(rad);
        rect.anchoredPosition = new Vector2(navpoint.x, navpoint.y);
        if (Vector2.Distance(rect.anchoredPosition, gameManager.collect.anchoredPosition) < 2)
        {
            UIController.instance.Remove(ch);
        }
        speed = new Vector2(4, 4);

        Anim.SetFloat("y", -1);
    }
    public void Startco(SCChar ch)
    {
        this.ch = ch;
        istouch = true;
        rad = Mathf.Atan2(gameManager.collect.anchoredPosition.y - rect.anchoredPosition.y, gameManager.collect.anchoredPosition.x - rect.anchoredPosition.x);
        Debug.Log(gameManager.collect.anchoredPosition + "BOXの");
        Debug.Log(rect.anchoredPosition);

    }

}
