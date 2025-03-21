using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/WeaponData", fileName = "Weapon Data")]
public class WeaponData : ScriptableObject
{
    public AudioClip attackClip;  //공격 소리
    public float damage;    //공격력
    public int energyCost;  //기력 소모량
    public float castingTime;   //공격속도
}
