using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    public GameObject greenbrick;
    public GameObject [] greenbrickpos;
    public GameObject redbrick;
    public GameObject [] redbrickpos;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnBricks",1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnBricks(){
        for (int i = 0; i < greenbrickpos.Length; i++)
        {
            Instantiate(greenbrick,greenbrickpos[i].transform.position,greenbrick.transform.rotation);
        }
        
        for (int j = 0; j < redbrickpos.Length; j++)
        {
            Instantiate(redbrick,redbrickpos[j].transform.position,redbrick.transform.rotation);
        }
    }
}
