using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharUnlockManager : MonoBehaviourSingletonPersistent<CharUnlockManager>
{
    [SerializeField] private List<CharacterUnlockData> characterUnlockStatusList;
    [SerializeField] private List<CharacterToChoose> characterNotUnlocked;
    public List<CharacterToChoose> CharacterNotUnlocked => characterNotUnlocked;

    private void OnEnable()
    {
        foreach (var data in characterUnlockStatusList.Where(data => !data.IsUnlocked))
        {
            characterNotUnlocked.Add(data.Character);
        }
    }

    public bool IsCharacterUnlocked(CharacterToChoose character)
    {
        return (from status in characterUnlockStatusList where status.Character.Equals(character) select status.IsUnlocked).FirstOrDefault();
    }

    public void UnlockCharacter(CharacterToChoose character)
    {
        characterNotUnlocked.Remove(character);
        foreach (var t in characterUnlockStatusList.Where(t => t.Character.Equals(character)))
        {
            t.UnlockCharacter();
            return;
        }
    }

    public CharacterToChoose FirstElementInArray()
    {
        return HaveCharToUnlock() ? characterNotUnlocked[0] : CharacterToChoose.Default;
    }

    public bool HaveCharToUnlock()
    {
        return characterNotUnlocked.Count != 0;
    }

    public bool IsDefaultCharacter(CharacterToChoose characterToChoose)
    {
        return characterToChoose is CharacterToChoose.Goku or CharacterToChoose.MabuForm1;
    }
}
