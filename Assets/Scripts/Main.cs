using UnityEngine;

public class Main : MonoBehaviour
{

    //temps pour une nuit normal (30 secondes/heure): 240
    public static float tempsNuit = 0f;
    //variable qui stock à quelle nuit le joueur est rendu
    public static float nombre_nuit = 0f;


    // Update is called once per frame
    void Update()
    {
        if (tempsNuit <= 240)
        {
            tempsNuit += Time.deltaTime;
            //tempsNuit += 0.02f;
            //Debug.Log($"timer: {tempsNuit}");
        }
    }
}
