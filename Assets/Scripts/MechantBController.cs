using UnityEngine;

public class MechantBController : MonoBehaviour
{
    //les positions o� purpleish peut �tre
    [SerializeField]
    private GameObject mechant;
    [SerializeField]
    private GameObject[] mechantPOS;
    private int positionActuelle;

    //stock le bouton de la porte
    [SerializeField] private Bouton_Porte porte;

    //stock le gameobject d'�cran de gameover
    [SerializeField] private GameObject gameover;

    //variable qui stock la valeur de l'agressivit� de purpleish. �a va de 0 � 20.
    [SerializeField]
    private float aggressivite = 0;

    //variable qui indique au gameobject de purpleish qu'il peut faire une nouvelle tentative de mouvement
    bool canMove_ = true;

    //stock la manette vr de droite
    [SerializeField]
    private OVRInput.Controller controllerR = OVRInput.Controller.RTouch;

    //amplitude de la vibration
    [SerializeField]
    private float amplitude = 1.0f;
    //duration de la vibration
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

    /// <summary>
    /// g�re quand le m�chant est dans le couloir. le code d�termine si le m�chant peut attaque le joueur si la porte est ouverte (aller dans le bureau)
    /// ou si la porte est ferm�, le m�chant va dans une autre position
    /// </summary>
    void coulloir()
    {
        if (!porte.porte_droite_ouverte)
        {
            int rando_ = UnityEngine.Random.Range(0, 26);
            if (rando_ <= 10) { positionActuelle = 0; }
            else if (rando_ > 10 && rando_ <= 20) { positionActuelle = 1; }
            else if (rando_ > 10 && rando_ > 20) { positionActuelle = 2; }
        }
        else if (porte.porte_droite_ouverte)
        {
            positionActuelle += 1;
            canMove();
            gameover.SetActive(true);

        }
    }

    //fonction qui d�termine si purpleish peut bouger ou non, selon son agressivit�.
    //fonctionne comme un d20 dans dnd
    void move()
    {
        int rand_ = UnityEngine.Random.Range(1, 20);
        if (aggressivite >= rand_ && !gameover.activeSelf)
        {
            if (positionActuelle == 2)
            {
                Invoke("coulloir", 5f);
            }
            else if (positionActuelle < 2) { positionActuelle += 1; }

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
        if(positionActuelle == 2)
        {
            OVRInput.SetControllerVibration(1, amplitude, controllerR);
        }
        else
        {
            OVRInput.SetControllerVibration(0, 0, controllerR);
        }

        GestionAgressivite();
        if (Main.tempsNuit <= 240)
        {
            if (canMove_ == true)
            {
                float rand_ = UnityEngine.Random.Range(1, 20);
                canMove_ = false;
                Invoke("move", 7f);
            }
        }

        if (CubePersistant.isCustomNight)
        {
            aggressivite = CubePersistant.purpleishAgg;
        }
    }
}
