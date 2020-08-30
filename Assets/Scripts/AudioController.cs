using UnityEngine;

/// <summary>
/// Controller for the game's audio.
/// </summary>
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;

    void Start()
    {
        musicSource.Play();
    }

    /// <summary>
    /// Plays an effect AudioClip.
    /// </summary>
    /// <param name="effect">The effect to play.</param>
    public void PlayEffect(AudioClip effect)
    {
        effectSource.PlayOneShot(effect);
    }
}
