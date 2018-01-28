using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;

    public GameObject startPage;
    public GameObject endPage;
    public GameObject gameOverPage;
    public GameObject letterPage;
    public GameObject dialoguePage;

    enum PageState {
        None,
        Start,
        Dialogue,
        End,
        GameOver,
        Letter
    }

    bool gameOver = false;
    public bool GameOver { get { return gameOver; } }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    void SetPageState(PageState state)
    {
        switch (state)
        {
            case PageState.None:
                startPage.SetActive(false);
                endPage.SetActive(false);
                gameOverPage.SetActive(false);
                dialoguePage.SetActive(false);
                letterPage.SetActive(false);
                break;
            case PageState.Start:
                startPage.SetActive(true);
                endPage.SetActive(false);
                gameOverPage.SetActive(false);
                dialoguePage.SetActive(false);
                letterPage.SetActive(false);
                break;
            case PageState.End:
                startPage.SetActive(false);
                endPage.SetActive(true);
                gameOverPage.SetActive(false);
                dialoguePage.SetActive(false);
                letterPage.SetActive(false);
                break;
            case PageState.GameOver:
                startPage.SetActive(false);
                endPage.SetActive(false);
                gameOverPage.SetActive(true);
                dialoguePage.SetActive(false);
                letterPage.SetActive(false);
                break;
            case PageState.Dialogue:
                startPage.SetActive(false);
                endPage.SetActive(false);
                gameOverPage.SetActive(false);
                dialoguePage.SetActive(true);
                letterPage.SetActive(false);
                break;
            case PageState.Letter:
                startPage.SetActive(false);
                endPage.SetActive(false);
                gameOverPage.SetActive(false);
                dialoguePage.SetActive(false);
                letterPage.SetActive(true);
                break;
        }
    }

    public void ConfirmGameOver()
    {
        OnGameOverConfirmed();
        SetPageState(PageState.Letter);
        SetPageState(PageState.Start);
    }

    public void StartGame()
    {
        SetPageState(PageState.Dialogue);
    }
}
