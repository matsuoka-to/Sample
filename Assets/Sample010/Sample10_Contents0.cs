using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System;

public class Sample10_Contents0 : Sample10_ContentsBase
{
    [SerializeField]
    Slider[] sounds;

    [SerializeField]
    TextMeshProUGUI[] soundRates;

    [SerializeField]
    Toggle[] notifications;

    [SerializeField]
    Text[] notificationTexts;

    /// <summary>
    /// 初期化
    /// </summary>
    public override void Initialization()
    {
        base.Initialization();

        // サウンド初期化
        for (var i = 0; i < sounds.Length; i++)
        {
            var id = i;

            // テキスト初期化
            var value = Math.Round(sounds[i].value, 2);
            soundRates[i].text = string.Format($"{(float)value * 100.0f}%");

            // スライダー初期化
            sounds[i].onValueChanged.AddListener((rate) => SoudnCallBack(id, rate));
        }

        // トグル初期化
        for (var i = 0; i < notifications.Length; i++)
        {
            var id = i;

            var value = notifications[i].isOn ? "On" : "Off";
            notifications[i].onValueChanged.AddListener((flg) => ToggleCallBack(id, flg));

            // テキスト初期化
            notificationTexts[i].text = string.Format($"＊＊＊通知 : {value}");
        }
    }

    /// <summary>
    /// スライダーのコールバック
    /// </summary>
    private void SoudnCallBack(int id, float rate)
    {
        var value = Math.Round(rate, 2);
        soundRates[id].text = string.Format($"{(float)value * 100.0f}%");
    }

    /// <summary>
    /// トグルコールバック
    /// </summary>
    private void ToggleCallBack(int id, bool flg)
    {
        var value = flg ? "On" : "Off";
        notificationTexts[id].text = string.Format($"＊＊＊通知 : {value}");
    }
}
