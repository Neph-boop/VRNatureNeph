using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioJournalScript : MonoBehaviour
{
    public AudioSource AudioSource;
    public float Volume = 1.0f;
    public AudioClip EquipJournalClip;
    public AudioClip UnequipJournalClip;
    public AudioClip PageClip;

    public void PlayEquipClip()
    {
        AudioSource.PlayOneShot(EquipJournalClip, Volume);
    }
    public void PlayUnequipClip()
    {
        AudioSource.PlayOneShot(UnequipJournalClip, Volume);
    }
    public void PlayPageClip()
    {
        AudioSource.PlayOneShot(PageClip, Volume);
    }

}
