using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyrb;
    public float range;
    public GameObject leftpos,rightpos;
    public bool left,right;
    // Start is called before the first frame update
    void Start()
    {
        enemyrb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(left==true){
            transform.Translate(Vector3.back*speed*Time.deltaTime);
            //enemyrb.AddForce(Vector3.forward*speed,ForceMode.Impulse);
            //right=false;
        }
        if(right==true){
            transform.Translate(Vector3.forward*speed*Time.deltaTime);
            //enemyrb.AddForce(Vector3.back*speed,ForceMode.Impulse);
            //left=false;
        }
    }
    public void OnCollisionEnter(Collision col){
        if(col.gameObject.tag=="left"){
            left=true;
            right=false;
        }
        if(col.gameObject.tag=="right"){
            right=true;
            left=false;
        }
    }
}
