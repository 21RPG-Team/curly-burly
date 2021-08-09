using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    [SerializeField] new public string name = "<Quest name>";

    protected List<Reward> rewards;
    protected List<Goal> goals;

    [SerializeField] private List<string> sentences;

    protected bool completed;

    public List<Goal> Goals { get => goals; }

    public List<string> Sentences { get => sentences; }
    public int GoalsCount { get => goals.Count; }
    public void CheckGoals()
    {
        completed = goals.TrueForAll(goal => goal.Completed);
        if (completed)
            gameObject.GetComponent<NPCController>().QuestDone();
    }

    public void GiveRewards()
    {
        QuestManager.Instance.Remove(this);

        foreach (Goal goal in goals)
            goal.Finish();

        foreach (Reward reward in rewards)
            reward.GiveReward();
    }
}