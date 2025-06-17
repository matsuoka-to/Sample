using UnityEngine;
using TS.PageSlider;

public class Sample014_00 : MonoBehaviour
{
    [SerializeField]
    PageSlider slider;

    [SerializeField]
    PageScroller pageScroller;

    [SerializeField]
    Sample014_PageItem pageItem;


    void Start()
    {
        for(var i = 0; i < 3; i++)
        {
            var text = string.Format($"text{i}");
            var page = Instantiate(pageItem);
            page.SetText(text);

            slider.AddPage((RectTransform)page.transform);

            if(i == 0)
            {
                pageScroller.OnPageChangeEnded.AddListener(PageScrollerCallBack);
            }
        }
    }

    void PageScrollerCallBack(int before, int after)
    {
        Debug.LogErrorFormat($"PageScrollerCallBack : {before} => {after}");
    }
}
