using System.Collections.Generic;
using UnityEngine;


public class TouchHandler : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private GameplayActivity _gamePlayActivity;

    private void Awake()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray ray = _camera.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
            if (Physics.Raycast(ray, out hit))
            {
                Transform transform = hit.transform;
                if (transform.tag == "hair")
                {
                    UpdatePlayerActivity(ActivitySelectionManager.Instance._selectedActivity, transform);
                }
            }
        }
    }
    public void UpdatePlayerActivity(int activityId, Transform transform)
    {
        switch (activityId)
        {
            case 0:
                _gamePlayActivity.HairCuttingActtivity(transform);
                break;
            case 1:
                _gamePlayActivity.HairTrimmingActivity(transform);
                break;
            case 2:
                _gamePlayActivity.HairRegrowActivity(transform);
                break;
        }
    }
    
}
