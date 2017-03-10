using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.EventSystems;

public class MyoRotate : MonoBehaviour, IDragHandler
{
    /// <summary>回転対象</summary>
    public GameObject Cube;
    /// <summary>回転速度</summary>
    public float Speed = 0.01f;

    /// <summary>
    /// Raises the drag event.
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = eventData.position;
        Vector2 deltaPos = eventData.delta;
        Cube.transform.Rotate(0, -deltaPos.x * Speed, 0);
    }
}