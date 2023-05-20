using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int levelsUnlocked;
    int levelsUnlocked1;
    int levelsUnlocked2;
    public int section;
    public Button[] buttons=null;

    // Start is called before the first frame update
    void Start()
    {
        //levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked",1);
        levelsUnlocked = DBmanager.getLevel(section);
        

        
            for (int i = 0; i < buttons.Length; i++)
            {


                buttons[i].interactable = false;
                buttons[i].GetComponent<Image>().color = new Color32(54, 86, 99, 255);
            }

            for (int i = 0; i < levelsUnlocked; i++)
            {
                if (i == buttons.Length)
                {

                    return;

                }
                buttons[i].interactable = true;
                buttons[i].GetComponent<Image>().color = new Color32(36, 107, 132, 255);
            }

        
       
        
    }

    
}
