using UnityEngine;

[CreateAssetMenu(fileName = "chillIA", menuName = "Scriptable Objects/chillIA")]
public class IAProfile : ScriptableObject
{
    public float maxSpeed = 25f;
    public float turnSpeed = 300;
    public float accel = 10f;
    public float decel = 10f;
    
}
