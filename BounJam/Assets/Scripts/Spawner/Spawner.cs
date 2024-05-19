using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] BaseRope rope;
    [SerializeField] GameObject spawnObject;
    [SerializeField] bool spawn;
    void Start()
    {
        
    }

    private void Update()
    {
        if(spawn)
        {
            spawn = false;
            SpawnOnRope(rope, spawnObject);
        }
    }

    private void SpawnOnRope(BaseRope rope, GameObject spawnobje)
    {
        Instantiate(spawnObject, DecidePosition(rope), Quaternion.identity);
    }
    private Vector3 DecidePosition(BaseRope rope)
    {
        BaseNode[] nodes = rope.GetNodes();
        float rand = Random.Range(0.12f, 0.88f);
        return Vector3.Lerp(nodes[0].transform.position, nodes[1].transform.position, rand);
    }
}
