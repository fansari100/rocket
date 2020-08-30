using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public const float SHRINK_SCALE = 0.9f;
    public const float GROW_SCALE = 1.0F;
    [SerializeField] private RectTransform rt;
    [SerializeField] private AudioController audioController;
    [SerializeField] protected GameObject menuScreen;

    protected void Start()
    {

    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData data)
    {
        SetScale(SHRINK_SCALE);
        audioController.playClickSound();
    }

    public void OnPointerUp(PointerEventData data)
    {
        SetScale(GROW_SCALE);
    }

    private void SetScale(float scale)
    {
        rt.localScale = new Vector3(scale, scale, scale);
    }
}