using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Bouton_Porte : MonoBehaviour
{
    //Gameobject du bouton
    [SerializeField]
    private GameObject bouton;

    //gameobject de la partie du bouton qui bouge
    GameObject presser;

    //bool qui d�termine si le bouton est appuy� ou non
    private bool isPressed;

    //stock l'animator de la porte (pour l'ouvrir et la fermer)
    [SerializeField]
    private Animator animation_porte;
    // bool qui d�termine si le script est sur la porte de droite ou gauche
    [SerializeField]
    private bool is_porte_gauche;

    //bools qui d�termine si les portes sont ouvertes ou non
    public bool porte_gauche_ouverte = true;
    public bool porte_droite_ouverte = true;

    //variables des sons des portes
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
        if (LayerMask.LayerToName(other.gameObject.layer) == "hand")
        {
            //le joueur appuie sur le bouton si le bouton est pas d�j� appui�
            if (!isPressed)
            {
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

    //remet la partie qui bouge du bouton comme elle �tait avant d'�tre appuy�
    private IEnumerator ResetButtonPosition()
    {
        yield return new WaitForSeconds(1f);
        bouton.transform.localPosition = new Vector3(0f, 0.179f, 0f);
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (porte_droite_ouverte || porte_gauche_ouverte) { Main.porteOuverte = true; }
        else { Main.porteOuverte = false; }
    }
}
