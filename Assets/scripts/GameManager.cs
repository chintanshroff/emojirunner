using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Static Singleton Instance
    public static GameManager _Instance = null;

    //property to get instance
    public static GameManager Instance
    {
        get
        {
            //if we do not have Instance yet
            if (_Instance == null)
            {
                _Instance = (GameManager)FindObjectOfType(typeof(GameManager));
            }
            return _Instance;
        }
    }


    public Transform base_1;
    public int cashAmount = 0;
    public int heartAmount = 0;
    public runner_container myRunner;
    public bool isCorrect = true;

    
   
  
   public runner_gate Gate1;
   public runner_gate Gate2;

private void Start() {
    GetRandomEmoji();
}
void Update()
    {
     if (isCorrect)
     {
        base_1.position += new Vector3(0, 0, 1f) * Time.deltaTime * myRunner.playerSpeed;
     }
     else
     {
        base_1.position -= new Vector3(0, 0, 50f) * Time.deltaTime * myRunner.playerSpeed;
        isCorrect = true;
     }
        
    }

    public void GetRandomEmoji()
    {
        int r = Random.Range(0, myRunner.emojiList.Count);
        myRunner.runner_mat.SetTexture("_MainTex", myRunner.emojiList[r]);

        int r1 = Random.Range(0, 2);
        if (r1 == 0)
        {
           Gate1.gate_mat.SetTexture("_MainTex", myRunner.emojiList_matching[r+r]);
           Gate1.isCorrect = true;
           Gate2.gate_mat.SetTexture("_MainTex", myRunner.emojiList_matching[r+r+1]);
            Gate2.isCorrect = false;

        }
        else
        {
            Gate1.gate_mat.SetTexture("_MainTex", myRunner.emojiList_matching[r+r+1]);
             Gate1.isCorrect = false;
            Gate2.gate_mat.SetTexture("_MainTex", myRunner.emojiList_matching[r+r]);
             Gate2.isCorrect = true;

        }
        

    }
    
}
