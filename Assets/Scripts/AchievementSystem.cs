using PlayerTank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour, IObserver
{
    private TankView tankView;
    private int crashes;

    public void Initialize()
    {
        crashes = 0;
        tankView = GetComponentInParent<TankView>();
        tankView.AddObserver(this);
    }

    public void OnNotify()
    {
        crashes++;

        switch(crashes)
        {
            case 10:
                Debug.Log("10 crashes");
                break;

            case 20:
                Debug.Log("20 crashes");
                break;

            case 30:
                Debug.Log("30 crashes");
                break;

            default:
                break;
        }
    }
}
