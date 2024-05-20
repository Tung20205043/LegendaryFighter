using UnityEngine;
using UnityEngine.Events;

public class RaycastCheck : MonoBehaviour {
    public float raycastDistance = 1f;
    public LayerMask layerMask;
    public UnityEvent<TakeDamageType> takeDmgEvent;
    public void CheckObjByRaycast(int value) {
        Vector2 direction = transform.right;
        Vector2 origin = transform.position;
        Debug.DrawRay(origin, direction * raycastDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, raycastDistance, layerMask);
        if (hit.collider != null) {
            takeDmgEvent.Invoke((TakeDamageType)value);
        } 
    }
}
