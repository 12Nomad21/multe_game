using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class FunctionSliders : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [Header("Sound values")]
    [SerializeField] private float _minSoundValue = -80f;
    [SerializeField] private float _maxSoundValue = 0;
    [Header("Instanceing sliders")]
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _effectsVolumeSlider;
    
    private void Start()
    {
        _mixer.audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        _musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolumeSliderValue");

        _mixer.audioMixer.SetFloat("EffectsVolume", PlayerPrefs.GetFloat("EffectsVolume"));
        _effectsVolumeSlider.value = PlayerPrefs.GetFloat("EffectsVolumeSliderValue");
    }

    public void ChangeMusicVolume()
    {
        var _lerpValue = Mathf.Lerp(_minSoundValue, _maxSoundValue, _musicVolumeSlider.value);
        _mixer.audioMixer.SetFloat("MusicVolume", _lerpValue);

        PlayerPrefs.SetFloat("MusicVolume", _lerpValue);
        PlayerPrefs.SetFloat("MusicVolumeSliderValue", _musicVolumeSlider.value);
    }

    public void ChangeEffectsVolume()
    {
        var _lerpValue = Mathf.Lerp(_minSoundValue, _maxSoundValue, _effectsVolumeSlider.value);
        _mixer.audioMixer.SetFloat("EffectsVolume", _lerpValue);

        PlayerPrefs.SetFloat("EffectsVolume", _lerpValue);
        PlayerPrefs.SetFloat("EffectsVolumeSliderValue", _effectsVolumeSlider.value);
    }
}
