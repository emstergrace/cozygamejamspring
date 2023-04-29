using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomUIButton : Button
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        if(MusicPlayer.instance != null)
        {
            MusicPlayer.instance.PlayOneShot(MusicPlayer.UISounds.Hover);
        }
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        if (MusicPlayer.instance != null)
        {
            MusicPlayer.instance.PlayOneShot(MusicPlayer.UISounds.Open);
        }
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (MusicPlayer.instance != null)
        {
            MusicPlayer.instance.PlayOneShot(MusicPlayer.UISounds.Select);
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
    }
}
