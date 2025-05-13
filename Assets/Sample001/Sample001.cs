using UnityEngine;
using TMPro;

public class Sample001 : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    private void Start()
    {
        text.text = "テスト";
        text.color = Color.blue;
    }

}
