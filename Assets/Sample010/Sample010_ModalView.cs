using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sample010_ModalView : MonoBehaviour
{
    [SerializeField]
    Button button;

    [SerializeField]
    Toggle[] toggles;

    [SerializeField]
    Sample10_ContentsBase[] parent;

    int tabID;
    public bool IsEnd;

    private void Start()
    {
        tabID = 0;
        IsEnd = false;

        parent[0].Initialization();

        // トグル初期化
        for (var i = 0; i < toggles.Length; i++)
        {
            var id = i;
            toggles[i].onValueChanged.AddListener((flg) => ToggleCallBack(id, flg));
        }

        // ボタンのコールバック
        button.onClick.AddListener(ButtonCallBack);
    }

    /// <summary>
    /// トグルコールバック
    /// </summary>
    private void ToggleCallBack(int id, bool flg)
    {
        if (flg)
        {
            // Contents切り替え
            parent[tabID].gameObject.SetActive(false);
            parent[id].Initialization();
            parent[id].gameObject.SetActive(true);

            tabID = id;
        }
    }

    private void ButtonCallBack()
    {
        IsEnd = true;
    }

}
