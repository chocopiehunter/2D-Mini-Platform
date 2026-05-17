using Assets.PixelFantasy.PixelHeroes.Common.Scripts.CharacterScripts;
using Assets.PixelFantasy.PixelHeroes.Common.Scripts.ExampleScripts;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 startPosition;
    private Rigidbody2D rb;
    private CharacterAnimation _animation;

    [Header("UI 설정")]
    // UI를 통째로 넣을곳
    [SerializeField] private GameObject clearPanelUI;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animation = GetComponent<CharacterAnimation>();
        startPosition = transform.position;

        // 게임 시작 시 UI 비활성화
        if (clearPanelUI != null)
        {
            clearPanelUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // DeadZone 충돌(낙사)
        if (collision.gameObject.name.Contains("DeadZone"))
        {
            Respawn();
        }

        // Fire 충돌
        if (collision.CompareTag("Fire"))
        {
            Respawn();
        }

        // Clear 충돌
        if (collision.CompareTag("Clear"))
        {
            GameClear();
        }
    }

    private void GameClear()
    {
        // UI 활성화
        if (clearPanelUI != null)
        {
            clearPanelUI.SetActive(true);
        }
    }

    public void Respawn()
    {
        transform.position = startPosition;
        if (rb != null) rb.linearVelocity = Vector2.zero;
        if (_animation != null) _animation.Ready();
    }
}