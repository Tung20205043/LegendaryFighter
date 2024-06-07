using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptableObjects/StartPunch")]
public class PunchSO : ScriptableObject
{
    public AnimatorOverrideController animatorOV;
    public float damage;

}
