using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class displayUser : MonoBehaviour
{
    public Text UserNAme;
    public GameObject bg;
    private void OnApplicationFocus(bool focus)
    {
        string JSONPath = Application.dataPath + "/offlineSaves.json";
        /*if (PlayerPrefs.GetInt("LoggedIn")==1) 
        { 
             UserNAme.text = "User : " + PlayerPrefs.GetString("uNme");  
        }*/
        if (File.Exists(JSONPath) == false)
        {
            DBmanager.createJson();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //bg.GetComponent<Image>().color = randColor();
        if (DBmanager.getLoggedIn() == true)
        { 
            UserNAme.text = "User : " + DBmanager.getUname();  
       }
        
    }
    private Color randColor()
    {

        Color randomColor = new Color(
            UnityEngine.Random.Range(0.59f, .72f), //Red
            UnityEngine.Random.Range(0.59f, .72f), //Green
            UnityEngine.Random.Range(0.59f, .72f), //Blue
            1 //Alpha (transparency)
        );
        return randomColor;
    }
}
