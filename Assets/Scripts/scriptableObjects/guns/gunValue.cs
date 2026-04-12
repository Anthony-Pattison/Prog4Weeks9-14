using Unity.Hierarchy;
using UnityEngine;

public enum weapon{
    pistol,
    rifle
}

[CreateAssetMenu(fileName = "gunValue", menuName = "Scriptable Objects/gunValue")]
public class gunValue : ScriptableObject
{
    public weapon weapon;
    public int currentAmmo;
    public int maxAmmo;
    public int extraAmmo;
    public int damage;
    public float weaponRange;
    public float weaponCoolDown;
}
