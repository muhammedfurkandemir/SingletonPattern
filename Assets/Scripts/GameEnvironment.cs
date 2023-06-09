using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnvironment 
{
    private static GameEnvironment instance;
    private List<GameObject> obstacles = new List<GameObject>();
    private List<GameObject> goalLocations = new List<GameObject>();
    public List<GameObject> Obstacles { get { return obstacles; } }
    public List<GameObject> GoalLocations { get { return goalLocations; } }

    public static GameEnvironment Singleton //veri gödereceğimiz property alanı
    {
        get
        {
            if (instance==null)
            {
                instance = new GameEnvironment();
                instance.GoalLocations.AddRange(GameObject.FindGameObjectsWithTag("goal"));//örnke oluşturulduğunda hedef noktaları listemize burdan alırız.
            }
            return instance;
        }
    }
    public void AddObstacles(GameObject go)//obstacles ekler
    {
        obstacles.Add(go);
    }
    public GameObject GetRandomGoal()
    {
        int index = Random.Range(0, goalLocations.Count);
        return goalLocations[index];
    }
    public void RemoveObstacles(GameObject go)//obstacles siler
    {
        int index = obstacles.IndexOf(go);
        obstacles.RemoveAt(index);
        GameObject.Destroy(go);
    }
}
