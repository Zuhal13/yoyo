using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOver GameOver;
    int maxPlatform = 0;

    public void GameOverScreen()
    {
        GameOver.Setup(maxPlatform);
    }
  




}

