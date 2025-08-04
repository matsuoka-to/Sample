using UnityEngine;
using UnityEngine.UI;

public class Sample017_00 : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;

    [SerializeField]
    Slider[] sliders;

    [SerializeField]
    AudioSource[] audioSources;

    enum ButtonType
    {
        BGM_Play,
        BGM_Stop,
        OK_Play,
        Cancel_Play
    }

    enum SoundType
    {
        BGM,
        OK,
        Cancel
    }

    float bgmValue;
    float seValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(var i = 0; i < buttons.Length; i++)
        {
            var id = i;
            buttons[i].onClick.AddListener(() => ButtonCallBack(id));
        }

        for(var i = 0; i < sliders.Length; i++)
        {
            var id = i;
            sliders[i].onValueChanged.AddListener((value) => SliderCallBack(id, value));
        }

        bgmValue = sliders[0].value;
        seValue = sliders[1].value;
    }

    /// <summary>
    /// ボタンのコールバック
    /// </summary>
    void ButtonCallBack(int id)
    {
        switch((ButtonType)id)
        {
            case ButtonType.BGM_Play:
                audioSources[(int)SoundType.BGM].volume = bgmValue;
                audioSources[(int)SoundType.BGM].Play();
            break;

            case ButtonType.BGM_Stop:
                audioSources[(int)SoundType.BGM].Stop();
            break;

            case ButtonType.OK_Play:
                audioSources[(int)SoundType.OK].volume = seValue;
                audioSources[(int)SoundType.OK].Play();
            break;

            case ButtonType.Cancel_Play:
                audioSources[(int)SoundType.Cancel].volume = seValue;
                audioSources[(int)SoundType.Cancel].Play();
            break;
        }
    }

    void SliderCallBack(int id, float value)
    {
        switch(id)
        {
            case 0:
                bgmValue = value;
                audioSources[(int)SoundType.BGM].volume = bgmValue;
            break;

            case 1:
                seValue = value;
            break;
        }
    }


}
