using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sample10_TestItem : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;

    [SerializeField]
    Image image;

    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    Button button;

    public void SetInit(int tab, int id, Action<int> callback)
    {
        image.sprite = sprites[tab];

        switch (tab)
        {
            case 0:
            {
                if(id == 0)
                {
                    text.text = string.Format($"なし");
                }
                else
                {
                    text.text = string.Format($"武器{id}");
                }
            }
            break;

            case 1:
            {
                if(id == 0)
                {
                    text.text = string.Format($"なし");
                }
                else
                {
                    text.text = string.Format($"盾{id}");
                }
            }
            break;

            case 2:
            {
                if(id == 0)
                {
                    text.text = string.Format($"なし");
                }
                else
                {
                    text.text = string.Format($"魔法{id}");
                }
            }
            break;
        }

        button.onClick.AddListener(() =>
        {
            callback.Invoke(id);
        });
    }
}
