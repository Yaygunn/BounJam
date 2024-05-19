using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public static EndGame Instance { get; private set; }

    [SerializeField] GameObject EndScreen;
    [SerializeField] TextMeshProUGUI text;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayerDeath()
    {
        EndScreen.SetActive(true);
        text.text = KillCounter.Instance.GetEnemyCount().ToString();
        Time.timeScale = 0;
        InputModManager.Instance.UIMod();
        Cursor.visible = true;
        CursorManager.Instance.Death();
        AbilityManager.Instance.CloseAll();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
