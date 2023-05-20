using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Signup : MonoBehaviour
{
    public InputField signupPassword, signupCpassword, signupName;
    public Text errorMessage;
    [System.Obsolete]
    public void SignupUser()
    {
        

        if (string.IsNullOrEmpty(signupPassword.text) || string.IsNullOrEmpty(signupCpassword.text) || string.IsNullOrEmpty(signupName.text))
        {
            Debug.Log("empty fields");
            errorMessage.text = "* Fill all above Fields";
            return;
        }
        else if (signupName.text.Length >= 20)
        {
            Debug.Log("uname check");
            errorMessage.text = "* Username must be less than 21 characters";
            return;
        }
        else if (signupPassword.text.Length < 8 || signupCpassword.text.Length < 8)
        {
            Debug.Log("not 8char long");
            errorMessage.text = "* Password must be 8 characters long";
            return;
        }
        else if (signupPassword.text != signupCpassword.text)
        {
            Debug.Log("notmatch");
            errorMessage.text = "* Passwords does not match";
            return;
        }
        else
        {
            StartCoroutine(Register());
        }

    }

    [System.Obsolete]
    private IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", signupName.text);
        form.AddField("password", signupPassword.text);

        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("created");
            SceneManager.LoadScene("LoginScreen");
        }
        else
        {
            Debug.Log("failed creating #" + www.text);
            errorMessage.text = www.text; 
        }
    }
}
