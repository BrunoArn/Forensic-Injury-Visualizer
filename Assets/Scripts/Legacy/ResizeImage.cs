using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ResizeImage : MonoBehaviour
{
    [SerializeField] private Vector2 targetSize = new Vector2(300f, 300f);

    private RectTransform rectTransform;
    private Vector2 originnalSize;

    private Transform originalParent;

    [Header("Parent to reposition")]
    [SerializeField] Transform newParentCanvas;

    [Header("Boolean Reference")]
    [Space]
    [SerializeField] private BoolReference isResized;
    private bool imResized;

    void Start()
    {
        if(!isResized.useConstantValue) {
            isResized.Value = false;
        }

        rectTransform = GetComponent<RectTransform>();
        originnalSize = rectTransform.sizeDelta;
        originalParent = this.transform.parent;

        GetComponent<Button>()?.onClick.AddListener(ToggleSize);
    }

    private void ToggleSize()
    {
        if (!isResized.useConstantValue && isResized.Value && !imResized) { return; }

        if(!isResized.Value) 
        {
            //Resize(targetSize, Vector2.zero);
            Resize(targetSize, newParentCanvas);

            if(!isResized.useConstantValue) { imResized = true; }
            isResized.Value = true;
        }
        else
        {
            Resize(originnalSize, originalParent);

            if(!isResized.useConstantValue) { imResized = false; }
            isResized.Value = false;
        }

    }

    private void Resize(Vector2 targetSize, Transform parent)
    {
        rectTransform.sizeDelta = targetSize;
        transform.SetParent(parent, false);
    }

    public void ForceMini()
    {
        Resize(originnalSize, originalParent);
        isResized.Value = false;
    }
}
