using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject canvasMenu;
    [SerializeField] public GameObject canvasPausa;
    [SerializeField] public GameObject canvasLose;
    [SerializeField] public GameObject canvasWin;
    [SerializeField] public TextMeshProUGUI TimerUI;
    //GameManager GM;

    private void Awake()
    {
        //GM = FindObjectOfType<GameManager>();
        TimerUI.text = 0.ToString();
    }

    private void Start()
    {
        //Time.timeScale = 0;
        
    }

    public void UpdateTimer(float time)
    {
        TimerUI.text = Mathf.FloorToInt(time).ToString();
    }

    //public void StartGame()
    //{
    //    canvasMenu.SetActive(true);
    //}
}
