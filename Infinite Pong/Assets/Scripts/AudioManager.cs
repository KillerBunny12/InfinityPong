using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource hit;
    public AudioSource lose;
    public AudioSource retry;
    // Start is called before the first frame update
    

    // Update is called once per frame
    public void playHit()
    {
        hit.Play();
    }

    public void playRetry()
    {
        retry.Play();
    }

    public void playLose()
    {
        lose.Play();
    }
}
