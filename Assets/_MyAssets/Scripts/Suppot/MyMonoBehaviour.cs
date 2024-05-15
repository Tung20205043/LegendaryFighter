using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMonoBehaviour : MonoBehaviour
{

    protected virtual void LoadComponents(MonoBehaviour monoBehaviour, GameObject obj) { 
        monoBehaviour = obj.GetComponent<MonoBehaviour>();
    }
}
