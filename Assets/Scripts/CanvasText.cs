using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasText : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] GameObject textBody;
    [SerializeField] GameObject textImage;

    private TextMeshProUGUI titleText;
    private TextMeshProUGUI textBodyText;
    private Image imageSprite;



    void Start()
    {
        titleText = title.GetComponent<TextMeshProUGUI>();
        textBodyText = textBody.GetComponent<TextMeshProUGUI>();
        imageSprite = textImage.GetComponent<Image>();
    }

    public void UpdateText(string newTitle, string newText, Sprite newImage) {
        titleText.text = newTitle;
        textBodyText.text = newText;
        imageSprite.sprite = newImage;
    }

    internal void UpdateText()
    {
        throw new NotImplementedException();
    }
}
