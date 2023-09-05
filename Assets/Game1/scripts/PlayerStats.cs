using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 400;

    public static int Health;
    public int startHealth = 20;

    public static int Rounds;

    void Start() 
    {
        Money = startMoney;
        Health = startHealth;

        Rounds = 0;
    }

}
