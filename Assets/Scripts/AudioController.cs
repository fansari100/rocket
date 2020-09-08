using UnityEngine;

/// <summary>
/// Controller for the game's audio.
/// </summary>
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectSource;

    void Start()
    {
        _musicSource.Play();
    }

    /// <summary>
    /// Plays an effect AudioClip.
    /// </summary>
    /// <param name="effect">The effect to play.</param>
    public void PlayEffect(AudioClip effect)
    {
        _effectSource.PlayOneShot(effect);
    }
}
