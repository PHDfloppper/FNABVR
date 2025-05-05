using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    //temps pour une nuit normal (30 secondes/heure): 240
    public static float tempsNuit = 0f;
    //variable qui stock à quelle nuit le joueur est rendu
    public static float nombre_nuit = 0f;

    [SerializeField] private float accelerer = 0f;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject gameover;

    [SerializeField] private float suffocation = 150f;
    [SerializeField] private Slider sliderSuffoc;
    public static bool porteOuverte = false;

    private void Start()
    {
        tempsNuit = 0f;
        win.SetActive(false);
        gameover.SetActive(false);
        sliderSuffoc.maxValue = suffocation;
        sliderSuffoc.value = suffocation;
    }

    // Update is called once per frame
    void Update()
    {
        tempsNuit += Time.deltaTime;
        tempsNuit += accelerer;
        //Debug.LogWarning($"timer: {tempsNuit}");
        if (tempsNuit > 240f)
        {
            win.SetActive(true);
        }

        if(porteOuverte)
        {
            suffocation -= Time.deltaTime;

            sliderSuffoc.value = suffocation;
        }

        if(suffocation < 0f)
        {
            gameover.SetActive(true);
        }
    }
}
