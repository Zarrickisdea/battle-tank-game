using PlayerTank;
using System.Collections;
using TMPro;
using UnityEngine;

public class AchievementSystem : MonoBehaviour, IObserver
{
    private TankView tankView;
    private int crashes;

    [SerializeField] private TextMeshPro text;

    public void Initialize()
    {
        crashes = 0;
        text.gameObject.SetActive(false);
        tankView = GetComponentInParent<TankView>();
        tankView.AddObserver(this);
    }

    public void OnNotify()
    {
        crashes++;
        switch (crashes)
        {
            case 5:
                ShowText("5 crashes");
                break;

            case 15:
                ShowText("15 crashes");
                break;

            case 30:
                ShowText("30 crashes");
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
