using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField] private bool porteGauche;
    [SerializeField] private bool porteDroite;

    [SerializeField] private GameObject porteGaucheCube;
    [SerializeField] private GameObject porteDroiteCube;

    private void Start()
    {
        porteDroiteCube.SetActive(false);
        porteGaucheCube.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(porteDroite) { porteDroiteCube.SetActive(true); }
        else if (!porteDroite) { porteDroiteCube.SetActive(false); }
        if (porteGauche) { porteGaucheCube.SetActive(true); }
        if (!porteGauche) { porteGaucheCube.SetActive(false); }
    }
}
