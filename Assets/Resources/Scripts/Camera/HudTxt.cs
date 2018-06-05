using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudTxt : MonoBehaviour {
    private void OnEnable()
    {
        StartCoroutine("Disappear");
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }
}
