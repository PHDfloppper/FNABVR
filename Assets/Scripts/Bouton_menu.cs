using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bouton_Menu : MonoBehaviour
{
    //Gameobject du bouton
    [SerializeField]
    private GameObject bouton;

    //gameobject de la partie du bouton qui bouge
    GameObject presser;

    //bool qui détermine si le bouton est appuyé ou non
    private bool isPressed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "hand")
        {
            //le joueur appuie sur le bouton si le bouton est pas déjà appuié
            if (!isPressed)
            {
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
