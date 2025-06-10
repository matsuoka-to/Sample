using UnityEngine;

public class Sample013_00 : SceneBase
{
    void Start()
    {
        GameObject.DontDestroyOnLoad(this);

        SceneChange(SceneID.Test4);
    }
}
