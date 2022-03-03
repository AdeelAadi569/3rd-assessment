using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
    public float speed;
    private Rigidbody playerrb;
    public Material greencolor;
    public float counter=2,zboundry=6,xbpundry=-3;
    bool move=true;
    public GameObject player;
    public GameObject [] poss;
    public int score;
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        score=0;
        playerrb=GetComponent<Rigidbody>();
        scoretext.text="Score :"+score;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w") && move==true){
            transform.Translate(Vector3.right*speed*Time.deltaTime);
        }
        if(Input.GetKey("s")){
            transform.Translate(Vector3.left*speed*Time.deltaTime);
        }
         if(Input.GetKey("a")){
            transform.Translate(Vector3.forward*speed*Time.deltaTime);
        }
         if(Input.GetKey("d")){
            transform.Translate(Vector3.back*speed*Time.deltaTime);
        }
        // var horizontal=Input.GetAxis("Horizontal");
        // var vertical=Input.GetAxis("Vertical");
        // if(move==true){
        //    // transform.Translate()
        // playerrb.AddForce(Vector3.right*vertical*speed,ForceMode.Impulse);
        //  playerrb.AddForce(Vector3.forward*horizontal*speed,ForceMode.Impulse);
        // }
        // else{
        //     playerrb.velocity=Vector3.zero;
        // }
        
        if(transform.position.z<=-zboundry){
            transform.position=new Vector3(transform.position.x,transform.position.y,-zboundry);
            playerrb.velocity=Vector3.zero;
        }
        if(transform.position.z>zboundry){
            transform.position=new Vector3(transform.position.x,transform.position.y,zboundry);
            playerrb.velocity=Vector3.zero;
        }
        if(transform.position.x<xbpundry){
            transform.position=new Vector3(xbpundry,transform.position.y,transform.position.z);
            playerrb.velocity=Vector3.zero;
        }
        
        if(counter>0){
            move=true;
        }
        if(counter<0){
            move=false;
        }

        
    }
    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag=="green")
        {
            //counter-=1;
            if(counter>0){
                counter--;
                score-=25;
                scoretext.text="Score :"+score;
            col.GetComponent<Renderer>().material=greencolor;
           // move=true;
            }
             if(counter==0 && transform.position.x>4.8f){
               move=false;
            //   var getposplayer=GameObject.Find("player").transform.position;
              
            //  // transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z);
             }
            //  if(transform.position.x<4){
            //      move=true;
            //  }
            //else
            //{
              //  move=true;
                
            //}
        }
       
        if(col.gameObject.tag=="againmove")  {
            move=true;
            Debug.Log("chk bool"+move);
        }   
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag=="greenbrick"){
            Destroy(col.gameObject);
          counter++;
          score+=25;
          scoretext.text="Score :"+score;
            for(int l=0;l<poss.Length;l++){
                
                 col.gameObject.transform.position=poss[l].transform.position;
            }
        }
    }
}
