using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSound : MonoBehaviour
{
   public AudioClip trainSound;
    public AudioClip carSound;
    AudioSource trafficSound; 

    bool alreadyPlaying = false;

    void Start()
    {

        trafficSound = gameObject.GetComponent<AudioSource>();
        MakeTrafficNoise();
        
    }



    public void PlayTrainSound()
    {

        trafficSound.clip = trainSound;
        trafficSound.volume = .15f;
        trafficSound.Play();
    }




    public void PlayCarHornSound()
    {

        trafficSound.clip = carSound;
        trafficSound.volume = .02f;
        trafficSound.Play();

    }

   public void MakeTrafficNoise() { 
        int randomSeconds = Random.Range(3,10
            );
    
        if(alreadyPlaying == false)
        {
            alreadyPlaying = true;
        StartCoroutine( TrafficCarPass(randomSeconds));
        }
    }

    IEnumerator TrafficCarPass(int seconds)
    {
     
        yield return new WaitForSeconds(seconds);
        PlayCarHornSound();
        alreadyPlaying = false;
    

    }
}
