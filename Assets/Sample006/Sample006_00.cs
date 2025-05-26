using UnityEngine;
using TMPro;

public class Sample006_00 : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inputField;

    public void InputCallBack()
    {
        Debug.LogErrorFormat($"input : {inputField.text}");
    }
}
