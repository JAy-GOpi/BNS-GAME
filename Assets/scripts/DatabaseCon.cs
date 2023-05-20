using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DatabaseCon : MonoBehaviour
{
    public InputField LoginName,LoginPassword;
    public Toggle remember;
    public Text errorMessage;
    private int levelOnline;
    private int levelOnline1;
    private int levelOnline2;
    private int levelOffline;
    private int levelOffline1;
    private int levelOffline2;
    
    [System.Obsolete]
    
    public void LoginUser()
    {
        if(string.IsNullOrEmpty(LoginName.text) || string.IsNullOrEmpty(LoginPassword.text))
        {
            Debug.Log("empty fields");
            errorMessage.text = "*Fill all above Fields";
            return;
        }
        else
        {
            StartCoroutine(Login());
        }
    }

    

    [System.Obsolete]
    private IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", LoginName.text);
        form.AddField("password", LoginPassword.text);

        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;

        if ((www.text.Split('\t')[0]) == "0")
        {
            levelOnline= int.Parse(www.text.Split('\t')[1]);
            levelOnline1= int.Parse(www.text.Split('\t')[2]);
            levelOnline2= int.Parse(www.text.Split('\t')[3]);
            //levelOffline = PlayerPrefs.GetInt("levelsUnlocked");
            levelOffline = DBmanager.getLevel(0);
            levelOffline1 = DBmanager.getLevel(1);
            levelOffline2 = DBmanager.getLevel(2);
            //PlayerPrefs.SetInt("LoggedIn", 1);
            DBmanager.setLoggedIn(true);
            //PlayerPrefs.SetString("uNme", LoginName.text);
            DBmanager.setUname(LoginName.text);
            //PlayerPrefs.SetString("uPss", LoginPassword.text);
            if (remember.isOn)
            {
                //PlayerPrefs.SetInt("remember", 1);
                DBmanager.setRemember(true);                
            }
            else
            {
                //PlayerPrefs.SetInt("remember", 0);
                DBmanager.setRemember(false);
            }
            if (levelOnline >= levelOffline)
            {
                //PlayerPrefs.SetInt("levelsUnlocked", levelOnline);
                DBmanager.setLevel(levelOnline,0);
            }
            if (levelOnline1 >= levelOffline)
            {
                //PlayerPrefs.SetInt("levelsUnlocked", levelOnline);
                DBmanager.setLevel(levelOnline2,1);
            }
            if (levelOnline2 >= levelOffline)
            {
                //PlayerPrefs.SetInt("levelsUnlocked", levelOnline);
                DBmanager.setLevel(levelOnline2,2);
            }
            else
            {
                //php script to set level
                StartCoroutine(levelManage());
                Debug.Log("php");

            }
            
            SceneManager.LoadScene("TitleScreen");
        }
        else
        {
            Debug.Log("failed LogIn #" + www.text);
            errorMessage.text = www.text;
        }

    }

    [System.Obsolete]
    private IEnumerator levelManage()
    {
        WWWForm form = new WWWForm();
        //form.AddField("lev", PlayerPrefs.GetInt("levelsUnlocked"));
        //form.AddField("uname", PlayerPrefs.GetString("uNme"));
        form.AddField("lev", DBmanager.getLevel(0));
        form.AddField("lev1", DBmanager.getLevel(1));
        form.AddField("lev2", DBmanager.getLevel(2));
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
}
