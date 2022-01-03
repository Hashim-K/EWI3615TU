using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingController : MonoBehaviour
{

    [SerializeField]
    private TMP_Text valueText;

    [SerializeField]
    private string[] valueList;

    private int index;
    void Start()
    {
        index = 0;
        valueText.SetText(valueList[index]);
    }

    public void Right()
    {
        if (index < valueList.Length - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }
        valueText.SetText(valueList[index]);
    }

    public void Left()
    {
        if (index - 1 > 0 )
        {
            index--;
        }
        else
        {
            index = valueList.Length - 1;
        }
        valueText.SetText(valueList[index]);
    }

    public int getIndex()
    {
        return index;
    }
}
