using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] BaseRope rope;
    [SerializeField] GameObject spawnObject;
    [SerializeField] GameObject EnemyObject;
    [SerializeField] bool spawn;
    void Start()
    {
        
    }

    private void Update()
    {
        if(spawn)
        {
            spawn = false;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        GameObject obje = SpawnOnRope(rope, EnemyObject);
        obje.GetComponent<Enemy>().Initiate( rope);
    }

    private GameObject SpawnOnRope(BaseRope rope, GameObject spawnobje)
    {
        return Instantiate(spawnObject, DecidePosition(rope), Quaternion.identity);
    }
    private Vector3 DecidePosition(BaseRope rope)
    {
        BaseNode[] nodes = rope.GetNodes();
        float rand = Random.Range(0.2f, 0.8f);
        return Vector3.Lerp(nodes[0].transform.position, nodes[1].transform.position, rand);
    }
}
