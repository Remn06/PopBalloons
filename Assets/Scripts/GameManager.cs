using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject popThingy;
    public int lives = 3;
    public Canvas menuCanvas;
    public int currentGameMode;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void SpawnPopstacles()
    {
        switch (currentGameMode)
        {
            case 1:
                {
                    Instantiate(popThingy, new Vector3(Random.Range(-2.25f, 2.25f), Random.Range(3f, 4.5f)), Quaternion.Euler(0f, 0f, 0f));
                    break;
                }
            case 2:
                {
                    Instantiate(popThingy, new Vector3(Random.Range(-2.25f, 2.25f), Random.Range(-4.5f, 4.5f)), Quaternion.Euler(0, 0, Random.Range(-180f, 180f)));
                    break;
                }
        }
    }

    public void FallingPopstacles()
    {
        currentGameMode = 1;
        lives = 3;
        menuCanvas.gameObject.SetActive(false);
        SpawnPopstacles();
    }

    public void StandingPopstackles()
    {
        currentGameMode = 2;
        lives = 3;
        menuCanvas.gameObject.SetActive(false);
        SpawnPopstacles();
    }

    public void GameLost()
    {
        currentGameMode = 0;
        menuCanvas.gameObject.SetActive(true);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
