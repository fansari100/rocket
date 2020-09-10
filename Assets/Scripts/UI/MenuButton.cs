using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Base class for UI menu buttons.
/// </summary>
public class MenuButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private const float ShrinkScale = 0.9f;
    private const float GrowScale = 1.0F;
    private static readonly Color OnColor = Color.white;
    private static readonly Color OffColor = Color.gray;

    [SerializeField] private RectTransform _rt;
    [SerializeField] private AudioClip _clickEffect;
    [SerializeField] private Image _image;
    [SerializeField] private bool _isToggle;
    [SerializeField] private string _playerPref;

    private bool _isEnabled;

    /// <summary>
    /// Configures the enabled state based on PlayerPrefs.
    /// </summary>
    void Awake()
    {
        _isEnabled = IsEnabled(_playerPref);
        _image.color = _isEnabled ? OnColor : OffColor;
    }

    /// <summary>
    /// Plays the button effect and shrink's the button's size.
    /// </summary>
    /// <param name="data"></param>
    public void OnPointerDown(PointerEventData data)
    {
        SetScale(ShrinkScale);
        AudioController.PlayEffect(_clickEffect);
    }

    /// <summary>
    /// Returns the button to its original size.
    /// </summary>
    /// <param name="data"></param>
    public void OnPointerUp(PointerEventData data)
    {
        SetScale(GrowScale);
        if (_isToggle)
        {
            _isEnabled = !_isEnabled;
            _image.color = _isEnabled ? OnColor : OffColor;
        }
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
    /// Checks whether the button is enabled based on PlayerPrefs.
    /// </summary>
    /// <param name="playerPref">The preference that determines the button's enabled state.</param>
    /// <returns>True if enabled. False if not enabled.</returns>
    private bool IsEnabled(string playerPref)
    {
        return Convert.ToBoolean(PlayerPrefs.GetInt(playerPref, 1));
    }
}