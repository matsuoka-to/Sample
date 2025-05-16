using UnityEngine;
using UnityEngine.UI;

public class Sample003_0 : MonoBehaviour
{
    [SerializeField]
    Text text;

    public void ToggleCallBack(Toggle toggle)
    {
        Debug.LogErrorFormat($"toggle : {toggle.isOn}");

        text.text = toggle.isOn ? "On" : "Off";
    }


}
