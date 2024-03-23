using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroStart : MonoBehaviour
{
    [Header("Start Delay")]
    [SerializeField] float startDelay = 5f;

    [Space]

    [Header("Scene")]
    Scene scene;


    private void Awake()
    {
        scene = SceneManager.GetActiveScene();

        GetComponent<AudioManager>();
    }


    void Start()
    {
       Invoke("GameScene", startDelay);  
    }


    //The scene that will play when you press the play button
    public void IntroScene()
    {
        //Sounds
        AudioManager.Instance.PlaySFX("Click");//button


        //Scene
        SceneManager.LoadScene(scene.buildIndex + 1);
        

    }


    //After 27 seconds, the Game Scene will play.
    void GameScene()
    {
        SceneManager.LoadScene(scene.buildIndex + 1);
    } 


   
}
