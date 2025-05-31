using UnityEngine;

[CreateAssetMenu(fileName = "Novo Item", menuName = "Inventário/Novo Item")]
public class ItemCreator : ScriptableObject
{
    public Sprite Icone;
    public string Name;
    [TextArea] public string Description;
}
