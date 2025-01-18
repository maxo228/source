using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameSession : MonoBehaviour
{
    [SerializeField] int playerScore=0;
    [SerializeField] int playerLives = 3;
    [SerializeField] float dyingTime;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    void Start(){
        livesText.text = "Lives : "+ playerLives.ToString();
        scoreText.text = "Score : "+ playerScore.ToString();
    }




void Awake(){
    
    int numGameSessions = FindObjectsOfType<GameSession>().Length;//количество обьектов на сцене (создаётся массив)
    if(numGameSessions>1){
        Destroy(gameObject);
    }
    else{
        DontDestroyOnLoad(gameObject);
    }
}
public void ProcessPlayerDeath(){
    if(playerLives>1){
        TakeLife();
    }
    else{
        ResetGameSession();
    }
}

void TakeLife(){
playerLives = playerLives -1;
int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
StartCoroutine(DyingTime(currentSceneIndex));



}


void ResetGameSession(){
    FindObjectOfType<SceneSaver>().ResetGameSave();
SceneManager.LoadScene(0);
Destroy(gameObject);//
}

public void AddToScore(int pointsAdd){
    playerScore = playerScore + pointsAdd;
    scoreText.text= "Score : "+ playerScore.ToString();
}

    IEnumerator DyingTime(int currentSceneIndex){
        yield return new WaitForSecondsRealtime(dyingTime);
        SceneManager.LoadScene(currentSceneIndex);
livesText.text = "Lives : "+playerLives.ToString();

    }
}
