using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class VolumeController : MonoBehaviour
{
    private AudioSource BackMus;
    private float MusVol = 1f;

    void Start()
    {
        //Assigning Source of audio in order to controll
        BackMus = GetComponent<AudioSource>();

    }

    void Update()
    {

        //volume option == music volume
        BackMus.volume = MusVol;

    }

    public void VolumeSetting(float volume)
    {
        MusVol = volume;
    }

}
