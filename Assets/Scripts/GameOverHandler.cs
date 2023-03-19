using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button continueButton;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    
    public void EndGame()
    {
        asteroidSpawner.enabled = false;

        int finalScore = scoreSystem.EndTimer();
        gameOverText.text = $"Your Score: {finalScore}";

        gameOverDisplay.gameObject.SetActive(true);
    }

  public void PlayAgain()
  {
    SceneManager.LoadScene(1);
  }

  public void ContinueButton()
  {
    AdManager.Instance.ShowAd(this);

    continueButton.interactable = false;
  }

  public void ReturnToMenu()
  {
    SceneManager.LoadScene(0);
  }

    internal void ContinueGame()
    {
        scoreSystem.StartTimer();

        player.transform.position = Vector3.zero;
        player.SetActive(true);

        asteroidSpawner.enabled = true;

        gameOverDisplay.gameObject.SetActive(false);
    }
}
