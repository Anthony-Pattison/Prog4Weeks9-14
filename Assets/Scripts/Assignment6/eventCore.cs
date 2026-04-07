using UnityEngine;
using UnityEngine.Events;

public class eventCore : MonoBehaviour
{
    public UnityEvent<float> playerDamage;

    public UnityEvent<string, float> EV_enemyDamage;

    public UnityEvent<float> EV_increasePlayerAmmo;

    public UnityEvent<string, float> EV_increaseHealth;
}
