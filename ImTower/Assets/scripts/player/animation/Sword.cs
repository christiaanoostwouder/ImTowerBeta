using UnityEngine;

public class Sword : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer; // Reference to the SkinnedMeshRenderer (set this in the Inspector)

    void LateUpdate()
    {
        // Ensure the collider follows the animated character's position and rotation
        if (skinnedMeshRenderer != null)
        {
            // Get the position of a bone or another reference point on your character
            Transform referenceTransform = skinnedMeshRenderer.bones[0]; // Change this index based on your character's skeleton
            Vector3 newPosition = referenceTransform.position;
            Quaternion newRotation = referenceTransform.rotation;

            // Update the position and rotation of the collider
            transform.position = newPosition;
            transform.rotation = newRotation;
        }
    }
}
