using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public static EndGame Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void PlayerDeath()
    {
        ReloadScene();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
