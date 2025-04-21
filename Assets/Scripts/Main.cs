using UnityEngine;

public class Main : MonoBehaviour
{

    //temps pour une nuit normal (30 secondes/heure): 240
    public static float tempsNuit = 0f;
    //variable qui stock à quelle nuit le joueur est rendu
    public static float nombre_nuit = 0f;

    [SerializeField] private float accelerer = 0f;
    [SerializeField] private GameObject win;

    private void Start()
    {
        win.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
            tempsNuit += Time.deltaTime;
            tempsNuit += accelerer;
            Debug.LogWarning($"timer: {tempsNuit}");
        if ( tempsNuit > 240f ) 
        {
            Time.timeScale = 0.0f;
            win.SetActive(true);
        }
    }
}
