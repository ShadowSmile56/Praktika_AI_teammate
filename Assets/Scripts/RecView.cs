using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecView : MonoBehaviour
{
    // Start is called before the first frame update
    public Text nick;
    public Text rectime;

    void Start()
    {
        nick.text = PlayerPrefs.GetString("nickname");
        rectime.text = PlayerPrefs.GetString("rectime");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
