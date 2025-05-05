using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonPorte : MonoBehaviour
{
    //variables qui stock les gameobject des caméra (la télé dans le bureau)
    [SerializeField] private GameObject CamA1;
    [SerializeField] private GameObject CamA2;
    [SerializeField] private GameObject CamB1;
    [SerializeField] private GameObject CamB2;

    //bools qui déterminent à quel gamebobject de cam le script est attaché
    [SerializeField] private bool isCamA1;
    [SerializeField] private bool isCamA2;
    [SerializeField] private bool isCamB1;
    [SerializeField] private bool isCamB2;

    //Gameobject du bouton
    [SerializeField]
    private GameObject bouton;

    //gameobject de la partie du bouton qui bouge
    GameObject presser;

    //bool qui détermine si le bouton est appuyé ou non
    private bool isPressed;
    void Start()
    {
        isPressed = false;
        CamA1.SetActive(true);
    }

    //désactive tout les écrans de cam
    private void DesactiveCam()
    {
        CamA1.SetActive(false);
        CamB1.SetActive(false);
        CamA2.SetActive(false);
        CamB2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "hand")
        {
            //le joueur appuie sur le bouton si le bouton est pas déjà appuié
            if (!isPressed)
            {
                if (isCamA1) 
                { 
                    DesactiveCam();
                    CamA1.SetActive(true);
                }
                else if (isCamA2)
                {
                    DesactiveCam();
                    CamA2.SetActive(true);
                }
                else if (isCamB1)
                {
                    DesactiveCam();
                    CamB1.SetActive(true);
                }
                else if (isCamB2)
                {
                    DesactiveCam();
                    CamB2.SetActive(true);
                }
            }
            bouton.transform.localPosition = new Vector3(0f, 0.090f, 0f);
            presser = other.gameObject;
            isPressed = true;
            StartCoroutine(ResetButtonPosition());
        }

    }

    //remet la partie qui bouge du bouton comme elle était avant d'être appuyé
    private IEnumerator ResetButtonPosition()
    {
        yield return new WaitForSeconds(1f);
        bouton.transform.localPosition = new Vector3(0f, 0.179f, 0f);
        isPressed = false;
    }
}
