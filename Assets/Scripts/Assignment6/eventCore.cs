using UnityEngine;
using UnityEngine.Events;

public class eventCore : MonoBehaviour
{
    public UnityEvent<float> playerDamage;

    public UnityEvent<string, float> EV_enemyDamage;

    public UnityEvent<float> EV_increasePlayerAmmo;

    public UnityEvent<string, float> EV_increaseHealth;

    public UnityEvent<string> EV_targetShot;

    public UnityEvent EV_playerReload;

    public UnityEvent EV_playerShoot;

    public UnityEvent EV_pauseGame;

    public UnityEvent EV_unPauseGame;

    public UnityEvent<onScreenText> EV_upgradePickUp;
}
