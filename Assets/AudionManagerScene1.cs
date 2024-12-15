using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudionManagerScene1 : MonoBehaviour
{
   [Header("------- Audio Source -------")]
   [SerializeField] AudioSource musicSource; 
    
   [Header("------- Audio Clip -------")]
    public AudioClip background1;


    private void Start(){
        musicSource.clip = background1;
        musicSource.loop = true;
        musicSource.Play();
    }
}
