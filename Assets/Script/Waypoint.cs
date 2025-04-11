using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float minDistance = 0.1f; // Khoảng cách tối thiểu để coi là đã đến waypoint

    private bool isMovingForward = true; // Biến để theo dõi hướng di chuyển

    private void Update()
    {
        // Kiểm tra xem mảng waypoints có phần tử nào không
        if (waypoints.Length == 0)
            return;

        // Kiểm tra khoảng cách giữa đối tượng và waypoint
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < minDistance)
        {
            if (isMovingForward)
            {
                currentWaypointIndex++;
                // Nếu đã đi qua tất cả waypoints, đi ngược lại cho đến điểm waypoint đầu tiên
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = waypoints.Length - 2;
                    isMovingForward = false;

                }
            }
            else
            {
                currentWaypointIndex--;
                if(currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1;
                    isMovingForward = true;
                }
            }
        }
        // Di chuyển đối tượng tới waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
