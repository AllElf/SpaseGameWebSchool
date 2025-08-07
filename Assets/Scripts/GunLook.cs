using UnityEngine;

public class GunLookAxisLimited : MonoBehaviour
{
    public enum RotationAxis { X, Y, Z }

    [Header("Target Settings")]
    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private float detectionRadius = 15f;

    [Header("Rotation Settings")]
    [SerializeField] private RotationAxis rotationAxis = RotationAxis.Y;
    [SerializeField] private float rotationSpeed = 180f;

    [Header("Rotation Limits")]
    [SerializeField] private float minAngle = -90f;
    [SerializeField] private float maxAngle = 90f;

    private Transform currentTarget;
    private float initialAngle;

    void Start()
    {
        initialAngle = GetAxisAngle(transform.localEulerAngles);
    }

    void Update()
    {
        FindNearestEnemy();

        if (currentTarget != null)
        {
            Vector3 localDir = transform.InverseTransformPoint(currentTarget.position);
            float targetAngle = GetTargetAngle(localDir);
            float clampedAngle = ClampAngle(targetAngle, initialAngle + minAngle, initialAngle + maxAngle);
            RotateToAngle(clampedAngle);
        }
        else
        {
            RotateToAngle(initialAngle);
        }
    }

    void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float closestDist = detectionRadius;
        currentTarget = null;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < closestDist)
            {
                closestDist = dist;
                currentTarget = enemy.transform;
            }
        }
    }

    float GetTargetAngle(Vector3 localDir)
    {
        switch (rotationAxis)
        {
            case RotationAxis.X:
                return Mathf.Atan2(localDir.z, localDir.y) * Mathf.Rad2Deg;
            case RotationAxis.Y:
                return Mathf.Atan2(localDir.x, localDir.z) * Mathf.Rad2Deg;
            case RotationAxis.Z:
                return Mathf.Atan2(localDir.y, localDir.x) * Mathf.Rad2Deg;
            default:
                return 0f;
        }
    }

    float GetAxisAngle(Vector3 euler)
    {
        return rotationAxis switch
        {
            RotationAxis.X => NormalizeAngle(euler.x),
            RotationAxis.Y => NormalizeAngle(euler.y),
            RotationAxis.Z => NormalizeAngle(euler.z),
            _ => 0f
        };
    }

    void RotateToAngle(float targetAngle)
    {
        Vector3 currentEuler = transform.localEulerAngles;
        float currentAngle = GetAxisAngle(currentEuler);
        float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);

        switch (rotationAxis)
        {
            case RotationAxis.X:
                transform.localEulerAngles = new Vector3(newAngle, currentEuler.y, currentEuler.z);
                break;
            case RotationAxis.Y:
                transform.localEulerAngles = new Vector3(currentEuler.x, newAngle, currentEuler.z);
                break;
            case RotationAxis.Z:
                transform.localEulerAngles = new Vector3(currentEuler.x, currentEuler.y, newAngle);
                break;
        }
    }

    float ClampAngle(float angle, float min, float max)
    {
        angle = NormalizeAngle(angle);
        min = NormalizeAngle(min);
        max = NormalizeAngle(max);

        if (min < max)
            return Mathf.Clamp(angle, min, max);
        else
        {
            if (angle > min || angle < max)
                return angle;
            else
                return Mathf.Abs(angle - min) < Mathf.Abs(angle - max) ? min : max;
        }
    }

    float NormalizeAngle(float angle)
    {
        angle %= 360f;
        if (angle < 0f) angle += 360f;
        return angle;
    }
}