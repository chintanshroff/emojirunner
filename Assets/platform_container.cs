using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_container : MonoBehaviour
{
   public runner_gate Gate1;
   public runner_gate Gate2;
   public bool isCurrentPlatform = false;
   
    
    
    void Update()
    {

     if (GameManager.Instance.isCorrect)
     {
        transform.position += new Vector3(0, 0, 1f) * Time.deltaTime * GameManager.Instance.myRunner_container.playerSpeed;
     }
     
     
     if (transform.position.z > 10)
     {
        if (isCurrentPlatform)
            {
               GameManager.Instance.SpawnPlatform(new Vector3 (0,0,GameManager.Instance.platform_list[GameManager.Instance.platform_list.Count-1].transform.localPosition.z -25f));
            }
     }
      if (transform.position.z > 50)
     {
       
       // GameManager.Instance.RemovePlatform();
     }
        
    }

    public void GetRandomEmoji()
    {
        
        int r = Random.Range(0,  GameManager.Instance.emojiList.Count);
        GameManager.Instance.myRunner_container.myRunners[0].my_rend.material  =  GameManager.Instance.emojiList[r];

        int r1 = Random.Range(0, 2);
       Debug.Log("Hello");
        if (r1 == 0)
        {
            
            Gate1.myRunnerScript.my_rend.material = GameManager.Instance.emojiList_matching[r+r];
            Gate1.isCorrectGate = true;
            Gate2.myRunnerScript.my_rend.material = GameManager.Instance.emojiList_matching[r+r+1];
            Gate2.isCorrectGate = false;
        }
        else
        {
            Gate1.myRunnerScript.my_rend.material = GameManager.Instance.emojiList_matching[r+r+1];
            Gate1.isCorrectGate = false;
            Gate2.myRunnerScript.my_rend.material = GameManager.Instance.emojiList_matching[r+r];
            Gate2.isCorrectGate = true;
        }
    }
}
