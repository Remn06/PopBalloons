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
    }

    private void OnBecameInvisible()
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
        } else
        {
            gameManagerScript.SpawnPopstacles();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDestroyed = true;
        Destroy(gameObject);
    }
}
