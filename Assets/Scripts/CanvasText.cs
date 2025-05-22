using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasText : MonoBehaviour
{
    [Header("Title configs")]
    [SerializeField] GameObject title;
    [Header("text configs")]
    [SerializeField] GameObject textBackgorund;
    [SerializeField] GameObject textBody;
    [SerializeField] float heightOffset;
    [Header("Image configs")]
    [SerializeField] GameObject textImage;

    private TextMeshProUGUI titleText;
    private Image textBackgorundImage;
    private TextMeshProUGUI textBodyText;
    private Image imageSprite;

    void Start()
    {
        titleText = title.GetComponent<TextMeshProUGUI>();

        textBackgorundImage = textBackgorund.GetComponent<Image>();
        textBodyText = textBody.GetComponent<TextMeshProUGUI>();

        imageSprite = textImage.GetComponent<Image>();
    }

    private void MatchBackgroundWithTextHeight()
    {
        if (textBodyText == null || textBackgorundImage == null) return;

        bool hasText = !string.IsNullOrWhiteSpace(textBodyText.text);
        textBackgorund.SetActive(hasText);


        // Get preferred height of the TMP text
        float textHeight = textBodyText.preferredHeight;

        // Get the Image RectTransform
        RectTransform imageRect = textBackgorundImage.rectTransform;

        // Match height with offset
        Vector2 size = imageRect.sizeDelta;
        size.y = textHeight + heightOffset;
        imageRect.sizeDelta = size;
    }

    public void UpdateText(string newTitle, string newText, Sprite newImage)
    {
        titleText.text = newTitle;
        textBodyText.text = newText;
        imageSprite.sprite = newImage;
        MatchBackgroundWithTextHeight();
    }

    internal void UpdateText()
    {
        throw new NotImplementedException();
    }
}
