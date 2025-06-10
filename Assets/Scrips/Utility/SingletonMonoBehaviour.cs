using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instatnce
    {
        get
        {
            if(!instance)
            {
                var t = typeof(T);
                instance = (T)FindFirstObjectByType(t);
            }

            return instance;
        }
    }
}
