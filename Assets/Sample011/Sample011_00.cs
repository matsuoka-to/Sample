using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Sample011_00 : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    Button[] buttons;

    [SerializeField]
    float delay = 0.0f;

    [SerializeField]
    float time = 2.0f;

    [SerializeField]
    Ease ease = Ease.Linear;

    [SerializeField]
    int loop = 1;

    [SerializeField]
    LoopType loopType = LoopType.Restart;

    Tween tweener;
    Sequence sequence;

    void Start()
    {
        for(var i = 0; i < buttons.Length; i++)
        {
            var id = i;
            buttons[i].onClick.AddListener(() => ButtonCallBack(id));
        }
    }

    private void ButtonCallBack(int id)
    {
        switch(id)
        {
            case 0: // フェードイン
            {
                image.transform.localPosition = new Vector3(400, 50, 0);
                image.color = new Color(0, 0, 0, 0.0f);
                tweener = image.DOFade(1.0f, time)
                        .SetDelay(delay)
                        .SetEase(ease)
                        .SetLoops(loop, loopType)
                        .OnComplete(CompleteCallBack);
            }
            break;

            case 1: // フェードアウト
            {
                image.transform.localPosition = new Vector3(400, 50, 0);
                image.color = new Color(0, 0, 0, 1.0f);
                tweener = image.DOFade(0.0f, time)
                        .SetDelay(delay)
                        .SetEase(ease)
                        .SetLoops(loop, loopType)
                        .OnComplete(CompleteCallBack);
            }
            break;

            case 2: // 移動
            {
                image.transform.localPosition = new Vector3(400, -217, 0);
                tweener = image.transform.DOLocalMoveX(-185.0f, time)
                        .SetDelay(delay)
                        .SetEase(ease)
                        .SetLoops(loop, loopType)
                        .OnComplete(CompleteCallBack);
            }
            break;

            case 3: // 回転
            {
                image.transform.localPosition = new Vector3(400, 50, 0);
                image.transform.localRotation = Quaternion.Euler(0, 0, 0);
                tweener = image.transform.DORotate(new Vector3(0, 0, 360), time, RotateMode.FastBeyond360)
                        .SetDelay(delay)
                        .SetEase(ease)
                        .SetLoops(loop, loopType)
                        .OnComplete(CompleteCallBack);
            }
            break;

            case 4: // スケール
            {
                image.transform.localPosition = new Vector3(400, 50, 0);
                image.transform.localScale = Vector3.one;
                tweener = image.transform.DOScale(new Vector3(2, 2, 2), time)
                        .SetDelay(delay)
                        .SetEase(ease)
                        .SetLoops(loop, loopType)
                        .OnComplete(CompleteCallBack);
            }
            break;

            case 5: // リセット
            {
                tweener?.Kill();

                image.color = new Color(0, 0, 0, 1.0f);
                image.transform.localPosition = new Vector3(400, 50, 0);
                image.transform.localRotation = Quaternion.Euler(0, 0, 0);
                image.transform.localScale = Vector3.one;
            }
            break;

            case 6: // 再生
            {
                tweener?.Play();
                sequence?.Play();
            }
            break;

            case 7: // 停止
            {
                tweener?.Pause();
                sequence?.Pause();
            }
            break;

            case 8: // Kill
            {
                tweener?.Kill();
                sequence?.Kill();
            }
            break;

            case 9:
            {
                image.transform.localPosition = new Vector3(400, -217, 0);
                var move = image.transform.DOLocalMoveX(-185.0f, time)
                        .SetDelay(delay)
                        .SetEase(ease)
                        .SetLoops(loop, loopType);
                var rot = image.transform.DORotate(new Vector3(0, 0, 360), time, RotateMode.FastBeyond360)
                        .SetDelay(delay)
                        .SetEase(ease)
                        .SetLoops(loop, loopType)
                        .OnComplete(CompleteCallBack);

                sequence = DOTween.Sequence();
                sequence.Append(move).Append(rot);
            }
            break;
        }
    }

    private void CompleteCallBack()
    {
        Debug.LogErrorFormat("Tween CompleteCallBack");
    }


}
