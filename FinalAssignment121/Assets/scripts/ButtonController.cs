using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource click;
    public void OnPointerEnter(PointerEventData eventData)
    {
         click.Play();
    }
}
