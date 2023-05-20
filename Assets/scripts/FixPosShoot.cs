using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class FixPosShoot : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bullet;
    public Rigidbody2D rb;
    Vector3 moveDirection;
    public float fireRate;
    float nextFire;
    Player targetPlayer;
    public bool followPlayer;
    public bool faceePlayer;

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindObjectOfType<Player>();
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        timeToFire();
        if (faceePlayer == true)
        {
            facePlayer();
        }
        if (followPlayer == true)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        if (targetPlayer == null)
        {
            return;
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();
            targetPlayer = GameObject.FindObjectOfType<Player>();
            moveDirection = (targetPlayer.transform.position - transform.position).normalized * moveSpeed;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
    }


    private void facePlayer()
    {
        if(targetPlayer==null)
        {
            return;
        }
        else
        {
            Vector3 playerPoz = targetPlayer.transform.position;

            Vector2 dirction = new Vector2(
                playerPoz.x - transform.position.x,
                playerPoz.y - transform.position.y
                );
            transform.up = dirction;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            WaitLoadScene();
        }
    }
    private void timeToFire()
    {
        if (Time.time > nextFire && targetPlayer != null)
        {
            bullet.SetActive(true);
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
    private void  WaitLoadScene()
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
