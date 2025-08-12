using UnityEngine;
using UnityEngine.UI;

public class Sample017_02 : MonoBehaviour
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
        Echo00,
        Echo01,
        Echo02,
        Echo03,
        Chorus00,
        Chorus01,
        Chorus02,
        Chorus03,
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
            case ButtonType.Echo00:
            {
                audioEcho.enabled = false;
                audioSource.Play();
            }
            break;

            case ButtonType.Echo01:
            {
                audioEcho.enabled = true;
                audioEcho.delay = 350;
                audioEcho.decayRatio = 0.4f;
                audioEcho.dryMix = 1.0f;
                audioEcho.wetMix = 0.3f;

                audioSource.Play();
            }
            break;

            case ButtonType.Echo02:
            {
                audioEcho.enabled = true;
                audioEcho.delay = 1200;
                audioEcho.decayRatio = 0.7f;
                audioEcho.dryMix = 0.8f;
                audioEcho.wetMix = 0.5f;

                audioSource.Play();
            }
            break;

            case ButtonType.Echo03:
            {
                audioEcho.enabled = true;
                audioEcho.delay = 500;
                audioEcho.decayRatio = 0.9f;
                audioEcho.dryMix = 0.6f;
                audioEcho.wetMix = 0.7f;

                audioSource.Play();
            }
            break;

            case ButtonType.Chorus00:
            {
                audioChorus.enabled = false;
                audioSource.Play();
            }
            break;

            case ButtonType.Chorus01:
            {
                audioChorus.enabled = true;

                audioChorus.dryMix = 1.0f;
                audioChorus.wetMix1 = 0.4f;
                audioChorus.delay = 30;
                audioChorus.rate = 0.5f;
                audioChorus.depth = 0.3f;

                audioSource.Play();
            }
            break;

            case ButtonType.Chorus02:
            {
                audioChorus.enabled = true;

                audioChorus.dryMix = 0.8f;
                audioChorus.wetMix1 = 0.6f;
                audioChorus.delay = 40;
                audioChorus.rate = 0.7f;
                audioChorus.depth = 0.7f;

                audioSource.Play();
            }
            break;

            case ButtonType.Chorus03:
            {
                audioChorus.enabled = true;

                audioChorus.dryMix = 0.6f;
                audioChorus.wetMix1 = 0.9f;
                audioChorus.delay = 5;
                audioChorus.rate = 3.0f;
                audioChorus.depth = 1.0f;

                audioSource.Play();
            }
            break;
        }
    }


}
