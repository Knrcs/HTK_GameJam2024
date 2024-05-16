using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class OptionsMenu : MonoBehaviour
{
    [Header("Menus")]
    public GameObject optionsMenu;
    
    [Header("Audio")] 
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider ambienceSlider;
    private FMOD.Studio.Bus _master;
    private FMOD.Studio.Bus _music;
    private FMOD.Studio.Bus _sfx;
    private FMOD.Studio.Bus _ambience;
    public float masterVolume = 1f;
    public float musicVolume = 0.5f;
    public float sfxVolume = 0.5f;
    public float ambienceVolume = 0.5f;
    
    
    private void Awake()
    {
        
        _master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        _music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        _sfx = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        _ambience = FMODUnity.RuntimeManager.GetBus("bus:/Master/Ambience");
        
    }

    private void Start()
    {
        StartCoroutine(StartSetSlider());
        optionsMenu.SetActive(false);
    }

    private IEnumerator StartSetSlider()
    {
        yield return new WaitForSeconds(0.01f);
        
        masterSlider.value = PlayerPrefs.GetFloat("masterValue");
        musicSlider.value = PlayerPrefs.GetFloat("musicValue");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxValue");
        ambienceSlider.value = PlayerPrefs.GetFloat("ambienceValue");

        yield return new WaitForSeconds(0.01f);
        
        masterVolume = masterSlider.value;
        musicVolume = musicSlider.value;
        sfxVolume = sfxSlider.value;
        ambienceVolume = ambienceSlider.value;
    }
    private void Update()
    {
        _master.setVolume(masterVolume);
        _music.setVolume(musicVolume);
        _sfx.setVolume(sfxVolume);
        _ambience.setVolume(ambienceVolume);
    }

    public void MasterVolume()
    {
        masterVolume = masterSlider.value;
        PlayerPrefs.SetFloat("masterValue", masterSlider.value);
        PlayerPrefs.Save();
    }
    public void MusicVolume()
    {
        musicVolume = musicSlider.value;
        PlayerPrefs.SetFloat("musicValue", musicSlider.value);
        PlayerPrefs.Save();
    }
    public void SfxVolume()
    {
        sfxVolume = sfxSlider.value;
        PlayerPrefs.SetFloat("sfxValue", sfxSlider.value);
        PlayerPrefs.Save();
    }
    
    public void AmbienceVolume()
    {
        ambienceVolume = ambienceSlider.value;
        PlayerPrefs.SetFloat("ambienceValue", ambienceSlider.value);
        PlayerPrefs.Save();
    }


}
