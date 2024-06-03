using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameUltis;

public class AvtImgTourController : MonoBehaviour
{
    [SerializeField] GameObject[] avtImg;

    public void ShowImg(CharacterToChoose character) {
        ShowObjInArray((int)character, avtImg);
    }
}
