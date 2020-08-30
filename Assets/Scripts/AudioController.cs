using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public const string CLICK_SOUND = "click_sound";
    public const string TITLE_MUSIC = "title_music";

    private Dictionary<string, AudioClip> audioClips;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;
    [SerializeField] private AudioClip[] clips;

    void Start()
    {
        LoadClips();
        musicSource.PlayOneShot(audioClips[TITLE_MUSIC]);
    }

    void Update()
    {
        
    }

    private void LoadClips()
    {
        audioClips = new Dictionary<string, AudioClip>();
         foreach (AudioClip clip in clips)
         {
             audioClips.Add(clip.name, clip);
         } 
    }
    public void playClickSound()
    {
        effectSource.PlayOneShot(audioClips[CLICK_SOUND]);
    }
}
