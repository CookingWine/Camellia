using UnityEditor;
using UnityEngine;

namespace Camellia.Runtime
{
    internal class GameInterfaceDraw:MonoBehaviour
    {
#if UNITY_EDITOR
        public bool m_EnableGizmos;
        private GameObject m_GameObject;

        private void OnDrawGizmos( )
        {
            if(m_GameObject == null)
            {
                m_GameObject = this.gameObject;
            }
            if(m_EnableGizmos && m_GameObject != null)
            {

            }

        }
#endif
    }
}
