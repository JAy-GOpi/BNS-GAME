using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public bool canMove = false;
    
    
    public Rigidbody2D rb;
    public ParticleSystem ps;
    public GameObject player;
    public GameObject face;
    public Animator camShake;
    public GameObject bg;
    public Animator animationEnd;
    
    Vector3 faceRotation;
    public bool playSound;
    public bool InvertControl;
    RigidbodyConstraints2D OriginalRb;

    // Start is called before the first frame update
    void Start()
    {
        playSound = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        OriginalRb = rb.constraints;
        if (bg != null)
        {
            bg.GetComponent<SpriteRenderer>().color = randColor();
        }
        //faceRotation = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
    }

    

    // Update is called once per frame
    void Update()
    {
        
        if (rb.velocity.magnitude > 0.0001f)
        {
            canMove = false;
        }
        
        if (rb.velocity.x > 0.0001f)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            canMove = false;
        }
        else if (rb.velocity.y > 0.0001f)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            canMove = false;
        }
        else if (rb.velocity.magnitude > 0.0001f)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }


        if (canMove == true && InvertControl==false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(0, 1 * speed * Time.deltaTime);
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                face.transform.rotation = Quaternion.Euler(0f, 0f,90f);
                SoundManager.playSound("swipe");
                playSound = true;
                
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.velocity = new Vector2(0, -1 * speed * Time.deltaTime);
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                face.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
                SoundManager.playSound("swipe");
                playSound = true;
                
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-1 * speed * Time.deltaTime, 0);
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                face.transform.rotation = Quaternion.Euler(180f, 0f, 180f);
                SoundManager.playSound("swipe");
                playSound = true;
                
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(1 * speed * Time.deltaTime, 0);
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                face.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                SoundManager.playSound("swipe");
                playSound = true;
                
            }
        }
        if (canMove == true && InvertControl == true)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.velocity = new Vector2(0, 1 * speed * Time.deltaTime);
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                face.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                SoundManager.playSound("swipe");
                playSound = true;

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(0, -1 * speed * Time.deltaTime);
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                face.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
                SoundManager.playSound("swipe");
                playSound = true;

            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(-1 * speed * Time.deltaTime, 0);
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                face.transform.rotation = Quaternion.Euler(180f, 0f, 180f);
                SoundManager.playSound("swipe");
                playSound = true;

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(1 * speed * Time.deltaTime, 0);
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                face.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                SoundManager.playSound("swipe");
                playSound = true;

            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("spikes"))
        {
            camShake.Play("cameraShake");
            SoundManager.playSound("destroy");
            Instantiate(ps, player.transform.position, Quaternion.identity);
            animationEnd.SetTrigger("TranEnd");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
        
            if (rb.velocity.magnitude<.5f && playSound==true)
            {
                SoundManager.playSound("wallHit");
            }
            
            
                
            GetComponent<Rigidbody2D>().constraints = OriginalRb;
            //rb.velocity = new Vector2(0,0);
        }
        if (collision.gameObject.CompareTag("spikes"))
        {
            Debug.Log("shake camera");
            SoundManager.playSound("destroy");
            camShake.Play("cameraShake");
            Instantiate(ps,player.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("winPort"))
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Animator>().Play("onWinAnim");
            gameObject.GetComponent<TrailRenderer>().enabled=false;
            SoundManager.playSound("win");
            canMove = false;
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
