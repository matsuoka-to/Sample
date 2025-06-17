using UnityEngine;
using TMPro;

public class Sample014_PageItem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public void SetText(string text)
    {
        this.text.text = text;
    }

}
