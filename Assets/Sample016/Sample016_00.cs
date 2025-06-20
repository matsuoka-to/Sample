using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class Sample016_00 : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;

    [SerializeField]
    Text timerText;

    [SerializeField]
    Text hpText;

    [SerializeField]
    InputField[] inputs;

    ReactiveProperty<int> hp = new ReactiveProperty<int>(100);

    void Start()
    {
        for(var i = 0; i < buttons.Length; i++)
        {
            var id = i;
            buttons[i].OnClickAsObservable()
                .Subscribe(_ =>
                {
                    switch(id)
                    {
                        case 0:
                        {
                            ButtonClick();
                        }
                        break;
                        case 1:
                        {
                            TimerUpdate();
                        }
                        break;
                        case 3:
                        {
                            hp.Value--;
                            hpText.text = string.Format($"HP : {hp.Value}");
                        }
                        break;
                        case 4:
                        {
                            hp.Value++;
                            hpText.text = string.Format($"HP : {hp.Value}");
                        }
                        break;
                    }
                })
                .AddTo(this);
        }

        HpChange();
        KeyDowndate();
        InputUpdate();
        TapUpdate();
    }

    /// <summary>
    /// ボタンクリック
    /// </summary>
    private void ButtonClick()
    {
        Debug.LogErrorFormat($"Clicked");
    }

    /// <summary>
    /// 1秒ごとに処理を実行！
    /// </summary>
    private void TimerUpdate()
    {
        Observable.Interval(TimeSpan.FromSeconds(1))
                  .Subscribe(_ =>
                  {
                      timerText.text = string.Format($"Timer : {_}");
                  })
                  .AddTo(this);
    }

    /// <summary>
    /// 変数の変更でUIを自動更新
    /// </summary>
    private void HpChange()
    {
        hp.Subscribe(value =>
        {
            Debug.LogErrorFormat($"HP: {value}");
        })
        .AddTo(this);
    }

    /// <summary>
    /// キー入力を監視
    /// </summary>
    private void KeyDowndate()
    {
        Observable.EveryUpdate()
                  .Where(_ => Input.GetKeyDown(KeyCode.Space))
                  .Subscribe(_ =>
                  {
                      Debug.LogErrorFormat("スペースキーが押されました");
                  })
                  .AddTo(this);
    }

    /// <summary>
    /// 複数の UI 入力チェック
    /// </summary>
    private void InputUpdate()
    {
        Observable.CombineLatest(
            inputs[0].OnValueChangedAsObservable(),
            inputs[1].OnValueChangedAsObservable(),
            (username, password) => !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password)
        )
        .Subscribe(canLogin =>
        {
            buttons[5].interactable = canLogin;
        })
        .AddTo(this);
    }

    /// <summary>
    /// タップチェック
    /// </summary>
    private void TapUpdate()
    {
        buttons[2].OnClickAsObservable()
              .ThrottleFirst(TimeSpan.FromSeconds(3))
              .Subscribe(_ =>
              {
                  Debug.LogErrorFormat($"tap");
              })
              .AddTo(this);
    }
}
