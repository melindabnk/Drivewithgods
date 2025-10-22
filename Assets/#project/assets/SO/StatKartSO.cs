using UnityEngine;

[CreateAssetMenu(fileName = "StatKartSo1", menuName = "Scriptable Objects/StatKartSo1")]
public class StatKartSO : ScriptableObject
{
    public float maxSpeed = 20f;
    public float turnSpeed = 100f;
    public float accel = 1f;
    public float decel = 1f;
    public float boostSpeed;

}
