using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using UnityEditor;

public class Controller : MonoBehaviour
{
    public int delay;
    public List<Card> _all_cards = new List<Card>();

    private void Start()
    {
        foreach (Card item in _all_cards)
        {
            item.StartDividing();
        }

        StartCoroutine(Sort());
    }

    private IEnumerator Sort()
    {
        List<Card> _all_values = new List<Card>();
        List<string> _values = new List<string>();

        _all_values = _all_cards;

        yield return new WaitForSeconds(delay);
        
        _all_values = _all_values.OrderBy(x => -x.value).ToList();

        for (int i = 0; i < _all_values.Count; i++)
        {
            _values.Add(_all_values[i].gameObject.name + " | value: " + _all_values[i].value.ToString() + "\n");
        }

        foreach (string item in _values)
        {
            Debug.Log(item);
        }

        WriteToFile(_values);
    }

    public void WriteToFile(List<string> _list)
    {
        string path = "Assets/SortedList.txt";

        StreamWriter writer = new StreamWriter(path, true);

        writer.WriteLine("===========NEW LIST=========== \n \n");

        foreach (string item in _list)
        {
            writer.WriteLine(item);
        }
        writer.Close();
    }
}