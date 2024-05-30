using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerPoint : MonoBehaviourSingleton<GetPlayerPoint> 
{
    [SerializeField] private Transform forwardTransform;
    [SerializeField] private Transform backTransform;
    [SerializeField] private Transform kamehaPos;
    [SerializeField] private Transform skillPos;
    [SerializeField] private Transform[] ultSkillPos;

    public Vector3 ForwardTransform { get { return forwardTransform.position; } }
    public Vector3 BackTransform { get { return backTransform.position; } }
    public Vector3 KamehaPos { get { return kamehaPos.position; } }
    public Vector3 SkillPos { get {return skillPos.position; } }
    public Vector3 UltSkillPos { 
        get {
            if (EnemyIsOnTheRight()) {
                return ultSkillPos[0].position;
            }
            else
                return ultSkillPos[1].position;
        } 
    }

    bool EnemyIsOnTheRight() {
        return GameObjectManager.Instance.DirectionToEnemy().x >= 0;
    }
}
