using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollect : MonoBehaviour
{
    [Header("Negative PowerUp")]
    [SerializeField] float negativePowerSpeed = 5.0f;

    [Space]

    [Header("Powerup")]
    [SerializeField] float powerSpeed = 10.0f;
    [SerializeField] float durationSpeed = 5f;
    PlayerMove accessForwardSpeed;

    [Space]

    [Header("Animator")]
    Animator anim;
    int isStumble,isDance,isSad = 0;



    private void Awake()
    {
        accessForwardSpeed = GetComponent<PlayerMove>();
        anim = GetComponent<Animator>();

        GetComponent<AudioManager>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        { 
            StartCoroutine(PowerupTime());
        } 

        if (other.gameObject.CompareTag("BackPowerup"))
        {
            StartCoroutine(NegativePowerupTime());
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (GameManegar.Instance.totalHeart > 0)
            {
                GameManegar.Instance.totalHeart--;
                GameManegar.Instance.CanvasHeartText();


                //Anim
                isStumble = 1;
                anim.SetTrigger("isStumble");
                //
            }

            else if (GameManegar.Instance.totalHeart <= 0)
            {
                //Anim
                isSad = 1;
                anim.SetTrigger("isSad");
                //


                StartCoroutine(GameOver());


                //Sounds
                AudioManager.Instance.PlaySFX("Gameover");
                AudioManager.Instance.musicSource.Stop();
                //
            }

            
        }

        else if (collision.gameObject.CompareTag("Finish"))
        {
            //Anim
            isDance = 1;
            anim.SetTrigger("isDance");
            //

            //Sounds
            AudioManager.Instance.PlaySFX("Win");
            AudioManager.Instance.musicSource.Stop();
            //

            StartCoroutine("Finish");
        }
    }


    
    

    IEnumerator PowerupTime()
    {
        accessForwardSpeed.forwardSpeed += powerSpeed;
        yield return new WaitForSeconds(durationSpeed);
        accessForwardSpeed.forwardSpeed -= powerSpeed;
        
    }

    IEnumerator NegativePowerupTime()
    {
        accessForwardSpeed.forwardSpeed -= negativePowerSpeed;
        yield return new WaitForSeconds(durationSpeed);
        accessForwardSpeed.forwardSpeed += negativePowerSpeed;
    }

    IEnumerator GameOver()
    {
        accessForwardSpeed.forwardSpeed = 0;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
        
    }

    IEnumerator Finish()
    {
        accessForwardSpeed.forwardSpeed = 0;
        gameObject.transform.Rotate(0, -180, 0);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);

    }
}
