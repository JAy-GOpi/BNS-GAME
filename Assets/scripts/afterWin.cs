using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class afterWin : MonoBehaviour
{
    public int section;
    public int CurrentLevel;
    public Animator transitionAnim;
    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            WaitLoadScene();
        }
    }

    [System.Obsolete]
    private void WaitLoadScene()
    {
        //int currentLevel = SceneManager.GetActiveScene().buildIndex;
        transitionAnim.SetTrigger("TranEnd");
        
        //yield return new WaitForSeconds(0.5f);

        if (CurrentLevel >= DBmanager.getLevel(section))
        {
            
            //PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
            DBmanager.setLevel(CurrentLevel + 1,section);
            StartCoroutine(levelManage());
        }
        //if (currentLevel == maxLevel) { }
        else
        {
            //SceneManager.LoadScene(currentLevel + 1);
        }
        
        
    }


    [System.Obsolete]
    private IEnumerator levelManage()
    {
        WWWForm form = new WWWForm();
        //form.AddField("lev", PlayerPrefs.GetInt("levelsUnlocked"));
        //form.AddField("uname", PlayerPrefs.GetString("uNme"));
        form.AddField("lev",DBmanager.getLevel(0));
        form.AddField("lev1",DBmanager.getLevel(1));
        form.AddField("lev2",DBmanager.getLevel(2));
        form.AddField("uname", DBmanager.getUname());


        WWW www = new WWW("http://localhost/sqlconnect/levelManager.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("level Updated");

        }
        else
        {
            Debug.Log("failed updating #" + www.text);
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
        }
        */
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
