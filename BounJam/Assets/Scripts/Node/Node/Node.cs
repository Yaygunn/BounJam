using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Node : BaseNode
{
    public BaseRope SelectRope(Vector2 direction)
    {
        direction.Normalize();

        float minDot = -2;
        BaseRope minRope = null;

        foreach(BaseRope rope in RopeDictionary.Keys)
        {
            float dot = math.dot(direction, RopeDictionary[rope]);
            if (dot > minDot)
            {
                minDot = dot;
                minRope = rope;
            }
        }
        if(minDot>0.1)
            return minRope;
        return null;
    }

    public void CharacterEntered(GameObject character)
    {
        StartCoroutine(TakeCharacterToCenter(character));
    }

    IEnumerator TakeCharacterToCenter(GameObject character)
    {
        float speed = 5;
  
        Vector3 direction = transform.position - character.transform.position;
        while (true)
        {
            yield return null;
            character.transform.position += direction * speed * Time.deltaTime;
            
            float dot = math.dot((transform.position-character.transform.position), direction);
            if (dot <= 0)
            {
                character.transform.position = transform.position;
                CharacterIsOnNode();
                break;
            }
        }
    }
    private void CharacterIsOnNode()
    {
        print("CharacterIsOnNode");
    }
}
