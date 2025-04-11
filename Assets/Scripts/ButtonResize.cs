using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonResize : MonoBehaviour
{
    public static event Action CollapseAll;

    [SerializeField] private Vector2 targetSize = new Vector2(300f, 300f);

    private RectTransform rectTransform;
    private Vector2 originnalSize;

    private Transform originalParent;
    [Header("Parent to reposition")]
    [SerializeField] Transform newParentCanvas;

    private bool isExpanded = false;

    void OnEnable()
    {
        CollapseAll += CollapseOthers;
    }

    void OnDisable()
    {
        CollapseAll -= CollapseOthers;
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originnalSize = rectTransform.sizeDelta;
        originalParent = this.transform.parent;

        GetComponent<Button>()?.onClick.AddListener(ToggleSize);
    }

    private void ToggleSize()
    {
        if(!isExpanded) 
        {
            CollapseAll?.Invoke();
            Resize(targetSize, newParentCanvas);
            isExpanded = true;
        }
        else
        {
            Resize(originnalSize, originalParent);
            isExpanded = false;
        }

    }

    private void Resize(Vector2 targetSize, Transform parent)
    {
        rectTransform.sizeDelta = targetSize;
        transform.SetParent(parent, false);
    }

    private void CollapseOthers()
    {
        Resize(originnalSize, originalParent);
        isExpanded = false;
    }

    public void CollapseAllButtons()
    {
        CollapseAll?.Invoke();
    }
}
