using UnityEngine;
using TMPro;

public class Sample006_01 : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inputField;

    void Start()
    {
        inputField.onValueChanged.AddListener(InputCallBack);
    }

    void InputCallBack(string value)
    {
        Debug.LogErrorFormat($"input : {value}");
    }

}
