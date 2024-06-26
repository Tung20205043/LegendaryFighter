using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemyTelePosition : MonoBehaviourSingleton<GetEnemyTelePosition>
{
    [SerializeField] private Transform forwardTransform;
    [SerializeField] private Transform backTransform;

    public Vector3 ForwardTransform { get { return forwardTransform.position; } }
    public Vector3 BackTransform { get { return backTransform.position; } }
}
