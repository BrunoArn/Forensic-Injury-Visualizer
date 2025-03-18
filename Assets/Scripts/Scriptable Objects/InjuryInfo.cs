using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "InjuryInfo", menuName = "Scriptable Objects/InjuryInfo")]
public class InjuryInfo : ScriptableObject
{
    public String InjuryTitle;

    [Header("Descrição do dano ao corpo")]
    [TextArea(3, 10)]
    public String injuryText;
    
    public Sprite injuryImage;
}
