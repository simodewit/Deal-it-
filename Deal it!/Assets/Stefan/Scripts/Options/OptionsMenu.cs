using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public UISelector windowedResolution;
    public Toggle fullscreenToggle;

    public Slider mainVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider fovSlider;
    public Slider sensitivitySlider;

    public UnityEvent<OptionsData> onOptionsApplied;

    private void OnEnable ( )
    {
        var option = OptionsData.Saved;

        windowedResolution.SetIndexWithoutSaving (option.resolutionIndex);
        fullscreenToggle.SetIsOnWithoutNotify (option.fullScreen);

        mainVolumeSlider.SetValueWithoutNotify (option.mainVolume);
        musicVolumeSlider.SetValueWithoutNotify (option.musicVolume);
        sfxVolumeSlider.SetValueWithoutNotify (option.sfxVolume);
        fovSlider.SetValueWithoutNotify (option.fov);
        sensitivitySlider.SetValueWithoutNotify (option.sensitivity);
    }

    private void OnDisable ( )
    {
        ApplyNewOptionChanges ( );
    }

    public void ApplyNewOptionChanges ( )
    {
        var data = OptionsData.Saved;

        data.resolutionIndex = windowedResolution.CurrentIndex;
        data.fullScreen = fullscreenToggle.isOn;
        data.mainVolume = mainVolumeSlider.value;
        data.musicVolume = musicVolumeSlider.value;
        data.sfxVolume = sfxVolumeSlider.value;
        data.fov = fovSlider.value;
        data.sensitivity = sensitivitySlider.value;

        data.Save ( );

        onOptionsApplied.Invoke (data);
    }
}