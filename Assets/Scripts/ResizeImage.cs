using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ResizeImage : MonoBehaviour
{
    [SerializeField] private Vector2 targetSize = new Vector2(300f, 300f);

    private RectTransform rectTransform;
    private RectTransform canvasReactTransform;

    private Vector2 originnalSize;
    private Vector2 originalAnchoredPosition;

    [Header("Boolean Reference")]
    [SerializeField] private BoolReference isResized;
    [SerializeField] private bool imResized;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originnalSize = rectTransform.sizeDelta;
        originalAnchoredPosition = rectTransform.anchoredPosition;

        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvasReactTransform = canvas.GetComponent<RectTransform>();
        }

        GetComponent<Button>()?.onClick.AddListener(ToggleSize);
    }

    private void ToggleSize()
    {
        if (!isResized.useConstantValue && isResized.Value && !imResized) { return; }

        if(!isResized.Value) 
        {
            Resize(targetSize, Vector2.zero);

            if(!isResized.useConstantValue) { imResized = true; }
            isResized.Value = true;
        }
        else
        {
            Resize(originnalSize, originalAnchoredPosition);

            if(!isResized.useConstantValue) { imResized = false; }
            isResized.Value = false;
        }

    }

    private void Resize(Vector2 targetSize, Vector2 position)
    {
        rectTransform.sizeDelta = targetSize;
        rectTransform.anchoredPosition = position;
    }
}
