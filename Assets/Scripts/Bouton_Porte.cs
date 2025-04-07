using System;
using System.Diagnostics;
using UnityEngine;

public class Bouton_Porte : MonoBehaviour
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
        if (!isPressed)
        {
            UnityEngine.Debug.LogWarning("appuyé fuck you");
            bouton.transform.localPosition = new Vector3(0f,0.090f,0f);
            presser = other.gameObject;
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == presser)
        {
            bouton.transform.localPosition = new Vector3(0f, 0.179f, 0f);
            isPressed = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
