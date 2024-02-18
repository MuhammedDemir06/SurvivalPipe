using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI scoreText;
   [SerializeField] private TextMeshProUGUI maxScoreText;
   public static int Score;
   public int MaxScore;
   [SerializeField]private GameObject menuScreen,gameScreen;
   
   private void Start()
   {
      MaxScore=PlayerPrefs.GetInt("MaxScore");
   }
   private void ScoreUpdate()
   {
      scoreText.text="SCORE:"+Score.ToString();
   }
   private void MaxScoreControl()
   {
     maxScoreText.text="MAX SCORE:"+MaxScore.ToString();
     if(Score>MaxScore)
     {
        MaxScore=Score;
        PlayerPrefs.SetInt("MaxScore",MaxScore);
     }

   }
   private void Update()
   {
      ScoreUpdate();
      MaxScoreControl();

      if(CharacterControl.IsDead)
      {
        Time.timeScale=0f;
        menuScreen.SetActive(true);
        gameScreen.SetActive(false);
      }
      else
      {
        Time.timeScale=1f;
        menuScreen.SetActive(false);
        gameScreen.SetActive(true);
      }
   }
   //Buttons
   public void PlayButton()
   {
      SceneManager.LoadScene(0);
   }
}
