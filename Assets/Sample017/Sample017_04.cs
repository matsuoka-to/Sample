using UnityEngine;
using UnityEngine.UI;

public class Sample017_04 : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioDistortionFilter audioDistortion;

    [SerializeField]
    AudioLowPassFilter audioLow;

    [SerializeField]
    AudioHighPassFilter audioHigh;

    enum ButtonType
    {
        Off,
        Distortion,
        Low,
        High
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(var i = 0; i < buttons.Length; i++)
        {
            var id = i;
            buttons[i].onClick.AddListener(() => ButtonCallBack(id));
        }
    }

    /// <summary>
    /// ボタンのコールバック
    /// </summary>
    void ButtonCallBack(int id)
    {
        switch((ButtonType)id)
        {
            case ButtonType.Off:
            {
                audioDistortion.enabled = false;
                audioLow.enabled = false;
                audioHigh.enabled = false;
                audioSource.Play();
            }
            break;

            case ButtonType.Distortion:
            {
                audioDistortion.enabled = true;
                audioLow.enabled = false;
                audioHigh.enabled = false;
                audioDistortion.distortionLevel = 0.7f;

                audioSource.Play();
            }
            break;

            case ButtonType.Low:
            {
                audioDistortion.enabled = false;
                audioLow.enabled = true;
                audioHigh.enabled = false;
                audioLow.cutoffFrequency = 500.0f;
                audioLow.lowpassResonanceQ = 1.0f;

                audioSource.Play();
            }
            break;

            case ButtonType.High:
            {
                audioDistortion.enabled = false;
                audioLow.enabled = false;
                audioHigh.enabled = true;
                audioHigh.cutoffFrequency = 5000.0f;
                audioHigh.highpassResonanceQ = 1.0f;

                audioSource.Play();
            }
            break;
        }
    }


}
