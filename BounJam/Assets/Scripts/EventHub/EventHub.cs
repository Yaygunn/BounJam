using System;

public static class EventHub 
{
    public static event Action<Node> E_PlayerNode;

    public static void PlayerNode(Node node)
    {
        E_PlayerNode?.Invoke(node);
    }
}
