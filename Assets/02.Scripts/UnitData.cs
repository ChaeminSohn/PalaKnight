using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/UnitData", fileName = "Unit Data")]
public class UnitData : ScriptableObject
{
    public float damage;
    public float hp;
    public float range;
    public float speed;
}
