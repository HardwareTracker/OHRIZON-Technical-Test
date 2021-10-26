using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class MemoryGameGM : MonoBehaviour
{
    [SerializeField] private List<CardBehavior> cards = new List<CardBehavior>();
    [SerializeField] private GameObject endGameOverlay;
    [SerializeField] private TextMeshProUGUI timer;
    
    private GameObject firstCard;
    private GameObject secondCard;
    
    private float gameTimer = 0;
    private int pairsFound = 0;

    void Start()
    {
        cards = cards.OrderBy( x => Random.value ).ToList( );
    }

    void Update()
    {
        gameTimer += 1 * Time.deltaTime;
        timer.text = "temps écoulé: " +  Mathf.Round(gameTimer).ToString();
    }

    public void CardSelected(GameObject mySelectedCard)
    {
        if (firstCard == null)
        {
            firstCard = mySelectedCard;
        }
        else
        {
            secondCard = mySelectedCard;
            VerifyMatch();
        }
    }

    private void VerifyMatch()
    {
        StartCoroutine("MatchVerifyCoroutine");
    }

    IEnumerator MatchVerifyCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        
        if (firstCard.gameObject.name == secondCard.gameObject.name)
        {
            firstCard.GetComponent<CardBehavior>().IsMatched = true;
            pairsFound++;
        }
        else
        {
            firstCard.GetComponent<CardBehavior>().FlipCard();
            secondCard.GetComponent<CardBehavior>().FlipCard();
        }
        
        firstCard = null;
        secondCard = null;

        if (pairsFound == 8)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        endGameOverlay.SetActive(true);
    }
    
    
}
