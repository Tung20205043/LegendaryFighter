using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecialUnityEvent : MonoBehaviourSingleton<SpecialUnityEvent>
{
    public UnityEvent setActiveHeavyPunchButton;
    public UnityEvent doComboPunch;
    public UnityEvent doTransform;
    public UnityEvent backToMainUI;
    public UnityEvent<GameObject> pressNextButton;
}
