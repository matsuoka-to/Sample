using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

public class Sample015_00 : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;

    [SerializeField]
    Image[] images;

    bool whileFlg;
    CancellationTokenSource cancellationTokenSource;

    void Start()
    {
        for(var i = 0; i < buttons.Length; i++)
        {
            var id = i;
            buttons[i].onClick.AddListener(() => ButtonCallBack(id));
        }
    }

    void ButtonCallBack(int id)
    {
        switch(id)
        {
            case 0:
            {
                TestDelay().Forget();
            }
            break;

            case 1:
            {
                TestWaitUntil().Forget();
            }
            break;

            case 2:
            {
                TestWaitAll().Forget();
            }
            break;

            case 3:
            {
                TestWhenAll().Forget();
            }
            break;

            case 4:
            {
                TestWhenAny().Forget();
            }
            break;

            case 5:
            {
                TestYield().Forget();
            }
            break;

            case 6:
            {
                ResourcesClear();
                if (whileFlg != true)
                {
                    cancellationTokenSource?.Cancel();
                }
                whileFlg = false;
            }
            break;
        }
    }

    /// <summary>
    /// キャッシュクリア
    /// </summary>
    void ResourcesClear()
    {
        images[0].sprite = null;
        images[1].sprite = null;
        images[2].sprite = null;

        Resources.UnloadUnusedAssets();
    }

    /// <summary>
    /// Delay
    /// </summary>
    async UniTask TestDelay()
    {
        Debug.LogErrorFormat("3秒開始");

        try
        {
            cancellationTokenSource = new CancellationTokenSource();
            await UniTask.Delay(TimeSpan.FromSeconds(3), cancellationToken: cancellationTokenSource.Token);

            Debug.LogErrorFormat("3秒終了");
        }
        catch (OperationCanceledException)
        {
            Debug.LogErrorFormat("キャンセルしました");
        }
    }

    /// <summary>
    /// WaitUntil
    /// </summary>
    async UniTask TestWaitUntil()
    {
        ResourcesClear();

        Debug.LogErrorFormat("load開始");

        try
        {
            cancellationTokenSource = new CancellationTokenSource();
            var data = Resources.LoadAsync<Sprite>("Textures/Potions/64/potion_blue_64");
            await UniTask.WaitUntil(() => data.isDone, cancellationToken: cancellationTokenSource.Token);
            images[0].sprite = data.asset as Sprite;

            Debug.LogErrorFormat($"load終了");
        }
        catch (OperationCanceledException)
        {
            Debug.LogErrorFormat("キャンセルしました");
        }
    }

    /// <summary>
    /// WaitWhile
    /// </summary>
    async UniTask TestWaitWhile()
    {
        whileFlg = true;
        Debug.LogErrorFormat("whileFlgをfalseになるまで待機");

        try
        {
            cancellationTokenSource = new CancellationTokenSource();
            await UniTask.WaitWhile(() => whileFlg, cancellationToken: cancellationTokenSource.Token);

            Debug.LogErrorFormat("whileFlgをfalseになりました");
        }
        catch (OperationCanceledException)
        {
            Debug.LogErrorFormat("キャンセルしました");
        }
    }

    /// <summary>
    /// WhenAll
    /// </summary>
    async UniTask TestWhenAll()
    {
        ResourcesClear();

        Debug.LogErrorFormat("load開始");

        var paths = new[] { "Textures/Potions/64/potion_blue_64", "Textures/Potions/64/potion_green_64", "Textures/Potions/64/potion_orange_64" };
        var loadTasks = paths.Select(p => Resources.LoadAsync<Sprite>(p).ToUniTask());
        var sprites = await UniTask.WhenAll(loadTasks);
        images[0].sprite = sprites[0] as Sprite;
        images[1].sprite = sprites[1] as Sprite;
        images[2].sprite = sprites[2] as Sprite;

        Debug.LogErrorFormat($"load終了");
    }

    /// <summary>
    /// WhenAny
    /// </summary>
    async UniTask TestWhenAny()
    {
        ResourcesClear();

        Debug.LogErrorFormat("load開始");

        var paths = new[] { "Textures/Potions/64/potion_blue_64", "Textures/Potions/64/potion_green_64", "Textures/Potions/64/potion_orange_64" };
        var loadTasks = paths.Select(p => Resources.LoadAsync<Sprite>(p).ToUniTask());
        var (task, sprite) = await UniTask.WhenAny(loadTasks);
        images[0].sprite = sprite as Sprite;
        images[1].sprite = sprite as Sprite;
        images[2].sprite = sprite as Sprite;

        Debug.LogErrorFormat($"load終了");
    }

    /// <summary>
    /// Yield
    /// </summary>
    async UniTask TestYield()
    {
        Debug.LogErrorFormat("開始");

        try
        {
            cancellationTokenSource = new CancellationTokenSource();
            await UniTask.Yield(cancellationToken: cancellationTokenSource.Token);
            Debug.LogErrorFormat("1");

            await UniTask.Yield(cancellationToken: cancellationTokenSource.Token);
            Debug.LogErrorFormat("2");

            await UniTask.Yield(cancellationToken: cancellationTokenSource.Token);
            Debug.LogErrorFormat("3");

            await UniTask.Yield(cancellationToken: cancellationTokenSource.Token);

            Debug.LogErrorFormat("終了");
        }
        catch (OperationCanceledException)
        {
            Debug.LogErrorFormat("キャンセルしました");
        }
    }
}
