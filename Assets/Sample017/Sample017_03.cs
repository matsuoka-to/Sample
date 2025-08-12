using UnityEngine;
using UnityEngine.UI;

public class Sample017_03 : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioEchoFilter audioEcho;

    [SerializeField]
    AudioChorusFilter audioChorus;

    enum ButtonType
    {
        Off,
        Echo00,
        Chorus00,
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
                audioEcho.enabled = false;
                audioChorus.enabled = false;
                audioSource.Play();
            }
            break;

            case ButtonType.Echo00:
            {
                audioEcho.enabled = true;
                audioEcho.delay = 500;
                audioEcho.decayRatio = 0.5f;
                audioEcho.dryMix = 0.7f;
                audioEcho.wetMix = 0.8f;

                audioSource.Play();
            }
            break;

            case ButtonType.Chorus00:
            {
                audioChorus.enabled = true;

                audioChorus.dryMix = 0.5f;
                audioChorus.wetMix1 = 0.7f;
                audioChorus.wetMix2 = 0.7f;
                audioChorus.wetMix3 = 0.7f;
                audioChorus.delay = 40;
                audioChorus.rate = 0.3f;
                audioChorus.depth = 0.8f;

                audioSource.Play();
            }
            break;
        }
    }


}
