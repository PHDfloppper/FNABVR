using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private TextMeshProUGUI instruction; //variale text qui stock le temps actuel de la nuit
    // Start is called before the first frame update
    void Start()
    {
        instruction = GetComponent<TextMeshProUGUI>();
        instruction.text = "test";
    }

    // update qui met à jour le temps de la nuit au fur et à mesure que le joueur survie
    void Update()
    {
        float timer = Main.tempsNuit;
        if (timer <= 30)
        {
            instruction.text = "12 am";
        }
        else if (timer >= 30 && timer <= 60)
        {
            instruction.text = "1 am";
        }
        else if (timer >= 60 && timer <= 90)
        {
            instruction.text = "2 am";
        }
        else if (timer >= 120 && timer <= 150)
        {
            instruction.text = "3 am";
        }
        else if (timer >= 180 && timer <= 210)
        {
            instruction.text = "4 am";
        }
        else if (timer >= 210)
        {
            instruction.text = "5 am";
        }
        //à 240 secondes, la nuit est fini
    }
}
