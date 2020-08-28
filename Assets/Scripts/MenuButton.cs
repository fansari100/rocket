using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    private RectTransform rt;
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData data)
    {
        audioSource.Play();
        Shrink();
    }

    public void OnPointerUp(PointerEventData data)
    {
        Grow();
    }

    private void Shrink()
    {
        rt.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }

    private void Grow()
    {
        rt.localScale = new Vector3(1f, 1f, 1f);
    }
}