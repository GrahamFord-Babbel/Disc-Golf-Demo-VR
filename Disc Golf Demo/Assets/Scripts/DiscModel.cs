using UnityEngine;
using Normal.Realtime;

namespace Normal.Realtime.Examples
{
    public class DiscModel : MonoBehaviour
    {

        private RealtimeView _realtimeView;
        private RealtimeTransform _realtimeTransform;

        private void Awake()
        {
            _realtimeView = GetComponent<RealtimeView>();
            _realtimeTransform = GetComponent<RealtimeTransform>();
        }

        private void Update()
        {
            // If this CubePlayer prefab is not owned by this client, bail.
            
        }
    }
}
