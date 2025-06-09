using UnityEngine;
using UnityEngine.UI;

public class Sample012_Test2 : SceneBase
{
    [SerializeField]
    Button[] buttons;

    void Start()
    {
        for(var i = 0; i < buttons.Length; i++)
        {
            var id = i;
            buttons[i].onClick.AddListener(() => OnButtonCallBack(id));
        }
    }

    private void OnButtonCallBack(int id)
    {
        switch(id)
        {
            case 0:
            {
                SceneChange(SceneID.Test1);
            }
            break;
            case 1:
            {
                SceneChange(SceneID.Test3);
            }
            break;
            case 2:
            {
                SceneChange(beforeScene);
            }
            break;
        }
    }
}
