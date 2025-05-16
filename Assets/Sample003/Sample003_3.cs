using UnityEngine;
using UnityEngine.UI;

public class Sample003_3 : MonoBehaviour
{
    [SerializeField]
    ToggleGroup toggleGroup;

    [SerializeField]
    Toggle[] toggles;

    [SerializeField]
    Text[] text;

    int index;

    void Start()
    {
        for(var i = 0; i < 5; i++)
        {
            toggles[i].onValueChanged.AddListener(ToggleCallBack);
            text[i].text = "Off";
        }

        index = 0;
        text[0].text = "On";
    }

    void ToggleCallBack(bool flg)
    {
        var name = toggleGroup.GetFirstActiveToggle().name;
        var num = name.Replace("Toggle", "");
        var id = int.Parse(num);

        text[index].text = "Off";
        text[id].text = flg ? "On" : "Off";
        index = id;

        Debug.LogErrorFormat($"toggle : {name} | {flg}");
    }

}
