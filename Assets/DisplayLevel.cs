using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DisplayLevel : MonoBehaviour
{
    public GameObject nextLevelButton;
    public Text levelNext;
    public Text symbol;
    public int section;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForUpdate());

    }

    IEnumerator waitForUpdate()
    {
        yield return new WaitForSeconds(0.5f);
        levelNext.text = (int.Parse(SceneManager.GetActiveScene().name )+1).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (DBmanager.getLevel(section) > int.Parse(SceneManager.GetActiveScene().name))
        {
            nextLevelButton.GetComponent<Button>().interactable=true;
            symbol.text = "<";
        }
        else
        {
            nextLevelButton.GetComponent<Button>().interactable = false;
            symbol.text = "x";
        }
            
    }
}
