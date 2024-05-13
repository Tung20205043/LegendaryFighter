using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamehaHeadObj : MonoBehaviour
{
    [SerializeField] GameObject kamehaTail;
    [SerializeField] GameObject kamehaBody;
    private void OnEnable() {
        kamehaTail.transform.localPosition = this.transform.localPosition;
        kamehaBody.transform.localPosition= this.transform.localPosition;
    }
}
