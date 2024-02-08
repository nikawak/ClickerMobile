using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class GameSound : MonoBehaviour
{
    [SerializeField] Slider _soundSlider;
    [SerializeField] Slider _musicSlider;
    [SerializeField] TextMeshProUGUI _soundText;
    [SerializeField] TextMeshProUGUI _musicText;
    [SerializeField] List<AudioSource> _soundSources;
    [SerializeField] List<AudioSource> _musicSources;

    [SerializeField] GameObject _soundImageEnabled;
    [SerializeField] GameObject _musicImageEnabled;
    [SerializeField] GameObject _soundImageDisabled;
    [SerializeField] GameObject _musicImageDisabled;
    private void Start()
    {
        _soundSlider.onValueChanged.AddListener(SoundValueChanged);
        _musicSlider.onValueChanged.AddListener(MusicValueChanged);

        _soundSlider.value = 0.99f;
        _musicSlider.value = 0.99f;
    }
    public void SoundClick()
    {
        var sound = _soundSlider.value;
        sound = sound == 0 ? 1 : 0;
        _soundSlider.value = sound;
    }
    public void MusicClick()
    {
        var sound = _musicSlider.value;
        sound = sound == 0 ? 1 : 0;
        _musicSlider.value = sound;
    }

    private void SoundValueChanged(float value)
    {
        UserData.SoundValue = value;
        _soundSources.ForEach(x=>x.volume = value);
        _soundText.text = Math.Round(value * 100).ToString() + " / 100";
        ChangeSoundIcon(value);
    }

    private void MusicValueChanged(float value)
    {
        UserData.MusicValue = value;
        _musicSources.ForEach(x => x.volume = value);
        _musicText.text = Math.Round(value*100).ToString() + " / 100";
        ChangeMusicIcon(value);
    }
    private void ChangeMusicIcon(float value)
    {
        var val = value == 0;
        _musicImageEnabled.SetActive(!val);
        _musicImageDisabled.SetActive(val);
    }
    private void ChangeSoundIcon(float value)
    {
        var val = value == 0;
        _soundImageEnabled.SetActive(!val);
        _soundImageDisabled.SetActive(val);
    }
}