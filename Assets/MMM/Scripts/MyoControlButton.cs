using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
public class MyoControlButton :
MonoBehaviour,
IPointerDownHandler
{
    /// <summary>
    /// The button.
    /// </summary>
    private Button _button;

    /// <summary>
    /// The on pointer down handler.
    /// </summary>
    private Action _onPointerDownHandler;

    public void Initialize(Action onPointerDown, Action onPointerUp)
    {
        //ボタンの取得
        _button = GetComponent<Button>();
        //ハンドラーを設定
        _onPointerDownHandler = onPointerDown;
        //ポインターアップした時の動作を設定
        _button.onClick.AddListener(() => {
            onPointerUp.Invoke();
        });
    }

    /// <summary>
    /// ポインターダウンした時に呼ばれる 
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        _onPointerDownHandler.Invoke();
    }
}
