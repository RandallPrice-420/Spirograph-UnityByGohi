using UnityEngine;
using UnityEngine.EventSystems;


public class DragHandler : MonoBehaviour
{
    private Vector3 offset;


    public void OnBeginDrag(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(pointerData.position.x, pointerData.position.y, Camera.main.nearClipPlane));
    }


    public void OnDrag(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(pointerData.position.x, pointerData.position.y, Camera.main.nearClipPlane)) + offset;
        transform.position = newPosition;
    }


    public void OnEndDrag(BaseEventData data)
    {
        // Optional: Add logic for when dragging ends
    }

}