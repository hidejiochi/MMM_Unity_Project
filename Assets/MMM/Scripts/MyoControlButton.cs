using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
public class MyoControlButton :
MonoBehaviour,
IPointerDownHandler,
IPointerExitHandler
{
    /// <summary>
    /// The button.
    /// </summary>
    private Button _button;

    /// <summary>
    /// The on pointer down handler.
    /// </summary>
    private Action _onPointerDownHandler;

    /// <summary>
    /// The on pointer down handler.
    /// </summary>
    private Action _onPointerExitHandler;

    /// <summary>
    /// Initialize the specified onPointerDown, onPointerUp and onPointerExit.
    /// </summary>
    /// <param name="onPointerDown">On pointer down.</param>
    /// <param name="onPointerUp">On pointer up.</param>
    /// <param name="onPointerExit">On pointer exit.</param>
    public void Initialize(
        Action onPointerDown,
        Action onPointerUp,
        Action onPointerExit
    )
    {
        //ボタンの取得
        _button = GetComponent<Button>();
        //ハンドラーを設定
        _onPointerDownHandler = onPointerDown;
        _onPointerExitHandler = onPointerExit;
        //ポインターアップした時の動作を設定
        _button.onClick.AddListener(() => {
            onPointerUp.Invoke();
        });
    }

    /// <summary>
    /// 押していた指が画像の範囲外にいってしまったら 
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnPointerExit(PointerEventData eventData)
    {
        _onPointerExitHandler.Invoke();
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
