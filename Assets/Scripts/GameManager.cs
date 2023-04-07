using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    [SerializeField] GameObject prefabsToInstantiate;
    UIManager UIM;
    PlayerController PC;


    public enum GameStatus
    {
        Menu,
        GameRunning,
        Pause,
        Lose,
        Win
    }
    [SerializeField] public GameStatus gameStatus;

    private void Awake()
    {
        UIM = FindObjectOfType<UIManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabsToInstantiate, new Vector2(0, 0), Quaternion.identity);
        PC = FindObjectOfType<PlayerController>();
        if (PC)
        {
            Debug.Log("Ecco il bro");
        }
    }

    // Update is called once per frame
    void Update()
    {
        StatusGame();
    }

    void StatusGame()
    {
        if(gameStatus == GameStatus.Menu)
        {
            //UIM.StartGame();
            UIM.canvasMenu.SetActive(true);
            UIM.canvasPausa.SetActive(false);
            Time.timeScale = 0;
        }
        else if(gameStatus == GameStatus.GameRunning)
        {
            UIM.canvasMenu.SetActive(false);
            Time.timeScale = 1;
        }
        if(Input.GetKeyDown(KeyCode.Escape) && gameStatus == GameStatus.GameRunning)
        {
            gameStatus = GameStatus.Pause;
            UIM.canvasPausa.SetActive(true);
            Time.timeScale = 0;
            PC.enabled = false;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && gameStatus == GameStatus.Pause)
        {
            gameStatus = GameStatus.GameRunning;
            UIM.canvasPausa.SetActive(false);
            Time.timeScale = 1;
            PC.enabled = true;
        }

    }

    public void playGame()
    {
        gameStatus = GameStatus.GameRunning;
    }

    public void Menu()
    {
        gameStatus = GameStatus.Menu;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
