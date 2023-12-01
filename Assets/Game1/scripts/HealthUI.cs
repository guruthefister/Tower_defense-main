using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text healthText;

    // Update is called once per frame
    void Update()
    {
        healthText.text = PlayerStats.Health.ToString() + " <color=#FF1100>\u2764</color>";
    }
}
