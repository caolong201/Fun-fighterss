using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class ViewItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtName;
    int _index;
    //public List<Sprite> imageList;

    public void Init(string name, int index )
    {
        txtName.text = name;
        _index = index;
       
    }

    public void OnbtnClickBUY()
    {
        Debug.Log("BUY" + _index);
    }
}
