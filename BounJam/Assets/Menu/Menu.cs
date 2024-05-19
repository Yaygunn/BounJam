using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] bool ShowMenu;
    [SerializeField] GameObject MenuCanvas;

    [SerializeField] Button button;

    private void Start()
    {
        if (!ShowMenu)
        {
            Play();
        }
        else
        {
            MenuCanvas.SetActive(true);
            Time.timeScale = 0;
            InputModManager.Instance.UIMod();
            Cursor.visible = true;
        }
    }

    private void MouseCheck()
    {
         MouseDetection.Instance.GetMousePosition();
    }
    public void HoverOn()
    {
        AudioManager.Instance.HoverOn();
    }

    public void HoverOff()
    {
        AudioManager.Instance.Hoverof();
    }
    public void Click()
    {
        AudioManager.Instance.Success();
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
    public void Play()
    {
        MenuCanvas.SetActive(false);
        InputModManager.Instance.GamePlayMod();
        Time.timeScale = 1;
        Cursor.visible = false;
    }
}
