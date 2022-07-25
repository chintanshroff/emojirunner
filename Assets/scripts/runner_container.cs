using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner_container : MonoBehaviour
{
     public float movementSpeed = 1f;
    public float playerSpeed = 2f;

    public List<Texture> emojiList = new List<Texture>();
    public List<Texture> emojiList_matching = new List<Texture>();

     public Material runner_mat;

    public Transform followerPos;

    
    

    // Update is called once per frame
    void Update()
    {
         
        MovementControls();
        
        
    }

  

    

    private void MovementControls()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(1f, 0, 0) * Time.deltaTime * movementSpeed;
            if (transform.position.x < -1.25f)
            {
                transform.position = new Vector3(-1.25f, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1f, 0, 0) * Time.deltaTime * movementSpeed;
            if (transform.position.x > 1.25f)
            {
                transform.position = new Vector3(1.25f, transform.position.y, transform.position.z);
            }
        }
    }

    
}
