using UnityEngine;
using Cinemachine;

public class CinemachineGroundYRestrictor : CinemachineExtension
{
    // Reference to the player or object that the virtual camera is following
    public Transform target;

    // The offset between the player's position and the ground level
    public float groundOffset = 2f;

    // This method will be called on every update of the virtual camera
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body && target != null)
        {
            // Get the new position of the virtual camera
            Vector3 pos = state.FinalPosition;

            // Calculate the ground level position
            float groundLevel = target.position.y + groundOffset;

            // Restrict the camera from going below the ground level
            if (pos.y < groundLevel)
            {
                pos.y = groundLevel;
            }

            // Apply the updated position to the virtual camera state
            state.PositionCorrection += pos - state.FinalPosition;
        }
    }
}
