using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCamScript : MonoBehaviour
{
    public AudioSource AudioSource;
    public float Volume = 1.0f;
    public AudioClip EquipCamClip;
    public AudioClip UnequipCamClip;
    public AudioClip CaptureClip;

    public void PlayEquipClip()
    {
        AudioSource.PlayOneShot(EquipCamClip, Volume);
    }
    public void PlayUnequipClip()
    {
        AudioSource.PlayOneShot(UnequipCamClip, Volume);
    }
    public void PlayCaptureClip()
    {
        AudioSource.PlayOneShot(CaptureClip, Volume);
    }
}
