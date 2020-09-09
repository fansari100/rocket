using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller for volume slider behavior.
/// </summary>
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private string audioSourceName;
    [SerializeField] private Slider _slider;
    
    /// <summary>
    /// Configures the event listener for the slider's value change.
    /// </summary>
    void Start()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    /// <summary>
    /// Sets the volume of the AudioSource this Slider is connected to.
    /// </summary>
    /// <param name="volume">The volume level of the Slider.</param>
    private void SetVolume(float volume)
    {
        AudioController.SetVolume(audioSourceName, volume);
    }
}
