using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner_container : MonoBehaviour
{
     
    public float playerSpeed = 2f;

    

    // public Renderer runner_rend;

    public Transform followerPos;

    
    public List<runner> myRunners = new List<runner>();


    // Update is called once per frame
    void Update()
    {
         
        MovementControls();
        
        
    }

  

    

    private void MovementControls()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
           
                myRunners[0].transform.position -= new Vector3(1f, 0, 0) * Time.deltaTime * myRunners[0].movementSpeed;
                if ( myRunners[0].transform.position.x < -1.25f)
                {
                    myRunners[0].transform.position = new Vector3(-1.25f,  myRunners[0].transform.position.y,  myRunners[0].transform.position.z);
                }
            
           
        }
        if (Input.GetKey(KeyCode.D))
        {
                myRunners[0].transform.position += new Vector3(1f, 0, 0) * Time.deltaTime * myRunners[0].movementSpeed;
                if ( myRunners[0].transform.position.x > 1.25f)
                {
                 myRunners[0].transform.position = new Vector3(1.25f,  myRunners[0].transform.position.y,  myRunners[0].transform.position.z);
                }
        }
    }

    
}
