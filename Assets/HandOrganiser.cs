using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandOrganiser : MonoBehaviour
{
    [SerializeField] private float offset = 0f;
    [SerializeField] private GameObject card_prefab;
    [SerializeField] private float width;
    [SerializeField] private float max_count;
    [SerializeField] private float start_pos;
    [SerializeField] private List<Card> cards = new List<Card>();
    private void Start()
    {
        Generate(cards);
    }

    public void Generate(List<Card> cards) 
    {
        width = card_prefab.GetComponent<Renderer>().bounds.size.x;
        
        float screenWidth = Camera.main.ScreenToWorldPoint(Camera.main.ViewportToScreenPoint(new Vector3(1f, 0f, 1f))).x - Camera.main.ScreenToWorldPoint(Camera.main.ViewportToScreenPoint(new Vector3(0f, 0f, 1f))).x;
        max_count = screenWidth / width;
        int size = cards.Count;
        print(max_count);

        if ((size % 2) == 0)
        {
            start_pos = 0 - ((size / 2) * width);
            for (int index = 0; index < cards.Count; index++)
            {
                GameObject card_x = Instantiate(card_prefab);
                card_x.GetComponent<CardRenderer>().Render(cards[index]);
                card_x.transform.position = new Vector3((start_pos + (width / 2)), -3.38f, 1f);
                start_pos = start_pos + width;
            }
        }
        else if (!((size % 2) == 0)) 
        {
            GameObject card_x = Instantiate(card_prefab);
            card_x.GetComponent<CardRenderer>().Render(cards[0]);
            cards.RemoveAt(0);
            card_x.transform.position = new Vector3(0.0f, -3.38f, 1f);

            start_pos = 0 - (((size / 2) * width) + (width / 2));
            for (int index = 0; index < cards.Count/2; index++)
            {
                card_x = Instantiate(card_prefab);
                card_x.GetComponent<CardRenderer>().Render(cards[index]);
                card_x.transform.position = new Vector3((start_pos + (width / 2)), -3.38f, 1f);
                start_pos = start_pos + width;
            }

            start_pos = 0 + (width/2);
            for (int index = ((cards.Count/2 )); index < cards.Count; index++)
            {
                card_x = Instantiate(card_prefab);
                card_x.GetComponent<CardRenderer>().Render(cards[index]);
                card_x.transform.position = new Vector3((start_pos + (width / 2)), -3.38f, 1f);
                start_pos = start_pos + width;
            }
        }

        for (int index = 0; index < cards.Count; index++) 
        { 
            
        }
    }



}
