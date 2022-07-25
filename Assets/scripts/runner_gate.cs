using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner_gate : MonoBehaviour
{
public bool isCorrect;
 public Material gate_mat;


    public void AttachToRunner()
    {
        if(isCorrect)
        {
             Debug.Log("Attach");
             transform.parent = GameManager.Instance.myRunner.transform;
             transform.position = GameManager.Instance.myRunner.followerPos.position;
             transform.rotation =  GameManager.Instance.myRunner.followerPos.rotation;
        }
        else if(!isCorrect)
        {
            Debug.Log("incorrect");
            GameManager.Instance.isCorrect = false;
        }
       
    }


}
