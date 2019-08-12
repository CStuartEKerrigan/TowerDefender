using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] int towerLimit = 5;
    [SerializeField] Transform UITransform;
    [SerializeField] Transform towerTransform;
    private Queue<TowerController> towers = new Queue<TowerController>();
    private UIAudioLibrary speech;

    public void Start()
    {
        speech = FindObjectOfType<UIAudioLibrary>();
    }

    public void AddTower(Waypoint point)
    {
        if (point.isPlaceable)
        {
            if (towers.Count < towerLimit)
            {
                CreateNewTower(point);
            }
            else
            {
                MoveExistingTower(point);
            }
        }
        else {
            speech.playSpeech(0);
        }
    }

    private void CreateNewTower(Waypoint point)
    {
        TowerController tower = Instantiate(towerPrefab, point.transform.position, Quaternion.identity,towerTransform).GetComponent<TowerController>();
        tower.point = point;
        point.isPlaceable = false;
        towers.Enqueue(tower);
        UITransform.transform.position = new Vector3(tower.transform.position.x, UITransform.position.y, tower.transform.position.z);
    }

    private void MoveExistingTower(Waypoint newPoint)
    {
        TowerController tower = towers.Dequeue();
        Waypoint oldPoint = tower.point;
        oldPoint.isPlaceable = true;
        tower.point = newPoint;
        tower.transform.position = newPoint.transform.position;
        towers.Enqueue(tower);
        newPoint.isPlaceable = false;
        tower.SetTargetEnemy();
        UITransform.transform.position = new Vector3(tower.transform.position.x, UITransform.position.y, tower.transform.position.z);
    }
}
