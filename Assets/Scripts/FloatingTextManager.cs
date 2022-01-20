using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    [SerializeField] private GameObject textContainer;
    [SerializeField] private GameObject textPrefab;
    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()
    {
        foreach (FloatingText floatingText in floatingTexts)
        {
            floatingText.UpdateFloatingText();
        }
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();

        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.SetTextPosition(Camera.main.WorldToScreenPoint(position));
        floatingText.SetMotion(motion);
        floatingText.SetDuration(duration);

        floatingText.Show();
    }

    public FloatingText GetFloatingText()
    {
        FloatingText floatingText = floatingTexts.Find(t => !t.GetActive());

        if (floatingText == null)
        {
            floatingText = new FloatingText();
            floatingText.SetGameObject(Instantiate(textPrefab));
            floatingText.SetTextTransform(textContainer);
            floatingText.txt = floatingText.GetObjectText();
            floatingTexts.Add(floatingText);
        }

        return floatingText;
    }

}   
