using UnityEngine;
using UnityEngine.UI;

public class Sample004_01 : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    Sprite[] sprites;

    int index;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            image.sprite = sprites[index];
            index++;
            if(index >= sprites.Length)
            {
                index = 0;
            }
        }
    }
}
