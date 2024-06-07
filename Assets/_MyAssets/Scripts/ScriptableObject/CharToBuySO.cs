using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptableObjects/UnlockUI")]
public class CharToBuySO : ScriptableObject
{
    public CharacterToChoose character;
    public int price;
}
