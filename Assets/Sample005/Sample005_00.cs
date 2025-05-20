using UnityEngine;
using UnityEngine.UI;

public class Sample005_00 : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    public void SliderCallBack()
    {
        Debug.LogErrorFormat($"slider : {slider.value}");
    }
}
