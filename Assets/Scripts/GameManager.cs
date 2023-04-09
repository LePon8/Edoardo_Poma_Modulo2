using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    [SerializeField] GameObject prefabsToInstantiate;
    UIManager UIM;
    PlayerController PC;
    BombController BC;

    private float timeLimit = 1;
    [SerializeField] float elapsedTime;
    [SerializeField] float time;


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
        
        elapsedTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        StatusGame();
        TimerController();
    }

    void StatusGame()
    {
        if(gameStatus == GameStatus.Menu)
        {
            //UIM.StartGame();
            UIM.canvasMenu.SetActive(true);
            UIM.canvasPausa.SetActive(false);
            UIM.canvasLose.SetActive(false);
            UIM.canvasWin.SetActive(false);
            UIM.TimerUI.enabled = false;
            Time.timeScale = 0;
            PC.transform.position = Vector2.zero;
        }
        else if(gameStatus == GameStatus.GameRunning)
        {
            UIM.canvasMenu.SetActive(false);
            UIM.canvasLose.SetActive(false);
            UIM.canvasWin.SetActive(false);
            UIM.TimerUI.enabled = true;
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
        if(gameStatus == GameStatus.Lose)
        {
            UIM.canvasLose.SetActive(true);
            UIM.TimerUI.enabled = false;
            PC.transform.position = Vector2.zero;
            Destroy(GameObject.Find("Bomb(Clone)"));
            

        }
        else if(gameStatus == GameStatus.Win)
        {
            UIM.canvasWin.SetActive(true);
            UIM.TimerUI.enabled = false;
            PC.transform.position = Vector2.zero;
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

    void TimerController()
    {
        elapsedTime -= Time.deltaTime;
        UIM.UpdateTimer(elapsedTime);

        if(elapsedTime <= timeLimit)
        {
            Time.timeScale = 0;
            UIM.TimerUI.text = "0";
            gameStatus = GameStatus.Lose;
            elapsedTime = time;
            
        }
    }
}
