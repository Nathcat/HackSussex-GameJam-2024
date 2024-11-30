using System.Collections.Generic;
using UnityEngine;

public class HandOrganiser : MonoBehaviour
{
    [SerializeField] private GameObject card_prefab;
    [SerializeField] private float width;
    [SerializeField] private float max_count;
    [SerializeField] private float start_pos;
    [SerializeField] public List<GameObject> funky_store = new List<GameObject>();
    public void Generate(List<Card> cards) 
    {
        funky_store = new List<GameObject>();
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
                GameObject card_x = Instantiate(card_prefab, transform);
                card_x.GetComponent<CardRenderer>().Render(cards[index]);
                card_x.transform.localPosition = new Vector3((start_pos + (width / 2)), 0, 0);
                funky_store.Add(card_x);
                start_pos = start_pos + width;
            }
        }
        else if (!((size % 2) == 0)) 
        {
            GameObject card_x = Instantiate(card_prefab, transform);
            card_x.GetComponent<CardRenderer>().Render(cards[0]);
            cards.RemoveAt(0);
            card_x.transform.localPosition = new Vector3(0.0f, 0, 0);
            funky_store.Add(card_x);

            start_pos = 0 - (((size / 2) * width) + (width / 2));
            for (int index = 0; index < cards.Count/2; index++)
            {
                card_x = Instantiate(card_prefab, transform);
                card_x.GetComponent<CardRenderer>().Render(cards[index]);
                card_x.transform.localPosition = new Vector3((start_pos + (width / 2)), 0, 0);
                start_pos = start_pos + width;
                funky_store.Add(card_x);
            }

            start_pos = 0 + (width/2);
            for (int index = ((cards.Count/2 )); index < cards.Count; index++)
            {
                card_x = Instantiate(card_prefab, transform);
                card_x.GetComponent<CardRenderer>().Render(cards[index]);
                card_x.transform.localPosition = new Vector3((start_pos + (width / 2)), 0, 0);
                start_pos = start_pos + width;
                funky_store.Add(card_x);
            }
        }
    }

    public void sort()
    {
        funky_store.Clear();
        foreach (Transform child in transform)
        {         
            funky_store.Add(child.gameObject);
        }
        int size = funky_store.Count;
        print(max_count);

        if ((size % 2) == 0)
        {
            start_pos = 0 - ((size / 2) * width);
            for (int index = 0; index < funky_store.Count; index++)
            {
                funky_store[index].transform.position = new Vector3((start_pos + (width / 2)), -3.38f, 1f);
                start_pos = start_pos + width;

            }
        }
        else if (!((size % 2) == 0))
        {
            funky_store[0].transform.position = new Vector3(0.0f, -3.38f, 1f);
            funky_store.Add(funky_store[0]);
            funky_store.RemoveAt(0);
            start_pos = 0 - (((size / 2) * width) + (width / 2));
            for (int index = 0; index < funky_store.Count / 2; index++)
            {

                funky_store[index].transform.position = new Vector3((start_pos + (width / 2)), -3.38f, 1f);
                start_pos = start_pos + width;

            }

            start_pos = 0 + (width / 2);
            for (int index = ((funky_store.Count / 2)); index < funky_store.Count; index++)
            {
                funky_store[index].transform.position = new Vector3((start_pos + (width / 2)), -3.38f, 1f);
                start_pos = start_pos + width;

            }
        }
    }


}
