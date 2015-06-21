using UnityEngine;
using System.Collections;

public class TogleObjectButton : MonoBehaviour {

    public void ToggleObject(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
