using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour {
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject Text;

    private void OnTriggerEnter(Collider other)
    {
        CharController.Instance.SetLookRotate(false);
        Camera.SetActive(true);
        if (Text)
            Text.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        CharController.Instance.SetLookRotate(true);
        Camera.SetActive(false);
    }
}
