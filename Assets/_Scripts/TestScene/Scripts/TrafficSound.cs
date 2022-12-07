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
     

            trafficSound.Play();



    }



    public void PlayCarSound()
    {


        trafficSound.clip = carSound;


        trafficSound.Play();





    }

   public void MakeTrafficNoise() { 
        int randomSeconds = Random.Range(1,4);
    
        if(alreadyPlaying == false)
        {
            alreadyPlaying = true;
        StartCoroutine( TrafficCarPass(randomSeconds));
        }
    }

    IEnumerator TrafficCarPass(int seconds)
    {
     
        yield return new WaitForSeconds(seconds);
        PlayCarSound();

        alreadyPlaying = false;
    

    }
}
