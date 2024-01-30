using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject popThingy;
    public int lives = 3;
    public Canvas menuCanvas;

    void Start()
    {
        Application.targetFrameRate = 60;
    }
    
    public void SpawnPopstacles()
    {
        Instantiate(popThingy, new Vector3(Random.Range(-2.25f, 2.25f), Random.Range(3f, 4.5f)), Quaternion.Euler(0f, 0f, 0f));
    }

    public void FallingPopstacles()
    {
        lives = 3;
        menuCanvas.gameObject.SetActive(false);
        SpawnPopstacles();
    }
    
    public void GameLost()
    {
        menuCanvas.gameObject.SetActive(true);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
