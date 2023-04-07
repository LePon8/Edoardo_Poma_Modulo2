using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject canvasMenu;
    [SerializeField] public GameObject canvasPausa;
    [SerializeField] public GameObject canvasLose;
    [SerializeField] public GameObject canvasWin;
    //GameManager GM;

    private void Awake()
    {
        //GM = FindObjectOfType<GameManager>();
    }

    //public void StartGame()
    //{
    //    canvasMenu.SetActive(true);
    //}
}
