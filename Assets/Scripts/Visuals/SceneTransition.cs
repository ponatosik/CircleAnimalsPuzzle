using UnityEngine;

public abstract class SceneTransition: MonoBehaviour
{
    [field: SerializeField]
    public float TransitionTime { get; set; } = 1f;
    public abstract void BeginTransition();
    public abstract void EndTransition();  
}
