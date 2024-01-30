using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScriptPopThingy : MonoBehaviour, IPointerDownHandler
{
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private bool isDestroyed = false;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        switch (gameManagerScript.currentGameMode)
        {
            case 1:
                {
                    break;
                }
            case 2:
                {
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                    Invoke("DestroySelf", 1f);
                    break;
                }
        }
    }

    private void OnBecameInvisible()
    {
        switch (gameManagerScript.currentGameMode)
        {
            case 1:
                {
                    if (isDestroyed != true && gameManagerScript.lives > 0)
                    {
                        gameManagerScript.lives--;
                        Debug.Log("Lives: " + gameManagerScript.lives);
                        gameManagerScript.SpawnPopstacles();
                        Destroy(gameObject);
                    }
                    else if (gameManagerScript.lives <= 0 && isDestroyed != true)
                    {
                        Debug.Log("Invisible");
                        gameManagerScript.GameLost();
                        Destroy(gameObject);
                    }
                    else
                    {
                        gameManagerScript.SpawnPopstacles();
                    }
                    break;
                }
            case 2:
                {
                    if (isDestroyed != true)
                    {
                        if (gameManagerScript.lives > 0)
                        {
                            gameManagerScript.lives--;
                            gameManagerScript.SpawnPopstacles();
                        }
                        else
                        {
                            gameManagerScript.GameLost();
                        }
                    }
                    else
                    {
                        gameManagerScript.SpawnPopstacles();
                    }
                    break;
                }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDestroyed = true;
        Destroy(gameObject);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }


}
