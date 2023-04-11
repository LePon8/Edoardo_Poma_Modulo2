using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    //public static GameManager gameManager { get; private set; }

    [SerializeField] GameObject prefabsToInstantiate;
    UIManager UIM;
    PlayerController PC;

    [SerializeField] public TextMeshProUGUI TimerUI;
    EnemyController EC;

    private float timeLimit = 1;
    [SerializeField] float elapsedTime;
    [SerializeField] float time;


    public enum GameStatus
    {
        GameRunning,
        Pause
    }
    [SerializeField] public GameStatus gameStatus;

    private void Awake()
    {
        UIM = FindObjectOfType<UIManager>();
        EC = FindObjectOfType<EnemyController>();
        TimerUI.text = 0.ToString();
        Time.timeScale = 1;
    }

    public void UpdateTimer(float time)
    {
        TimerUI.text = Mathf.FloorToInt(time).ToString();
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
        Win();
    }

    void StatusGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameStatus == GameStatus.GameRunning)
        {
            gameStatus = GameStatus.Pause;
            UIM.canvasPausa.SetActive(true);
            Time.timeScale = 0;
            PC.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gameStatus == GameStatus.Pause)
        {
            gameStatus = GameStatus.GameRunning;
            UIM.canvasPausa.SetActive(false);
            Time.timeScale = 1;
            PC.enabled = true;
        }

    }






    void TimerController()
    {
        elapsedTime -= Time.deltaTime;
        UpdateTimer(elapsedTime);

        if(elapsedTime <= timeLimit)
        {
            Time.timeScale = 0;
            TimerUI.text = "0";
            elapsedTime = time;
            GameOver();
            
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    //GameObject Enemies;
    public void Win()
    {
        //foreach (var enemy in enemies)
        //{

        //}
        if (EC == null)
        {
            SceneManager.LoadScene("Win");

        }
    }
   
}
