using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NickName : MonoBehaviour
{

    public InputField intp_nick;
    // Start is called before the first frame update
    void Start()
    {
        intp_nick.text = PlayerPrefs.GetString("nickname");
    }

    // Update is called once per frame
    public void Create()
    {
        PlayerPrefs.SetString("nickname", intp_nick.text);
        PlayerPrefs.Save();
    }
}
