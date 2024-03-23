using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DoTweenPlayerScale : MonoBehaviour
{
    [Header("Player Scale")]
    [SerializeField] float minScale = 0.5f;
    [SerializeField] float maxScale = 0.85f;
    [SerializeField] float scaleIncrease_Decrease = 0.1f;

    [Space]

    [Header("Scale Time")]
    [SerializeField] float time = 0.2f;

    [Space]

    [Header("Speed Increase Panel")]
    int totalHealthyFoodNumber = 0;
    [SerializeField] GameObject speedPanel;
    [SerializeField] float panelDelay = 5.0f;
    PlayerMove newForwardSpeed;


    [Space]
    [Header("Score")]
    int minScore = 0;


    private void Awake()
    {
        newForwardSpeed = GetComponent<PlayerMove>();

        GetComponent<AudioManager>();

        GetComponent<GameManegar>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthyFood"))
        {
            //Sounds
            AudioManager.Instance.PlaySFX("Healthy");

            //Destroy
            Destroy(other.gameObject, time);

            //Scale
            IncreaseScale();

            //Score
            GameManegar.Instance.totalScore++;
            GameManegar.Instance.CanvasScoreText();

            //Speed Panel-New Feature
            totalHealthyFoodNumber += 1;
            if (totalHealthyFoodNumber == 12)
            {
                Invoke("OpenPanel", 0.01f);
                newForwardSpeed.forwardSpeed += 10;
            }


            //Debug.Log(totalScore);
        }


        else if (other.CompareTag("FastFood"))
        {
            //Sounds
            AudioManager.Instance.PlaySFX("FastFood");


            //Destroy
            Destroy(other.gameObject, time);
            

            //Score
            if (GameManegar.Instance.totalScore > minScore)
            {
                GameManegar.Instance.totalScore--;
                GameManegar.Instance.CanvasScoreText();
            }

            //Scale
            DecreaseScale();
        }
    }



    private void IncreaseScale()
    {
        Vector3 currentScale = transform.localScale;
        float newXScale = Mathf.Clamp(currentScale.x - scaleIncrease_Decrease, minScale, maxScale);
        float newZScale = Mathf.Clamp(currentScale.z - scaleIncrease_Decrease, minScale, maxScale);

        
        Vector3 newScale = new Vector3(newXScale, currentScale.y, newZScale);
        transform.DOScale(newScale, time);
    }


    private void DecreaseScale()
    {
        Vector3 currentScale = transform.localScale;
        float newXScale = Mathf.Clamp(currentScale.x + scaleIncrease_Decrease, minScale, maxScale);
        float newZScale = Mathf.Clamp(currentScale.z + scaleIncrease_Decrease, minScale, maxScale);

        
        Vector3 newScale = new Vector3(newXScale, currentScale.y, newZScale);
        transform.DOScale(newScale, time);
    }


  
    void OpenPanel()
    {
        speedPanel.SetActive(true);
        Invoke("ClosePanel", panelDelay);
    }

    void ClosePanel()
    {
        speedPanel.SetActive(false);
    }

}
