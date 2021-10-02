using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    

    public GameObject lose;
    public GameObject win;
    public bool gamePause = false;
    private PlayerHealth gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver= GameObject.Find("Player").GetComponent<PlayerHealth>();

        pauseMenu.SetActive(false);
        lose.SetActive(false);
        win.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Health();
        Pause();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            gamePause = true;
            Pause();
        }
    }

    void Health()
    {
        if(gameOver.gameOver==true)
        {
            Pause();
        }
        else
        {

        }
    }
    //bring up menu, pausing game
    void Pause()
    {   
        if (gameOver.gameOver==true)
        {
            lose.SetActive(true);
            gamePause = true;
        }
        if (gamePause == true)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
            lose.SetActive(false);
        }
    }
  
    public void UnPauseGame()
    {
        pauseMenu.SetActive(false);

        gamePause = false;

    }
}
