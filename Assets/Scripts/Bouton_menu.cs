using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bouton_Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject bouton;

    GameObject presser;

    private bool isPressed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("collider entre hahahaha");
        if (LayerMask.LayerToName(other.gameObject.layer) == "hand")
        {
            if (!isPressed)
            {
                UnityEngine.Debug.LogWarning("appuyé fuck you");
                bouton.transform.localPosition = new Vector3(0f, 0.090f, 0f);
                presser = other.gameObject;
                isPressed = true;
                SceneManager.LoadScene(sceneName: "SampleScene");
            }
        }

    }

    private IEnumerator ResetButtonPosition()
    {
        yield return new WaitForSeconds(1f);
        bouton.transform.localPosition = new Vector3(0f, 0.179f, 0f);
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
