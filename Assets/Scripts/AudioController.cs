using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller for the game's audio.
/// </summary>
public class AudioController : MonoBehaviour
{
    private static Dictionary<string, AudioSource> _audioSources;
    private static AudioController _instance;

    /// <summary>
    /// Configures the music and effect AudioSource in the AudioController's children.
    /// </summary>
    void Awake()
    {
        _instance = this;
        _audioSources = new Dictionary<string, AudioSource>();
        _audioSources.Add("music", transform.Find("MusicSource").GetComponent<AudioSource>());
        _audioSources.Add("effect", transform.Find("EffectSource").GetComponent<AudioSource>());
        ConfigureSettings();
    }

    /// <summary>
    /// Plays the title music.
    /// </summary>
    void Start()
    {
        _audioSources["music"].Play();
    }

    /// <summary>
    /// Plays an effect AudioClip.
    /// </summary>
    /// <param name="effect">The effect to play.</param>
    public static void PlayEffect(AudioClip effect)
    {
        _audioSources["effect"].PlayOneShot(effect);
    }

    /// <summary>
    /// Toggles the mute for the specified AudioSource.
    /// </summary>
    /// <param name="audioSourceName">The name of the AudioSource (either "music" or "effect").</param>
    public static void ToggleMute(string audioSourceName)
    {
        _instance.StartCoroutine(ToggleMuteAfterEffectPlays(audioSourceName));
    }

    /// <summary>
    /// Sets the volume for the specified AudioSource.
    /// </summary>
    /// <param name="audioSourceName">The name of the AudioSource (either "music" or "effect").</param>
    /// <param name="volume">The volume to set (float between 0f and 1f).</param>
    public static void SetVolume(string audioSourceName, float volume)
    {
        _audioSources[audioSourceName].volume = volume;

        PlayerPrefs.SetFloat(audioSourceName + "Volume", volume);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Toggles the mute of the specified AudioSource after the button effect plays.
    /// </summary>
    /// <param name="audioSource">The AudioSource to toggle.</param>
    /// <returns>WaitForSeconds the length of the button effect AudioClip.</returns>
    private static IEnumerator ToggleMuteAfterEffectPlays(string audioSourceName)
    {
        yield return new WaitForSeconds(_audioSources["effect"].clip.length);
        
        AudioSource audioSource = _audioSources[audioSourceName];
        audioSource.mute = !audioSource.mute;
        
        PlayerPrefs.SetInt(audioSourceName + "Mute", Convert.ToInt32(!audioSource.mute));
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Configures the mute and volume settings of the AudioSources based on PlayerPrefs.
    /// </summary>
    private static void ConfigureSettings()
    {
        _audioSources["music"].mute = !Convert.ToBoolean(PlayerPrefs.GetInt("musicMute", 1));
        _audioSources["music"].volume = PlayerPrefs.GetFloat("musicVolume", 1f);
        _audioSources["effect"].mute = !Convert.ToBoolean(PlayerPrefs.GetInt("effectMute", 1));
        _audioSources["effect"].volume = PlayerPrefs.GetFloat("effectVolume", 1f);
    }
}