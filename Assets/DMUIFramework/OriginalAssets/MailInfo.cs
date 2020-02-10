using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniMail;

public class MailInfo : MonoBehaviour
{
    public void SendMail()
    {
        string text = GameObject.Find("SendText").GetComponent<Text>().text;
        Mail.Send("seiju1213@gmail.com", "セキュキャラ（お問い合わせ)", text);
    }
}
