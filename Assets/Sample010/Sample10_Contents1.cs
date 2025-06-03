using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sample10_Contents1 : Sample10_ContentsBase
{
    [SerializeField]
    Image[] bar;

    [SerializeField]
    TextMeshProUGUI[] barRate;

    [SerializeField]
    Sample10_TestData testData;

    /// <summary>
    /// 初期化
    /// </summary>
    public override void Initialization()
    {
        base.Initialization();

        // HP状態
        var hpMin = testData.hpMin;
        var hpMax = testData.hpMax;
        var hpRate = hpMin / hpMax;

        // MP状態
        var mpMin = testData.mpMin;
        var mpMax = testData.mpMax;
        var mpRate = mpMin / mpMax;

        // Exp状態
        var expMin = testData.expMin;
        var expMax = testData.expMax;
        var expRate = expMin / expMax;

        // テキスト表示
        barRate[0].text = string.Format($"{hpMin} / {hpMax}");
        barRate[1].text = string.Format($"{mpMin} / {mpMax}");
        barRate[2].text = string.Format($"{expMin} / {expMax}");

        // バー表示
        bar[0].fillAmount = hpRate;
        bar[1].fillAmount = mpRate;
        bar[2].fillAmount = expRate;
        bar[3].fillAmount = testData.powerRate;
        bar[4].fillAmount = testData.magicRate;
    }
}
