using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System.Collections.Generic;

public class Sample10_Contents2 : Sample10_ContentsBase
{
    [SerializeField]
    Toggle[] toggles;

    [SerializeField]
    TextMeshProUGUI[] text;

    [SerializeField]
    Sample10_TestItem itemObject;

    [SerializeField]
    ScrollRect scrollRect;

    [SerializeField]
    GameObject contenParent;

    int tabID = 0;
    List<Sample10_TestItem> itemData = new List<Sample10_TestItem>();

    /// <summary>
    /// 初期化
    /// </summary>
    public override void Initialization()
    {
        base.Initialization();

        // トグル登録
        for (var i = 0; i < toggles.Length; i++)
        {
            var id = i;
            toggles[i].onValueChanged.AddListener((flg) => ToggleCallBack(id, flg));

            // テキスト初期化
            text[i].text = "なし";
        }

        // リストの中身設定
        CreateItem(tabID);
    }

    /// <summary>
    /// トグルコールバック
    /// </summary>
    private void ToggleCallBack(int id, bool flg)
    {
        if (flg)
        {
            tabID = id;
            CreateItem(tabID);
        }
    }

    /// <summary>
    /// リストの中身設定
    /// </summary>
    private void CreateItem(int tab)
    {
        // 中身を削除
        for(var i = itemData.Count - 1; i >= 0; i--)
        {
            GameObject.Destroy(itemData[i].gameObject);
        }
        itemData.Clear();

        scrollRect.verticalNormalizedPosition = 1.0f;

        // 中身を作成
        for (var i = 0; i < 30; i++)
        {
            var id = i;

            var data = Sample10_TestItem.Instantiate(itemObject, contenParent.transform);
            data.SetInit(tab, id, ItemCallBack);

            itemData.Add(data);
        }
    }

    /// <summary>
    /// アイテムのコールバック
    /// </summary>
    private void ItemCallBack(int id)
    {
        if(id == 0)
        {
            text[tabID].text = "なし";
        }
        else
        {
            switch(tabID)
            {
                case 0:
                {
                    text[tabID].text = string.Format($"武器{id}");
                }
                break;

                case 1:
                {
                    text[tabID].text = string.Format($"盾{id}");
                }
                break;

                case 2:
                {
                    text[tabID].text = string.Format($"魔法{id}");
                }
                break;
            }
        }
    }
}
