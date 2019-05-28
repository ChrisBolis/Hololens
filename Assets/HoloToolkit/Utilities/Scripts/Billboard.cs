
using UnityEngine;

namespace HoloToolkit.Unity
{
    public enum PivotAxis
    {
        XY,
        Y,
        // Rotate about an individual axis.
        X,
        Z,
        // Rotate about a pair of axes.
        XZ,
        YZ,
        // Rotate about all axes.
        Free
    }

    public class Billboard : MonoBehaviour
    {
        [Tooltip("Specifies the axis about which the object will rotate.")]
        [SerializeField]
        private PivotAxis pivotAxis = PivotAxis.XY;
        public PivotAxis PivotAxis
        {
            get { return pivotAxis; }
            set { pivotAxis = value; }
        }


        [Tooltip("Specifies the target we will orient to. If no target is specified, the main camera will be used.")]
        [SerializeField]
        private Transform targetTransform;
        public Transform TargetTransform
        {
            get { return targetTransform; }
            set { targetTransform = value; }
        }

        private void OnEnable()
        {
            if (TargetTransform == null)
            {
                if (CameraCache.Main != null)
                {
                    TargetTransform = CameraCache.Main.transform;
                }
            }
        }


        private void LateUpdate()
        {
            if (TargetTransform == null)
            {
                if (CameraCache.Main != null)
                {
                    TargetTransform = CameraCache.Main.transform;
                }
                else
                {
                    return;
                }
            }


            Vector3 directionToTarget = TargetTransform.position - transform.position;

            bool useCameraAsUpVector = true;

            switch (PivotAxis)
            {
                case PivotAxis.X:
                    directionToTarget.x = 0.0f;
                    useCameraAsUpVector = false;
                    break;

                case PivotAxis.Y:
                    directionToTarget.y = 0.0f;
                    useCameraAsUpVector = false;
                    break;

                case PivotAxis.Z:
                    directionToTarget.x = 0.0f;
                    directionToTarget.y = 0.0f;
                    break;

                case PivotAxis.XY:
                    useCameraAsUpVector = false;
                    break;

                case PivotAxis.XZ:
                    directionToTarget.x = 0.0f;
                    break;

                case PivotAxis.YZ:
                    directionToTarget.y = 0.0f;
                    break;

                case PivotAxis.Free:
                default:
                    break;
            }


            if (directionToTarget.sqrMagnitude < 0.001f)
            {
                return;
            }

            // Calculate and apply the rotation required to reorient the object
            if (useCameraAsUpVector)
            {
                transform.rotation = Quaternion.LookRotation(-directionToTarget, CameraCache.Main.transform.up);
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(-directionToTarget);
            }
        }
    }
}
