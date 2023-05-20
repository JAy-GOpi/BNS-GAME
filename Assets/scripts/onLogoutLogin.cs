
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class onLogoutLogin : MonoBehaviour
{
    public GameObject logoutButton;
    public GameObject loginButton;
    public GameObject deleteButton;
    public Text Uname;

    // Start is called before the first frame update

    private void Start()
    {
        /*if (PlayerPrefs.GetInt("LoggedIn") == 1)
        {
            logoutButton.SetActive(true);
            loginButton.SetActive(false);
        }*/
        if (DBmanager.getLoggedIn() == true)
        {
            logoutButton.SetActive(true);
            loginButton.SetActive(false);
        }
        else
        {
            logoutButton.SetActive(false);
            loginButton.SetActive(true);
        }
    }

    public void Logout()
    {
        //PlayerPrefs.SetInt("LoggedIn", 0);
        DBmanager.setLoggedIn(false);
        //PlayerPrefs.SetString("uNme", null);
        DBmanager.setUname(null);
        //PlayerPrefs.SetString("uPss", null);
        logoutButton.SetActive(false);
        loginButton.SetActive(true);
        Uname.text = null;

    }

    [System.Obsolete]
    public void deleteA()
    {
        StartCoroutine(deleteAcc());
        //deleteButton.SetActive(false);
        //deleteButton.SetActive(true);
        Uname.text = null;
    }

    
    [System.Obsolete]
    private IEnumerator deleteAcc()
    {
        WWWForm form = new WWWForm();
        WWW www = new WWW("http://localhost/sqlconnect/delete.php", form);
        form.AddField("name", Uname.text);
        yield return www;
        Debug.Log(www.text);
        
    }
    public void LogIN()
    {
        
        SceneManager.LoadScene("LoginScreen");
    }
}
