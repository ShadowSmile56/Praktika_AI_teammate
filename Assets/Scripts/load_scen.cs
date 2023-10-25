using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class load_scen : MonoBehaviour
{
    public int d = 8;
    public int b = 8;
    public int ds(int b = 0)
    {
        int sum = d * b;
        return sum;
    }
    public InputField intp_nick;
    public Text Error;
    private int i=0;
    AsyncOperation asyncOperation;

    private void Start()
    {
        b = 10;
        Debug.Log(ds(6));
    }
    public void LoadScene(int Game)
    {
        StartCoroutine(LoadSceneCor(Game));
    }
    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Escape) && i==0)
        {
            Cursor.visible = true;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.Escape)&& i ==1)
        {
            Cursor.visible = false;
            i--;
        }

    }
    public void LoadGame(int Game)
    {
        if (PlayerPrefs.GetString("nickname") != "")
        {
            print(intp_nick.text);
            SceneManager.LoadScene(Game);
            Error.gameObject.SetActive(false);
        }
        else
        {
            Error.gameObject.SetActive(true);
        }
        
    }
    IEnumerator LoadSceneCor(int SceneID)
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(SceneID);
    }
    public void Exit() {

        Application.Quit();
    }
}
