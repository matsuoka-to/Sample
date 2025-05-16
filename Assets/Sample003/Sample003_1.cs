using UnityEngine;
using UnityEngine.UI;

public class Sample003_1 : MonoBehaviour
{
    [SerializeField]
    Text[] text;

    int index;

    void Start()
    {
        index = 0;
        for(var i = 0; i < text.Length; i++)
        {
            text[i].text = "Off";
        }
        text[0].text = "On";
    }

    public void ToggleCallBack(Toggle toggle)
    {
        Debug.LogErrorFormat($"{toggle.name} | {toggle.isOn}");

        var num = toggle.name.Replace("Toggle", "");
        var id = int.Parse(num);

        text[index].text = "Off";
        text[id].text = toggle.isOn ? "On" : "Off";
        index = id;
    }
}
