using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoldButton : Button, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent<bool> holdButton;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        holdButton?.Invoke(true);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        holdButton?.Invoke(false);
    }
}
