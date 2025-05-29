using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TestItem : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;

    [SerializeField]
    Image image;

    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    Button button;

    public void SetInit(int id, Action<int> callback)
    {
        image.sprite = sprites[id % sprites.Length];
        text.text = string.Format($"item{id}");
        button.onClick.AddListener(() =>
        {
            callback.Invoke(id);
        });
    }

}
