using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Bouton_Porte : MonoBehaviour
{
    [SerializeField]
    private GameObject bouton;

    GameObject presser;

    private bool isPressed;


    [SerializeField]
    private Animator animation_porte;
    [SerializeField]
    private bool is_porte_gauche;

    public bool porte_gauche_ouverte = true;
    public bool porte_droite_ouverte = true;

    [SerializeField]
    private AudioSource gaucheOuvre;
    [SerializeField]
    private AudioSource gaucheFerme;
    [SerializeField]
    private AudioSource droiteOuvre;
    [SerializeField]
    private AudioSource droiteFerme;
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
                animation_porte.SetTrigger("ouvrir");
                animation_porte.SetTrigger("ouvrir");
                if (is_porte_gauche == true)
                {
                    if (porte_gauche_ouverte == true) { gaucheFerme.Play(); porte_gauche_ouverte = false; }
                    else { porte_gauche_ouverte = true; gaucheOuvre.Play(); }
                }
                else
                {
                    if (porte_droite_ouverte == true) { droiteFerme.Play(); porte_droite_ouverte = false; }
                    else { porte_droite_ouverte = true; droiteOuvre.Play(); }
                }
                StartCoroutine(ResetButtonPosition());
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
