using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner_colliderScript : MonoBehaviour
{
     void OnTriggerEnter(Collider c)
    {
        
       if (c.gameObject.tag == "Gate")
        {
             
            Debug.Log("hit");
           runner_gate runner =  c.gameObject.GetComponentInParent<runner_gate>();
           runner.AttachToRunner();
        }

        else if (c.gameObject.tag == "?")
        {
           Debug.Log("?");
           GameManager.Instance.GetRandomEmoji();
        }
        
    }
}
