using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsHandler : MonoBehaviour
{
    public AudioMixer AudioMixerRef;
    public int MainMenuSceneIndex;

    public void SetBirdVolume(float volume)
    {
        AudioMixerRef.SetFloat("BirdVol", Mathf.Log10(volume) * 20);
    }

    public void SetBackgroundVolume(float volume)
    {
        AudioMixerRef.SetFloat("BgVol", Mathf.Log10(volume) * 20);
    }
    public void SetSfxVolume(float volume)
    {
        AudioMixerRef.SetFloat("SfxVol", Mathf.Log10(volume) * 20);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneIndex);
    }
}
