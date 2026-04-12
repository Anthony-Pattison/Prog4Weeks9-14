using UnityEngine;

[CreateAssetMenu(fileName = "onScreenText", menuName = "Scriptable Objects/onScreenText")]
public class onScreenText : ScriptableObject
{
    public string titleText;
    [TextArea(0, 20)]
    public string discriptionText;
    public Sprite showImageSprite;
}
