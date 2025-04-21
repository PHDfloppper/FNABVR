using UnityEngine;

public class CubePersistant : MonoBehaviour
{
    private static CubePersistant instance; //instance du cube

    public static float purpleishAgg = 0f; //aggressivit� de purplish pour la nuit personnalis�
    public static float yellowishAgg = 0f; //aggressivit� de yellowish pour la nuit personnalis�
    public static bool isCustomNight = false; //bool qui d�termine si le joueur a commence une nuit personnalis� ou non

    //awake qui sert � ce que le cube puisse se d�placer entre les sc�nes
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
