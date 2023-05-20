using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{

    //public Text levelNext;
    public string lev="";
    public string Section="";
    public string scenes="";
    void Start()
    {
        //int levelCurrent = SceneManager.GetActiveScene().buildIndex;
    }

    public void loadCurrentLevel()
    {
        //Debug.Log("current level");
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);
        //Debug.Log(Section);
        //Debug.Log(lev);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync($"Scenes/Lvl {Section}/{lev}");
    }
    public void loadNextLevel()
    {
        //string path=SceneManager.GetActiveScene().name;
        //string tempLevel=(int.Parse(lev) + 1).ToString();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        SceneManager.LoadSceneAsync($"Scenes/Lvl {Section}/{lev}");
    }

    public void OpenScene()
    {
        if (scenes != "")
        {
            SceneManager.LoadScene(scenes);
        }
        else if (lev != "")
        {
            //SceneManager.LoadScene($"Level {lev}");
            SceneManager.LoadSceneAsync($"Scenes/Lvl {Section}/{lev}");
            Debug.Log(Section);
            Debug.Log(lev);

        }
        else
        {
            /*if (PlayerPrefs.GetInt("remember") == 0)
            {
                PlayerPrefs.SetInt("LoggedIn", 0);
                DBmanager.setLoggedIn(false);
                PlayerPrefs.SetString("uNme", null);
                DBmanager.setUname(null);
                //PlayerPrefs.SetString("uPss", null);
            }*/
            
            if (DBmanager.getRemember() == false)
            {
                //PlayerPrefs.SetInt("LoggedIn", 0);
                DBmanager.setLoggedIn(false);
                //.SetString("uNme", null);
                DBmanager.setUname(null);
                //PlayerPrefs.SetString("uPss", null);
            }
            Application.Quit();
            Debug.Log("appquit");
        }
        
    }
    private void OnApplicationQuit()
    {
        /*if (PlayerPrefs.GetInt("remember") == 0)
        {
            PlayerPrefs.SetInt("LoggedIn", 0);
            DBmanager.setLoggedIn(false);
            PlayerPrefs.SetString("uNme", null);
            DBmanager.setUname(null);
            //PlayerPrefs.SetString("uPss", null);
        }*/
        
        if (DBmanager.getRemember() == false)
        {
            //PlayerPrefs.SetInt("LoggedIn", 0);
            DBmanager.setLoggedIn(false);
            //PlayerPrefs.SetString("uNme", null);
            DBmanager.setUname(null);
            //PlayerPrefs.SetString("uPss", null);
        }
    }

}
