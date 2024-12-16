using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerPrep : MonoBehaviour
{
  [Header("------- Audio Source -------")]
   [SerializeField] AudioSource musicSource; 
    
   [Header("------- Audio Clip -------")]
    public AudioClip background;


    private void Start(){
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }
}
