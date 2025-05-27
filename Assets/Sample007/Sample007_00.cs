using UnityEngine;
using TMPro;

public class Sample007_00 : MonoBehaviour
{
    [SerializeField]
    TMP_Dropdown dropdown;

    public void DropDownCallBack()
    {
        Debug.LogErrorFormat($"drop : {dropdown.captionText.text}");
    }
}
