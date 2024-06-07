using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptableObjects/CharacterUnlockData")]
public class CharacterUnlockData : ScriptableObject
{
    [SerializeField] private CharacterToChoose character;
    [SerializeField] private bool isUnlocked;
    [SerializeField] private int price;
    public CharacterToChoose Character => this.character;
    public bool IsUnlocked => this.isUnlocked;
    public int Price => this.price;

    public void UnlockCharacter()
    {
        this.isUnlocked = true;
    }
}