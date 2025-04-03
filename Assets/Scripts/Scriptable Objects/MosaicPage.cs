using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MosaicPage", menuName = "Scriptable Objects/MosaicPage")]
public class MosaicPage : ScriptableObject
{
    [Tooltip("List of sprites to be displayed in the mosaic page.")]
    [SerializeField] private Sprite[] sprites = new Sprite[9];

    public int SpriteCount => sprites.Length;
    public Sprite GetSprite(int index) => sprites[index];

    public Sprite[] Sprites => sprites;
}
