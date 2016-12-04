using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharaRotateDetectImage :MonoBehaviour,IDragHandler
{
    //ドラッグされた時に毎回呼ばれる
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = eventData.position;
    }
}
