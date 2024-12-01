using System;
using System.Collections.Generic;
using UnityEngine;

public class HandOrganiser : MonoBehaviour
{
    [SerializeField] private GameObject card_prefab;
    [SerializeField] private float width;
    [SerializeField] private float max_count;
    [SerializeField] private float start_pos;
    [SerializeField] public List<GameObject> funky_store = new List<GameObject>();
    [SerializeField] public List<Card> hold_gen = new List<Card>();
    public void Generate(List<Card> cards) 
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
            funky_store = new List<GameObject>();
        }

        for (int index = 0; index < cards.Count; index++) 
        { hold_gen.Add(cards[index]); }
           
        width = card_prefab.GetComponent<Renderer>().bounds.size.x;
        
        float screenWidth = Camera.main.ScreenToWorldPoint(Camera.main.ViewportToScreenPoint(new Vector3(1f, 0f, 1f))).x - Camera.main.ScreenToWorldPoint(Camera.main.ViewportToScreenPoint(new Vector3(0f, 0f, 1f))).x;
        max_count = screenWidth / width;
        int size = cards.Count;
        print(max_count);

        float totalWidth = width * cards.Count;

        int i = 0;
        for (float X = -(totalWidth / 2f) + (width / 2f); X <= (totalWidth / 2f) - (width / 2f); X += width)
        {
            GameObject obj = Instantiate(card_prefab, new Vector3(X, -3.38f, 1f), new Quaternion());
            obj.transform.SetParent(transform);
            obj.GetComponent<CardRenderer>().Render(cards[i]);
            i++;

            funky_store.Add(obj);
        }
    }

    public void sort()
    {
        funky_store = new List<GameObject>();
        foreach (Transform child in transform)
        {
            funky_store.Add(child.gameObject);
        }
        if (funky_store.Count <= 0) { Generate(hold_gen); }
        else { int size = funky_store.Count;
            print(max_count);

            if ((size % 2) == 0)
            {
                print("even");
                start_pos = 0 - ((size / 2) * width);
                for (int index = 0; index < funky_store.Count; index++)
                {
                    funky_store[index].transform.position = new Vector3((start_pos + (width / 2)), -3.38f, 1f);
                    start_pos = start_pos + width;

                }
            }
            else if (!((size % 2) == 0))
            {
                print("odd");
                funky_store[0].transform.position = new Vector3(0.0f, -3.38f, 1f);
                
                start_pos = 0 - ((Mathf.Floor(funky_store.Count / 2) * width) + (width / 2));
                for (int index = 0; index < MathF.Floor(funky_store.Count / 2)+ 1; index++)
                {

                    funky_store[index].transform.position = new Vector3((start_pos + (width / 2)), -3.38f, 1f);
                    start_pos = start_pos + width;

                }

                start_pos = 0 + (width / 2);
                for (int index = (int)(MathF.Floor(funky_store.Count / 2))+1; index < funky_store.Count; index++)
                {
                    funky_store[index].transform.position = new Vector3((start_pos + (width / 2)), -3.38f, 1f);
                    start_pos = start_pos + width;

                }
            }
        }
    }

}
