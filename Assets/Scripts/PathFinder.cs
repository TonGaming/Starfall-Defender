using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    // hạn chế cả PathFinder và EnemySpawner đều có SerializeField gọi tới SO, chỉ để EnemySpawner gọi tới thôi và waveConfig sẽ thông qua enemySpawner
    WaveConfigSO waveConfig;
    EnemySpawner enemySpawner;


    List<Transform> waypoints ;

    int waypointsIndex = 0;

    void Awake()
    {
        
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        // Gọi tới WaveConfigSO thông qua EnemySpawner
        waveConfig = enemySpawner.GetCurrentWave();

        // sau đó gán list waypoints đã có sẵn vào list waypoints mới tạo bên này
        waypoints = waveConfig.GetWaypoints();

        //  vị trí của bdau enemy = vị trí của waypoints đầu tiên 
        transform.position = waypoints[waypointsIndex].position;


    }

    void Update()
    {
        PathRunner();
    }

    // để làm enemy di chuyển cần có: vị trí hiện tại, điểm đến kế tiếp, hướng di chuyển, tốc độ di chuyển
    void PathRunner()
    {
        // nếu vẫn còn path chưa đi hết
        if (waypointsIndex < waypoints.Count)
        {

            // gán điểm đến tiếp theo vào biến vector2
            Vector2 targetPosition = waypoints[waypointsIndex].position;

            // khoảng cách di chuyển giữa các frame
            float movedEachFrame = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;

            // sử dụng MoveTowards để làm vật di chuyển về 1 hướng nhất định vs 1 speed tuỳ chỉnh
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movedEachFrame);

            // nếu đã đạt tới vị trí của điểm đến tiếp theo, ta tăng waypointsIndex để hướng tới vị trí kế
            if(transform.position == waypoints[waypointsIndex].position)
            {
                waypointsIndex++;
            }

        }
        // nếu đã đi hết path
        else
        {
            Destroy(gameObject);
        }
    }
}
