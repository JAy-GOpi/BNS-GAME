using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class straightShoot : MonoBehaviour
{
    // Start is called before the first frame update
    FixPosShoot hex;
    public float moveSpeed;
    public Rigidbody2D rb;
    //public GameObject hex;
    
    private IEnumerator coroutine;
    //public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hex = GameObject.FindObjectOfType<FixPosShoot>();
        rb.transform.rotation= hex.transform.rotation;
        rb.velocity = transform.up*moveSpeed;
        SoundManager.playSound("ball");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");

            WaitLoadScene();
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("wall"))
        {
            gameObject.transform.position = new Vector2(
                transform.position.x + 10000,
                transform.position.y + 10000
                );
            Destroy(gameObject, 1f);
        }
    }

        private void WaitLoadScene()
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            //Print the time of when the function is first called.
            //transition.SetTrigger("TranEnd");

            Debug.Log("Started Coroutine at timestamp : " + Time.time);

            //yield on a new YieldInstruction that waits for .5 seconds.
            //yield return new WaitForSeconds(0.5f);

            //After we have waited 5 seconds print the time again.
            Debug.Log("Finished Coroutine at timestamp : " + Time.time);

            //SceneManager.LoadScene(currentLevel);
        }
    }





