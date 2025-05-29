using UnityEngine;

public class Sample008_00 : MonoBehaviour
{
    [SerializeField]
    TestItem itemObject;

    [SerializeField]
    GameObject contenParent;

    void Start()
    {
        for(var i = 0; i < 30; i++)
        {
            var data = TestItem.Instantiate(itemObject, contenParent.transform);
            data.SetInit(i, ItemCallBack);
        }
    }

    void ItemCallBack(int id)
    {
        Debug.LogErrorFormat($"item : {id}");
    }

}
