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
    [SerializeField] private bool isToggle;

    private bool isEnabled = true;

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
        if (isToggle)
        {
            _image.color = _image.color == OnColor ? OffColor : OnColor;
            isEnabled = !isEnabled;
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
}