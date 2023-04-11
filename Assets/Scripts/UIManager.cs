using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject canvasPausa;

    PlayerController PC;



    private void Start()
    {
        
        PC = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
       
    }

    public void playGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
