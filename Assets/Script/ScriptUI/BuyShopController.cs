using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyShopController : MonoBehaviour
{
    [SerializeField] Transform Continal;
    [SerializeField] GameObject prefab;
    int Rocket = 30;
    private List<ViewItem> listItems = new List<ViewItem>();
    void Start()
    {
        for(int i = 0; i< Rocket; i++)
        {
            GameObject newContent = Instantiate(prefab, Continal);
            var item = newContent.GetComponent<ViewItem>();
            string name = " Rocket" + i;
            item.Init(name, i);
            listItems.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
