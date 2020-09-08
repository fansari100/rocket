using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Base class for UI menu buttons.
/// </summary>
public class MenuButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private const float ShrinkScale = 0.9f;
    private const float GrowScale = 1.0F;

    [SerializeField] private RectTransform _rt;
    [SerializeField] private AudioClip _clickEffect;
    
    private static AudioController _audioController;

    void Start()
    {
        InitializeAudioController();
    }

    public void OnPointerDown(PointerEventData data)
    {
        SetScale(ShrinkScale);
        _audioController.PlayEffect(_clickEffect);
    }

    public void OnPointerUp(PointerEventData data)
    {
        SetScale(GrowScale);
    }

    /// <summary>
    /// Sets the localScale property of the button's RectTransform.
    /// </summary>
    /// <param name="scale">The float value to set the localScale to.</param>
    private void SetScale(float scale)
    {
        _rt.localScale = new Vector3(scale, scale, scale);
    }

    /// <summary>
    /// Sets the _audioController field with the current AudioController in the scene.
    /// </summary>
    private void InitializeAudioController()
    {
        if (_audioController == null)
        {
            _audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
        }
    }
}