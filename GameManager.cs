using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;
    public static event GameDelegate OnWinConfirmed;
    public GameObject startPage;
    public GameObject endPage;
    public GameObject gameOverPage;
    public GameObject letterPage;
    public GameObject dialoguePage;
    public GameObject winPage;
    public Text TimeText;

    public float scrollSpeed = -5f;

    enum PageState {
        None,
        Start,
        Dialogue,
        End,
        GameOver,
        Letter,
        Win
    }

    bool gameOver = false;
    public bool GameOver { get { return gameOver; } }
    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        Player.OnPlayerGameOver += OnPlayerGameOver;
        Player.OnPlayerCollision += OnPlayerCollision;
        Player.OnPlayerWin += OnPlayerWin;

    }

    private void OnDisable()
    {
        Player.OnPlayerGameOver -= OnPlayerGameOver;
        Player.OnPlayerCollision -= OnPlayerCollision;
        Player.OnPlayerWin -= OnPlayerWin;

    }

    void OnPlayerGameOver()
    {
        gameOver = true;
        SetPageState(PageState.GameOver);
    }

    void OnPlayerCollision()
    {

    }

    void OnPlayerWin()
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
                winPage.SetActive(false);
                break;
            case PageState.Start:
                startPage.SetActive(true);
                endPage.SetActive(false);
                gameOverPage.SetActive(false);
                dialoguePage.SetActive(false);
                letterPage.SetActive(false);
                winPage.SetActive(false);
                break;
            case PageState.End:
                startPage.SetActive(false);
                endPage.SetActive(true);
                gameOverPage.SetActive(false);
                dialoguePage.SetActive(false);
                letterPage.SetActive(false);
                winPage.SetActive(false);
                break;
            case PageState.GameOver:
                startPage.SetActive(false);
                endPage.SetActive(false);
                gameOverPage.SetActive(true);
                dialoguePage.SetActive(false);
                letterPage.SetActive(false);
                winPage.SetActive(false);
                break;
            case PageState.Dialogue:
                startPage.SetActive(false);
                endPage.SetActive(false);
                gameOverPage.SetActive(false);
                dialoguePage.SetActive(true);
                letterPage.SetActive(false);
                winPage.SetActive(false);
                break;
            case PageState.Letter:
                startPage.SetActive(false);
                endPage.SetActive(false);
                gameOverPage.SetActive(false);
                dialoguePage.SetActive(false);
                letterPage.SetActive(true);
                winPage.SetActive(false);
                break;
            case PageState.Win:
                startPage.SetActive(false);
                endPage.SetActive(false);
                gameOverPage.SetActive(false);
                dialoguePage.SetActive(false);
                letterPage.SetActive(false);
                winPage.SetActive(true);
                break;
        }
    }

    public void ConfirmGameOver()
    {
        //activate when losing a level
        OnGameOverConfirmed();
        SetPageState(PageState.Start);
    }

    public void StartGame()
    {
        //activate on play button
        SetPageState(PageState.Start);
        SetPageState(PageState.Dialogue);
    }

    public void ConfirmWin()
    {
        OnWinConfirmed();
        //activate when player wins game
        SetPageState(PageState.Win);
        SetPageState(PageState.Letter);
        SetPageState(PageState.Start);
    }
}
