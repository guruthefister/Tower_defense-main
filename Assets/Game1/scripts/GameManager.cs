using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject GameOverUI;

    private void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if (Input.GetKeyDown("e"))
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
