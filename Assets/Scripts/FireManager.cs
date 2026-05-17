using UnityEngine;

namespace Assets.PixelFantasy.PixelHeroes.Common.Scripts.ExampleScripts
{
    public class ObstacleManager : MonoBehaviour
    {
        [Header("동적 생성할 불 프리팹")]
        [SerializeField] private GameObject firePrefab;

        [Header("불이 생성될 X, Y 좌표 목록")]
        [SerializeField] private Vector2[] spawnPositions;

        void Start()
        {
            // 게임 시작과 동시에 설정된 모든 좌표에 불 오브젝트를 동적 생성
            foreach (Vector2 pos in spawnPositions)
            {
                if (firePrefab != null)
                {
                    // Vector2를 Vector3로 변환하여 생성 (Z축은 0)
                    Vector3 spawnPos = new Vector3(pos.x, pos.y, 0f);
                    Instantiate(firePrefab, spawnPos, Quaternion.identity);
                }
            }
        }
    }
}