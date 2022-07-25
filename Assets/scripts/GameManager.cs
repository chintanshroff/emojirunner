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


    
    public int cashAmount = 0;
    public int heartAmount = 0;
    public runner_container myRunner;
    public bool isCorrect = true;

    private platform_container platform;
    private Transform pooledPlatform;

   public List<platform_container> platform_list = new List<platform_container>();
  
   public runner_gate Gate1;
   public runner_gate Gate2;


   public List<Material> emojiList = new List<Material>();
    public List<Material> emojiList_matching = new List<Material>();

private void Start() 
{
    
    SpawnPlatform(new Vector3 (0,0,0));
    platform_list[platform_list.Count-1].GetRandomEmoji();
}


    

    public void SpawnPlatform(Vector3 pos)
    {
        pooledPlatform = GameObjectPool.GetPool("PlatformPool").GetInstance();
        platform = pooledPlatform.GetComponent<platform_container>();
        platform.transform.localPosition = pos;
        for (int i =0; i<GameManager.Instance.platform_list.Count; i++)
        {
            GameManager.Instance.platform_list[i].isCurrentPlatform = false;
        }
        platform_list.Add(platform);
        platform.isCurrentPlatform = true;
       

    }
    
    public void RemovePlatform()
    {
        GameObjectPool.GetPool("PlatformPool").ReleaseInstance(platform_list[0].transform);
        platform_list.Remove(platform_list[0]);
    }
}
