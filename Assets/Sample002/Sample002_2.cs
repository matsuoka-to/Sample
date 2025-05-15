using UnityEngine;
using UnityEngine.UI;

public class Sample002_2 : MonoBehaviour
{
    [SerializeField]
    Button[] button;

    void Start()
    {
        for (var i = 0; i < button.Length; i++)
        {
            var id = i;
            button[i].onClick.AddListener(() => Button(id));
        }
    }

    void Button(int id)
    {
        Debug.LogErrorFormat($"ok : {id}");
    }
}
