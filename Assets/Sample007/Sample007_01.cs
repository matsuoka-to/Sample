using UnityEngine;
using TMPro;

public class Sample007_01 : MonoBehaviour
{
    [SerializeField]
    TMP_Dropdown dropdown;

    void Start()
    {
        dropdown.options.Clear();
        for(var i = 0; i < 10; i++)
        {
            var item = new TMP_Dropdown.OptionData();
            item.text = string.Format($"item{i}");
            dropdown.options.Add(item);
        }

        dropdown.onValueChanged.AddListener(DropDownCallBack);
    }

    void DropDownCallBack(int id)
    {
        Debug.LogErrorFormat($"drop : {id} | {dropdown.options[id].text}");
    }

}
