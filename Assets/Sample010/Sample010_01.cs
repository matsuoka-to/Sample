using UnityEngine;
using UnityEngine.UI;

public class Sample010_01 : MonoBehaviour
{
    [SerializeField]
    Sample010_ModalView dialogBase;

    [SerializeField]
    Button button;

    Sample010_ModalView dialog;

    bool buttonFlg;

    void Start()
    {
        buttonFlg = false;
        button.onClick.AddListener(ButtonCallBack);
    }

    private void ButtonCallBack()
    {
        if(buttonFlg == false)
        {
            buttonFlg = true;
            dialog = Sample010_ModalView.Instantiate(dialogBase, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(dialog != null && dialog.IsEnd)
        {
            GameObject.Destroy(dialog.gameObject);
            dialog = null;

            buttonFlg = false;
        }
    }
}
