using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }

    [SerializeField] GameObject spawnObject;
    [SerializeField] GameObject EnemyObject;
    [SerializeField] bool spawn;
    List<BaseRope> ropeList= new List<BaseRope>();
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(EnemySpawning());
        StartCoroutine(SpawnResource());
    }

    private void Update()
    {
        if(spawn)
        {
            spawn = false;
            SpawnEnemy();
        }
    }

    public void AddRope(BaseRope rope)
    {
        ropeList.Add(rope);
    }
    public void RemoveRope(BaseRope rope)
    {
        ropeList.Remove(rope);
    }
    IEnumerator SpawnResource()
    {
        yield return new WaitForSeconds(3);
            float spawntime = 13;
        while (true)
        {
            SpawnAResource();
            yield return new WaitForSeconds(spawntime);
        }
    }
    public void SpawnAResource()
    {
        BaseRope rope = SelectRandomRope();
        GameObject objec = SpawnOnRope(rope, spawnObject);
    }
    IEnumerator EnemySpawning()
    {
        yield return new WaitForSeconds(3);
        float spawntime = 7;
        while (true)
        {
            SpawnEnemy() ;
            spawntime -= 0.2f;
            spawntime = math.max(spawntime, 4.5f);
            yield return new WaitForSeconds(spawntime);
        }
    }
    public void SpawnEnemy()
    {
        BaseRope rope = SelectRandomRope();
        GameObject obje = SpawnOnRope(rope, EnemyObject);
        obje.GetComponent<Enemy>().Initiate( rope);
    }

    private GameObject SpawnOnRope(BaseRope rope, GameObject spawnobje)
    {
        return Instantiate(spawnobje, DecidePosition(rope), Quaternion.identity);
    }
    private Vector3 DecidePosition(BaseRope rope)
    {
        BaseNode[] nodes = rope.GetNodes();
        float rand = UnityEngine.Random.Range(0.2f, 0.8f);
        return Vector3.Lerp(nodes[0].transform.position, nodes[1].transform.position, rand);
    }

    private BaseRope SelectRandomRope()
    {
        return ropeList[UnityEngine.Random.Range(0,ropeList.Count)];
    }
}
