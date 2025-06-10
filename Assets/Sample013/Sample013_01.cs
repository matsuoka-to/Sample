using UnityEngine;
using UnityEngine.UI;

public class Sample013_01 : SceneBase
{
    [SerializeField]
    Button button;

    void Start()
    {
        FadeManager.Instatnce.FadeIn();

        button.onClick.AddListener(OnButtonCallBack);
    }

    private void OnButtonCallBack()
    {
        FadeManager.Instatnce.FadeOut(() =>
        {
            SceneChange(SceneID.Test5);
        });
    }
}
