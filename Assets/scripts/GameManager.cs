using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    // Start is called before the first frame update
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject NextLevel;

    [SerializeField] int NumAnimals;

    public int currentSceneIndex;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        PauseGame();

    }

    public void LoadLv1 ()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void RestartScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void loadLv2()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }

    public void RestartScene2()
    {
        SceneManager.LoadScene(3);
    }
    public void Loadlv3()
    {
        SceneManager.LoadScene(6);
        Time.timeScale = 1;
    }
   
    public void RestartScene3()
    {
        SceneManager.LoadScene(5);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }


    void PauseGame() 
    {

        if(Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0; 
                PauseMenu.SetActive(true);
                Debug.Log("Game Pause");
            }
            else if  (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
                Debug.Log("Game Resume");
            }

        }

    }

    public void CaptureAnimal ()
    {
        NumAnimals = NumAnimals - 1;

        if (NumAnimals < 1) 
        {
            Time.timeScale = 0;
            NextLevel.SetActive(true);
        }

    }

}
//bugs
//1. los animales se detienen si pierdes la partida, no se mueven 
//2. puntos, si cae al suelo una bala o etc se va a game over
//3. se va a game over si llega a cierta cantidad de puntos
//4. los animales se vuelven locos si una bala los toca
//5. despues de reiniciar el nivel, la escena queda estatica.