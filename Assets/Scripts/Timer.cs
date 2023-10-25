using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public bool IsDone;
    public bool TimeDown = true;
    public int Hour = 0;
    public int Min = 2;
    public int Secound = 30;
    public Text Timers;
    public GameObject Exit;
    Transform player;
    float messageRange = 3;
    public Text Hint;
    public KeyCode wakeUp;
    private void Start()
    {
        //Timers = GetComponent<Text>();
        print (Timers);
        print(PlayerPrefs.GetString ("record"));
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Hour <= 0 && Min <= 0 && Secound <= 0)
        {
            IsDone = true;

            if (SceneManager.GetActiveScene().name == "Scene1")
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                PlayerPrefs.SetString("rectime", Timers.text);
                SceneManager.LoadScene(3);
            }
        }
        if (IsDone == false)
        {
            if (Hour <10 && Secound < 10 && Min < 10)
            {
                Timers.text = "0"+ Hour + ":0" + Min + ":0" + Secound;
            }
            else if (Hour < 10 && Min < 10)
            {
                Timers.text = "0" + Hour + ":0" + Min + ":" + Secound;
            }
            else if (Hour < 10)
            {
                Timers.text = "0" + Hour + ":" + Min + ":" + Secound;
            }
            else if (Min < 10)
            {
                Timers.text = Hour + ":0" + Min + ":" + Secound;
            }
            else if (Secound < 10)
            {
                Timers.text = Hour + ":" + Min + ":0" + Secound;
            }
            else
            {
                Timers.text = Hour + ": " + Min + ":" + Secound;
            }
            if (TimeDown == true)
            {
                Invoke("Time", 1f);
                TimeDown = false;
            }
            if (Secound > 60)
            {
                Min++;
                Secound = 1;
            }
            if (Min > 60)
            {
                Hour++;
                Min = 0;
            }
            if (Secound < 0)
            {
                Min--;
                Secound = 59;
            }
            if (Min < 0)
            {
                Hour--;
                Min = 59;
            }
        }
        float distance = Vector3.Distance(Exit.transform.position, player.position);
        if (distance <=messageRange)
        {
            Hint.text = "Выход, нажмите[E]";
            Hint.gameObject.SetActive(true);
            if (Input.GetKeyUp(wakeUp))
            {
                if (SceneManager.GetActiveScene().name == "Scene1")
                {
                    SceneManager.LoadScene(2);
                }
                else
                {
                    
                    PlayerPrefs.SetString("rectime", Timers.text);
                    SceneManager.LoadScene(3);
                }
            }
        }
        else
        {
            Hint.gameObject.SetActive(false);
        }
    }
    void Time()
    {
        Secound--;
        TimeDown = true;
    }
    public void Records()
    {
        PlayerPrefs.SetString("record", Timers.text);
        PlayerPrefs.Save();
        SceneManager.LoadScene(4);

    }
}
