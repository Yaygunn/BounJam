using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public static KillCounter Instance {  get; private set; }
    [SerializeField] TextMeshProUGUI text;
    int counter = 0;

    private void Awake()
    {
        Instance = this;
    }
    public void EnemyDied()
    {
        counter++;
        text.text = counter.ToString();
    }

    public int GetEnemyCount()
    {
        return counter;
    }
}
