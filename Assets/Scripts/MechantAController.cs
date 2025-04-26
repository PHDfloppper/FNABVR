using System;
using UnityEngine;
using UnityEngine.Events;

public class MechantAController : MonoBehaviour
{
    //les positions o� purpleish peut �tre
    [SerializeField]
    private GameObject mechant;
    [SerializeField]
    private GameObject[] mechantPOS;
    private int positionActuelle;

    [SerializeField] private Bouton_Porte porte;

    [SerializeField] private GameObject gameover;

    //variable qui stock la valeur de l'agressivit� de purpleish. �a va de 0 � 20.
    [SerializeField]
    private float aggressivite = 0;

    //variable qui indique au gameobject de purpleish qu'il peut faire une nouvelle tentative de mouvement
    bool canMove_ = true;

    [SerializeField]
    private OVRInput.Controller controllerL = OVRInput.Controller.LTouch;

    [SerializeField]
    private float amplitude = 1.0f;
    [SerializeField]
    private float duration = 0.2f;


    private void Start()
    {
        gameover.SetActive(false);
        positionActuelle = 0;
        mechant.transform.position = mechantPOS[positionActuelle].transform.position;
        mechant.transform.rotation = mechantPOS[positionActuelle].transform.rotation;

        if (CubePersistant.isCustomNight)
        {
            aggressivite = CubePersistant.purpleishAgg;
        }
        else if (!CubePersistant.isCustomNight)
        {
            //if qui indique l'agressivit� de d�but pour chaque nuit
            if (Main.nombre_nuit == 1f)
            {
                aggressivite = 1f;
            }
            else if (Main.nombre_nuit == 2f)
            {
                aggressivite = 3f;
            }
            else if (Main.nombre_nuit == 3f)
            {
                aggressivite = 0f;
            }
            else if (Main.nombre_nuit == 4f)
            {
                aggressivite = 2f;
            }
            else if (Main.nombre_nuit == 5f)
            {
                aggressivite = 5f;
            }
        }
    }

    //fonction qui change la position de purpleish
    //pour l'instant, il y a une instantiation de purpleish dans chaque position mais ils sont tous invisibles.
    //si purpleish doit �tre � une certaine position, l'instance de purpleish � la position voulu devien visible
    void canMove()
    {

        mechant.transform.position = mechantPOS[positionActuelle].transform.position;
        mechant.transform.rotation = mechantPOS[positionActuelle].transform.rotation;
    }

    //fonction qui d�termine si purpleish peut bouger ou non, selon son agressivit�.
    //fonctionne comme un d20 dans dnd
    void move()
    {
        int rand_ = UnityEngine.Random.Range(1, 20);
        if (aggressivite >= rand_)
        {
            if (positionActuelle < 2) { positionActuelle += 1; }
            OVRInput.SetControllerVibration(0, 0, controllerL);
            if (positionActuelle == 2)
            {
                OVRInput.SetControllerVibration(1, amplitude, controllerL);
            }
            if (positionActuelle == 2 && !porte.porte_gauche_ouverte)
            {
                int rando_ = UnityEngine.Random.Range(0, 1);
                positionActuelle = rando_;
            }
            else if (positionActuelle == 2 && porte.porte_gauche_ouverte)
            {
                positionActuelle += 1;
                gameover.SetActive(true);

            }

            canMove();
        }
        canMove_ = true;
    }

    //fonction qui g�re l'agressivit� de purpleish, l'agressivit� augmente plus que la nuit avance
    //l'agressivit� est techniquement limit� � 20. L'agressivit� est cod� de mani�re que pass� 20, il n'y a plus aucune diff�rence d'agressivit�.
    void GestionAgressivite()
    {
        float timer = Main.tempsNuit;
        if (timer == 30)
        {
            aggressivite += 1;
        }
        else if (timer == 60)
        {
            aggressivite += 1;
        }
        else if (timer == 120)
        {
            aggressivite += 1;
        }
    }

    void Update()
    {
        //if (MenuDev.hudTricheActif == true) { activerCheat.Invoke(); }
        //else { desactiverCheat.Invoke(); }

        GestionAgressivite();
        if (Main.tempsNuit <=240)
        {
            if (canMove_ == true)
            {
                float rand_ = UnityEngine.Random.Range(1, 20);
                canMove_ = false;
                Invoke("move", 4.6f);
            }
        }

        if (CubePersistant.isCustomNight)
        {
            aggressivite = CubePersistant.purpleishAgg;
        }

        UnityEngine.Debug.Log(positionActuelle);
    }
}
