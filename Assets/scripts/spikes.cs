using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class spikes : MonoBehaviour
{
    
    
    
    public Animator transition;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Destroy(collision.gameObject);
            WaitLoadScene();
            
        }
    }

    public void WaitLoadScene()
    {
        //int currentLevel = SceneManager.GetActiveScene().buildIndex;
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        transition.SetTrigger("TranEnd");
        //yield return new WaitForSeconds(0.5f);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        //SceneManager.LoadScene(currentLevel);
    }

}
