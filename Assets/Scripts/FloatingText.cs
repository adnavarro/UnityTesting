using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    private bool active;
    private GameObject go;
    public Text txt;
    private Vector3 motion;
    private float duration;
    private float lastShown;

    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

    public void UpdateFloatingText()
    {
        if(!active)
        {
            return;
        }

        if(Time.time - lastShown > duration)
        {
            Hide();
        }

        go.transform.position += motion * Time.deltaTime;
    }

    public bool GetActive()
    {
        return this.active;
    }

    public void SetGameObject(GameObject go)
    {
        this.go = go;
    }

    public void SetMotion(Vector3 motion)
    {
        this.motion = motion;
    }

    public void SetDuration(float duration)
    {
        this.duration = duration;
    }

    public Text GetObjectText()
    {
        return go.GetComponent<Text>();
    }

    public void SetTextTransform(GameObject textObject)
    {
        go.transform.SetParent(textObject.transform);
    }

    public void SetTextPosition(Vector3 position)
    {
        go.transform.position = position;
    }
}
