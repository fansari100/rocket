using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Base class for UI menu buttons.
/// </summary>
public class MenuButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private const float SHRINK_SCALE = 0.9f;
    private const float GROW_SCALE = 1.0F;

    [SerializeField] private RectTransform rt;
    [SerializeField] private AudioController audioController;
    [SerializeField] private protected GameObject menuScreen;
    [SerializeField] private AudioClip clickEffect;

    public void OnPointerDown(PointerEventData data)
    {
        SetScale(SHRINK_SCALE);
        audioController.PlayEffect(clickEffect);
    }

    public void OnPointerUp(PointerEventData data)
    {
        SetScale(GROW_SCALE);
    }

    /// <summary>
    /// Sets the localScale property of the button's RectTransform.
    /// </summary>
    /// <param name="scale">The float value to set the localScale to.</param>
    private void SetScale(float scale)
    {
        rt.localScale = new Vector3(scale, scale, scale);
    }
}