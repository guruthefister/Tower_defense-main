using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyUI : MonoBehaviour {

    public Text moneyText;

    // Update is called once per frame
    void Update() {
        moneyText.text = PlayerStats.Money.ToString() + " $";

        int charIndex = moneyText.text.IndexOf("$");
        moneyText.text = moneyText.text.Replace(moneyText.text[charIndex].ToString(), "<color=#4DFF00>" + 
            moneyText.text[charIndex].ToString() + "</color>");
    }
}
