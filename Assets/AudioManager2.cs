using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
   [Header("------- Audio Source -------")]
   [SerializeField] AudioSource musicSource; 
   [SerializeField] AudioSource laserSource; 
    
   [Header("------- Audio Clip -------")]
    public AudioClip background;
    public AudioClip laser; 

    public bool playLaser; 


    private void Start(){
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

    void Update(){
        if(playLaser){
            laserSource.clip = laser;
            laserSource.Play();
            playLaser = false;
        }
    }
}
