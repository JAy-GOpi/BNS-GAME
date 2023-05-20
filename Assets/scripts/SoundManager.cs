using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip  destroy,win;
    public static AudioClip[] wallHit = new AudioClip[3];
    public static AudioClip[] swipe = new AudioClip[3];
    public static AudioClip[] shoot = new AudioClip[4];
    public static AudioClip ballShoot;
    
    static AudioSource audSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        wallHit[0] = Resources.Load<AudioClip>("HitWall1");
        wallHit[1] = Resources.Load<AudioClip>("HitWall2");
        wallHit[2] = Resources.Load<AudioClip>("HitWall3");
        destroy = Resources.Load<AudioClip>("destroy");
        swipe[0]= Resources.Load<AudioClip>("swipe1");
        swipe[1]= Resources.Load<AudioClip>("swipe2");
        swipe[2]= Resources.Load<AudioClip>("swipe3");
        shoot[0]= Resources.Load<AudioClip>("laser1");
        shoot[1]= Resources.Load<AudioClip>("laser2");
        shoot[2]= Resources.Load<AudioClip>("laser3");
        shoot[3]= Resources.Load<AudioClip>("laser4");
        ballShoot = Resources.Load<AudioClip>("ball1");
       // ballShoot[1]= Resources.Load<AudioClip>("ball2");
        win= Resources.Load<AudioClip>("win");

        audSrc = GetComponent<AudioSource>();
    }

    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "wallHit":
                audSrc.PlayOneShot(wallHit[Random.Range(0,3)]);
                break;
            case "destroy":
                audSrc.PlayOneShot(destroy);
                break;
           case "swipe":
                audSrc.PlayOneShot(swipe[Random.Range(0, 3)]);
                break;
           case "shoot":
                audSrc.PlayOneShot(shoot[Random.Range(0, 4)]);
                break;
            case "ball":
                audSrc.PlayOneShot(ballShoot);
                break;
            case "win":
                audSrc.PlayOneShot(win);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
