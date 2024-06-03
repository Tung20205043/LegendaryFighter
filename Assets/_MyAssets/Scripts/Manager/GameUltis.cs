using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public static class GameUltis {

    public static void ReplaceArrayElements<T>(T[] a, T[] b) {
        if (a.Length != b.Length) {
            Debug.LogError("Both arrays must have the same number of elements.");
            return;
        }

        for (int i = 0; i < a.Length; i++) {
            a[i] = b[i];
        }
    }
    public static void ShowObjInArray(int value, GameObject[] gameObjects) {
        foreach (var gameObject in gameObjects) {
            gameObject.SetActive(false);
        }
        gameObjects[value].SetActive(true);
    }
    public static IEnumerator IEDelayCall(float time, Action Callback) {
        yield return new WaitForSeconds(time);
        Callback?.Invoke();
    }

    public static int RandomNumber(int a, int b) {
        return UnityEngine.Random.Range(a, b + 1);
    }
    public static T GetComponentFromObject<T>(GameObject obj) where T : Component {
        return obj.GetComponent<T>();
    }


    public static int GenerateRandomValue(int startValue, int endValue, int[] notTargetValues) {
        int randomValue;

        do {
            randomValue = UnityEngine.Random.Range(startValue, endValue + 1);
        } while (notTargetValues.Contains(randomValue));

        return randomValue;
    }


    public static void CreateContainer(this MonoBehaviour mono, string name, ref Transform trans) {
        GameObject obj = new GameObject(name);
        obj.transform.parent = mono.transform;
        trans = obj.transform;
    }

    public static string ObjectName(GameObject obj) {
        return obj.name.Replace("(Clone)", "");
    }

    public static void SetParent(GameObject obj, Transform parent) {
        obj.transform.SetParent(parent, false);
    }
    public static void Hide(GameObject obj) {
        obj.gameObject.SetActive(false);
    }
    public static void Show(GameObject obj) {
        obj.gameObject.SetActive(true);
    }
    public static bool ExitScreen(Vector3 currentPosition) {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(currentPosition);
        return (screenPosition.x < 0 || screenPosition.x > Screen.width || screenPosition.y < 0 || screenPosition.y > Screen.height * 2);
    }


    public static bool ExitLeftScreen(Vector3 currentPosition) {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(currentPosition);
        return (screenPosition.x < 0);
    }
    public static bool ExitRightScreen(Vector3 currentPosition) {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(currentPosition);
        return (screenPosition.x > Screen.width);
    }
}
