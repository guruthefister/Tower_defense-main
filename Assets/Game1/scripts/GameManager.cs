using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject GameOverUI;

    void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            EndGame();
        }

        if(PlayerStats.Health <= 0)
        {
            EndGame();
        }
    }

    void EndGame ()
    {
        GameIsOver = true;
        GameOverUI.SetActive(true);
    }
}
