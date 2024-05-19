using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    [SerializeField] bool ChangeScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(ChangeScale)
        {
            transform.localScale = originalScale * 1.2f; 
        }
        AudioManager.Instance.HoverOn();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale; 
        AudioManager.Instance.Hoverof();
    }
}
