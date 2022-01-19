using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

enum Language
{
    FR,
    EN
};
public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsObject;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Animator OptionsMenuAnimator;
    bool areOptionsDisplayed = false;
    public void DisplayMenu()
    {
        if (areOptionsDisplayed)
        {
            optionsObject.SetActive(false);
            areOptionsDisplayed = false;
            
        }
        else
        {
            optionsObject.SetActive(true);
            areOptionsDisplayed = true;
        }
        OptionsMenuAnimator.SetBool("isOpen", areOptionsDisplayed);
    }
    
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }
    public void SetEffectVolume(float volume)
    {
        audioMixer.SetFloat("Effect", volume);
    }
}
