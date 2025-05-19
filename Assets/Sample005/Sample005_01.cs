using UnityEngine;
using UnityEngine.UI;

public class Sample005_01 : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    void Start()
    {
        slider.onValueChanged.AddListener(SliderCallBack);
    }

    void SliderCallBack(float value)
    {
        Debug.LogErrorFormat($"slider : {value}");
    }
}
