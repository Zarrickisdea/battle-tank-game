using PlayerTank;
using System.Collections;
using TMPro;
using UnityEngine;

public class AchievementSystem : MonoBehaviour, IObserver
{
    private TankView tankView;
    private int crashes;
    private int bulletsFired;
    private int bulletsHit;

    [SerializeField] private TextMeshPro text;

    public void Initialize()
    {
        crashes = 0;
        bulletsFired = 0;
        bulletsHit = 0;
        text.gameObject.SetActive(false);
        tankView = GetComponentInParent<TankView>();
        tankView.AddObserver(this);
    }

    public void OnNotify(AchievementType achievementType)
    {
        switch(achievementType)
        {
            case AchievementType.Crashes:
                crashes++;
                
                if (crashes == 5)
                {
                    ShowText("5 Crashes!");
                }
                else if (crashes == 10)
                {
                    ShowText("10 Crashes!");
                }
                else if (crashes == 25)
                {
                    ShowText("Too Many Crashes!");
                }
                break;

            case AchievementType.BulletsFired:
                bulletsFired++;
                if (bulletsFired == 5)
                {
                    ShowText("5 Bullets Fired!");
                }
                else if (bulletsFired == 10)
                {
                    ShowText("10 Bullets Fired!");
                }
                else if (bulletsFired == 25)
                {
                    ShowText("25 Bullets Fired!");
                }
                break;

            case AchievementType.BulletsHit:
                bulletsHit++;
                if (bulletsHit == 1)
                {
                    ShowText("First Bullet Hit!");
                }
                else if (bulletsHit == 5)
                {
                    ShowText("5 Bullets Hit!");
                }
                else if (bulletsHit == 10)
                {
                    ShowText("10 Bullets Hit!");
                }
                break;

        }
    }

    private void ShowText(string message)
    {
        text.gameObject.SetActive(true);
        text.text = message;
        StartCoroutine(HideText());
    }

    private IEnumerator HideText()
    {
        yield return new WaitForSeconds(3);
        text.gameObject.SetActive(false);
    }
}

public enum AchievementType
{
    Crashes,
    BulletsFired,
    BulletsHit,
}
