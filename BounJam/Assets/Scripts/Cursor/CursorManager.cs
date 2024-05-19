using UnityEngine;

public enum E_CursorState { none, makas, node, rope}
public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance { get; private set; } 

    [SerializeField] private CursorData UICursor;

    [SerializeField] private GameObject ParentCursor;
    [SerializeField] private GameObject MakasCursor;
    [SerializeField] private GameObject NodeCursor;
    [SerializeField] private GameObject RopeCursor;
    bool alive = true;

    private void Awake()
    {
        Instance = this;
        UIMod();
    }
    private void Update()
    {
        if(alive)
            ParentCursor.transform.position = MouseDetection.Instance.GetMousePosition();
    }
    
    private void UIMod()
    {
        ChangeCursor(UICursor);
    }

    private void ChangeCursor(CursorData cursorData)
    {
        Cursor.SetCursor(cursorData.cursorTexture, cursorData.hotSpot, CursorMode.Auto);
    }

    public void ChangeCursorState(E_CursorState state)
    {
        if(state == E_CursorState.none)
        {
            ParentCursor.SetActive(false);
            ShowCursor();
            return;
        }
        HideCursor();
        ParentCursor.SetActive(true);
        HideChildCursors();
        switch (state)
        {
            case E_CursorState.makas:
                MakasCursor.SetActive(true); break;
            case E_CursorState.rope: 
                RopeCursor.SetActive(true);break;
            case E_CursorState.node:
                NodeCursor.SetActive(true); break;
        }
    }

    private void HideChildCursors()
    {
        MakasCursor.SetActive(false);
        NodeCursor.SetActive(false);
        RopeCursor.SetActive(false);
    }
    private void ShowCursor()
    {
        Cursor.visible = true;
    }
    private void HideCursor()
    {
        Cursor.visible = false;
    }
    public void Death()
    {
        Destroy(ParentCursor);
        alive = false;
    }
}
