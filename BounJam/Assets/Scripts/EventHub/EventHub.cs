using System;

public static class EventHub 
{
    public static event Action<Node> E_PlayerNode;

    public static void PlayerNode(Node node)
    {
        E_PlayerNode?.Invoke(node);
    }

    public static event Action E_AbilityChange;

    public static void AbilityChange()
    {
        E_AbilityChange?.Invoke();
    }

    public static event Action E_GamePlay;

    public static void GamePlay()
    {
        E_GamePlay?.Invoke();
    }
    public static event Action E_UI;

    public static void UI()
    {
        E_UI?.Invoke();
    }
}
