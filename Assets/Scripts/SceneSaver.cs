using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSaver : MonoBehaviour
{
void Awake(){
    
    int numScenePersits = FindObjectsOfType<GameSession>().Length;
    if(numScenePersits>1){
        Destroy(gameObject);
    }
    else{
        DontDestroyOnLoad(gameObject);
    }
}
    public void ResetGameSave(){
        Destroy(gameObject);//удаляем GameSave
    }

}

