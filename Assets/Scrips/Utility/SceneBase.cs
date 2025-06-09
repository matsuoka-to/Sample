using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBase : MonoBehaviour
{
    protected enum SceneID
    {
        Test1,
        Test2,
        Test3
    }

    protected static SceneID beforeScene;
    protected static SceneID nowScene;

    protected void SceneChange(SceneID id)
    {
        beforeScene = nowScene;
        nowScene = id;

        SceneManager.LoadScene((int)id);
    }

}
