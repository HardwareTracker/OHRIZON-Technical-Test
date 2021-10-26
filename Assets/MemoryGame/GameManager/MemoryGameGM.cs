using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MemoryGameGM : MonoBehaviour
{
    [SerializeField] private List<CardBehavior> cards = new List<CardBehavior>();
    private float gameTimer = 0;

    void Start()
    {
        cards = cards.OrderBy( x => Random.value ).ToList( );
    }

    void Update()
    {
        gameTimer += 1 * Time.deltaTime;
    }
}
