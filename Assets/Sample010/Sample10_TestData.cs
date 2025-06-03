using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "TestData")]
public class Sample10_TestData : ScriptableObject
{
    public float hpMin;
    public float hpMax;

    public float mpMin;
    public float mpMax;

    public float expMin;
    public float expMax;

    public float powerRate;
    public float magicRate;
}
