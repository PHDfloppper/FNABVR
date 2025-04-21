using UnityEngine;

public class CubePersistant : MonoBehaviour
{
    private static CubePersistant instance; //instance du cube

    public static float purpleishAgg = 0f; //aggressivité de purplish pour la nuit personnalisé
    public static float yellowishAgg = 0f; //aggressivité de yellowish pour la nuit personnalisé
    public static bool isCustomNight = false; //bool qui détermine si le joueur a commence une nuit personnalisé ou non

    //awake qui sert à ce que le cube puisse se déplacer entre les scènes
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        //Debug.Log(isCustomNight);
    }
}
