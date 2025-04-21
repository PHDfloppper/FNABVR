using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonPorte : MonoBehaviour
{
    [SerializeField] private GameObject CamA1;
    [SerializeField] private GameObject CamA2;
    [SerializeField] private GameObject CamB1;
    [SerializeField] private GameObject CamB2;

    [SerializeField] private bool isCamA1;
    [SerializeField] private bool isCamA2;
    [SerializeField] private bool isCamB1;
    [SerializeField] private bool isCamB2;

    [SerializeField]
    private GameObject bouton;

    GameObject presser;

    private bool isPressed;
    void Start()
    {
        isPressed = false;
        CamA1.SetActive(true);
    }

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

    private IEnumerator ResetButtonPosition()
    {
        yield return new WaitForSeconds(1f);
        bouton.transform.localPosition = new Vector3(0f, 0.179f, 0f);
        isPressed = false;
    }
}
