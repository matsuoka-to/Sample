using UnityEngine;
using UnityEngine.UI;

public class Sample003_2 : MonoBehaviour
{
    [SerializeField]
    Toggle toggle;

    [SerializeField]
    Text text;


    void Start()
    {
        toggle.onValueChanged.AddListener(ToggleCallBack);
    }

    void ToggleCallBack(bool flg)
    {
        Debug.LogErrorFormat($"toggle : {flg}");
        text.text = flg ? "On" : "Off";
    }
}
