using System.Collections.Generic;
using UnityEngine;

public abstract class ObserverSubject : MonoBehaviour
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(AchievementType achievementType)
    {
        foreach (IObserver observer in observers)
        {
            observer.OnNotify(achievementType);
        }
    }
}
