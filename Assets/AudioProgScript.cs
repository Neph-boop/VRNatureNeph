using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioProgScript : MonoBehaviour
{
    public AudioSource AudioSource;
    public float Volume = 1.0f;
    public AudioClip UnlockedSpeciesClip;
    public void PlayEquipClip()
    {
        AudioSource.PlayOneShot(UnlockedSpeciesClip, Volume);
    }
}
