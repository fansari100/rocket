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
        AudioSource audioSource = _audioSources[audioSourceName];
        _instance.StartCoroutine(ToggleMuteAfterEffectPlays(audioSource));
    }

    /// <summary>
    /// Sets the volume for the specified AudioSource.
    /// </summary>
    /// <param name="audioSourceName">The name of the AudioSource (either "music" or "effect").</param>
    /// <param name="volume">The volume to set (float between 0f and 1f).</param>
    public static void SetVolume(string audioSourceName, float volume)
    {
        _audioSources[audioSourceName].volume = volume;
    }

    /// <summary>
    /// Toggles the mute of the specified AudioSource after the button effect plays.
    /// </summary>
    /// <param name="audioSource">The AudioSource to toggle.</param>
    /// <returns>WaitForSeconds the length of the button effect AudioClip.</returns>
    private static IEnumerator ToggleMuteAfterEffectPlays(AudioSource audioSource)
    {
        yield return new WaitForSeconds(_audioSources["effect"].clip.length);
        audioSource.mute = !audioSource.mute;
    }
}
