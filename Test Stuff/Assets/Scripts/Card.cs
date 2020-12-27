using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    public float value;

    public List<Card> _cards = new List<Card>();
    public List<LineRenderer> _line = new List<LineRenderer>();

    public TextMeshPro _text;

    private void Awake()
    {
        _text.text = value.ToString();
        for(int i = 0; i < _cards.Count; i++)
        {
            _line[i].SetPosition(0, transform.position);
            _line[i].SetPosition(1, _cards[i].gameObject.transform.position);
        }
    }

    private void Update()
    {
        _text.text = value.ToString();
    }

    public void StartDividing()
    {
        StartCoroutine(Divide());
    }

    public IEnumerator Divide()
    {
        for (int i = 0; i < Mathf.Infinity; i++)
        {
            float temp = value;
            value = 0;

            yield return new WaitForSeconds(0.01f);

            for (int j = 0; j < _cards.Count; j++)
            {
                if(temp != 0)
                {
                    Debug.Log(_cards[j].gameObject.name);
                    _cards[j].value += (temp / 3);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}