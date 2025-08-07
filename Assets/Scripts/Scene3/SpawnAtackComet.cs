using System.Collections;
using UnityEngine;

public class SpawnAtackComet : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject[] _comet;
    [SerializeField] GameObject[] _improvements;

    [Header("Spawn Settings")]
    [SerializeField] float speedSpawnComet = 0.07f;
    [SerializeField] float speedSpawnImprovements = 10f;
    [SerializeField] float spawnRadius = 50f;

    [Header("Gizmos")]
    [SerializeField] Color gizmoColor = Color.cyan;
    [SerializeField] int gizmoSegments = 64;

    void Start()
    {
        if (_comet != null && _improvements != null)
        {
            StartCoroutine(SpawnComets());
            StartCoroutine(SpawnImprovements());
        }
    }

    IEnumerator SpawnComets()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedSpawnComet);
            Vector3 spawnPos = GetRandomPositionInCircle(spawnRadius);
            Quaternion spawnRot = transform.rotation;

            GameObject comet = Instantiate(
                _comet[Random.Range(0, _comet.Length)],
                spawnPos,
                spawnRot
            );
            comet.name = "Comet";
        }
    }

    IEnumerator SpawnImprovements()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedSpawnImprovements);
            Vector3 spawnPos = GetRandomPositionInCircle(spawnRadius);
            Quaternion spawnRot = transform.rotation;

            GameObject improvement = Instantiate(
                _improvements[Random.Range(0, _improvements.Length)],
                spawnPos,
                spawnRot
            );
            improvement.name = "Improvements";
        }
    }

    /// <summary>
    /// Возвращает случайную позицию в круге по X и Y вокруг объекта.
    /// </summary>
    Vector3 GetRandomPositionInCircle(float radius)
    {
        Vector2 randomCircle = Random.insideUnitCircle * radius;
        return new Vector3(
            transform.position.x + randomCircle.x,
            transform.position.y + randomCircle.y,
            transform.position.z // остаётся фиксированным
        );
    }

    /// <summary>
    /// Отрисовка круга в редакторе.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        DrawCircle(transform.position, spawnRadius, gizmoSegments);
    }

    void DrawCircle(Vector3 center, float radius, int segments)
    {
        Vector3 prevPoint = center + new Vector3(radius, 0f, 0f);
        for (int i = 1; i <= segments; i++)
        {
            float angle = (float)i / segments * Mathf.PI * 2f;
            Vector3 newPoint = center + new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0f);
            Gizmos.DrawLine(prevPoint, newPoint);
            prevPoint = newPoint;
        }
    }
}