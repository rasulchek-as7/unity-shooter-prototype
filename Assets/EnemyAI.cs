using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;

    [Header("Настройки ИИ")]
    public string playerTag = "Player";
    public float damage = 2f;
    public float attackRate = 1.5f;
    public float attackRange = 2f;

    private float nextAttackTime;

    void Awake()
    {
        // Принудительно находим и включаем агент
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true; 
    }

    void Start()
    {
        // Ищем игрока
        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
            Debug.Log("<color=green>Враг:</color> Игрок найден, начинаю преследование.");
        }
        else
        {
            Debug.LogError("<color=red>Враг:</color> Объект с тегом " + playerTag + " не найден! Проверьте теги.");
        }
    }

    void Update()
    {
        if (playerTransform == null || !agent.isOnNavMesh) return;

        // Принудительно обновляем цель каждый кадр
        agent.SetDestination(playerTransform.position);

        // Проверка дистанции для атаки
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        
        if (distance <= attackRange)
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + attackRate;
            }
        }
    }

    void Attack()
    {
        Debug.Log("<color=yellow>Бам!</color> Враг ударил игрока на " + damage);
        // Здесь можно вызвать метод урона у скрипта игрока
    }

    // Эта функция нарисует в редакторе линию пути, чтобы вы видели, куда он хочет идти
    void OnDrawGizmos()
    {
        if (agent != null && agent.hasPath)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, agent.destination);
        }
    }
}