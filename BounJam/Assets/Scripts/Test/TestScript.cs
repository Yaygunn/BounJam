using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputGameplay.Instance.E_SprintStart += Sprint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Sprint()
    {
        print("sprint");
    }
}
