using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class ButtonChangeInfo : MonoBehaviour
{
    [SerializeField] InjuryInfo myInfo;
    [SerializeField] GameObject canvas;

    public void ChangeInfo() {
        canvas.GetComponent<CanvasText>().UpdateText(myInfo.InjuryTitle, myInfo.injuryText, myInfo.injuryImage);
    }
}
