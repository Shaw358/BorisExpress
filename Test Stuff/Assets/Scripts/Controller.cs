using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    int delay;
    public List<Card> _all_cards = new List<Card>();

    private void Start()
    {
        foreach (Card item in _all_cards)
        {
            item.StartDividing();
        }
    }
}