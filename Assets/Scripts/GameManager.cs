using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject ammoBoxPrefab;
   


    public GameObject lose;
    public GameObject win;
    public bool gamePause = false;
    private PlayerHealth gameOver;
    


    //supply drop timer
    public Image supplyDropTimer;
    public GameObject collectTimer;
    
    //how long to call for ammo
    float time = 0;
    private float maxTime = 3;
    //was drop called
    public bool supplyDropped = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOver= GameObject.Find("Player").GetComponent<PlayerHealth>();
        

        pauseMenu.SetActive(false);
        

        lose.SetActive(false);
        win.SetActive(false);
        collectTimer.SetActive(false);

        
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


        if (Input.GetKey(KeyCode.R) && gameOver.gameOver == false)
        {
            SupplyDropCall();
            

        }
        else
        {
            resetTimer();
        }
    }

    void Health()
    {
        if(gameOver.gameOver==true)
        {
            Pause();
            
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

   

    void SupplyDropCall()
    {
        
        collectTimer.SetActive(true);

        InvokeRepeating("DropSupply", 1, 1);

        if (supplyDropped == true)
        {

            
            resetTimer();
            Instantiate(ammoBoxPrefab, new Vector3(0,5,0), transform.rotation);
        }
    }
    //call Drop Supply
    public void DropSupply()
    {
        
        //keep track of time while interacting with object(rock sample)
        if (time < maxTime)
        {
            time++;
            //fill timer wheel
            supplyDropTimer.fillAmount = time / maxTime;
        }
        if (time == maxTime)
        {

            // was sample collected 
            supplyDropped = true;

        }
        else
        {
            // Stops all repeating invokes
            //if player moves away from object cancel repeating function, stopping timer

            CancelInvoke();
        }

    }

    //reset timer for collecting sample
    private void resetTimer()
    {
        time = 0;
        supplyDropped = false;
        collectTimer.SetActive(false);
    }
}
