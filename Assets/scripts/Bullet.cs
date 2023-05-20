using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    Player targetPlayer;
    Vector3 moveDirection;
    private IEnumerator coroutine;
    //public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPlayer = GameObject.FindObjectOfType<Player>();
        moveDirection = (targetPlayer.transform.position - transform.position).normalized*moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Vector2 dirction = new Vector2(
            targetPlayer.transform.position.x - transform.position.x,
            targetPlayer.transform.position.y - transform.position.y
            );
        
        transform.up = dirction;
        SoundManager.playSound("shoot");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
            
            WaitLoadScene();
            Destroy(collision.gameObject);
            gameObject.transform.position = new Vector2(
                transform.position.x + 10000,
                transform.position.y + 10000
                );
            //Destroy(gameObject);

        }
        else if (collision.gameObject.CompareTag("wall"))
        {
            gameObject.transform.position= new Vector2(
                transform.position.x+10000,
                transform.position.y+10000
                );
            Destroy(gameObject,1f);
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
