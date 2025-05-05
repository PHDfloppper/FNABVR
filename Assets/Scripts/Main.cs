using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    //temps pour une nuit normal (30 secondes/heure): 240
    public static float tempsNuit = 0f;
    //variable qui stock à quelle nuit le joueur est rendu
    public static float nombre_nuit = 0f;

    [SerializeField] private float accelerer = 0f; //accelerer l'écoulement du temps
    [SerializeField] private GameObject win; //gameobject de l'écran de win
    [SerializeField] private GameObject gameover; //gameobject de l'écran de gameover

    [SerializeField] private float suffocation = 150f;  //niveau de suffocation du joueur
    [SerializeField] private Slider sliderSuffoc; //slider du niveau de suffocation
    public static bool porteOuverte = false; //bool qui indique si une des portes est ouverte ou non

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

        //affiche le menu de win si le joueur est en vie à la fin de la nuit
        if (tempsNuit > 240f)
        {
            win.SetActive(true);
        }

        //baisse l'air du joueur si une des portes est fermé
        if (porteOuverte)
        {
            suffocation -= Time.deltaTime;

            sliderSuffoc.value = suffocation;
        }

        //affiche l'écran de gameover si le joueur n'a plus d'air
        if (suffocation < 0f)
        {
            gameover.SetActive(true);
        }
    }
}
