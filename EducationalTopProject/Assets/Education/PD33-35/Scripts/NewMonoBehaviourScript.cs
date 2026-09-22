using UnityEngine;
namespace Education.PD33_35
{
    public class NewMonoBehaviourScript : MonoBehaviour
    {
        
        void Start()
        {
            Debug.Log("Start called");
        }

       
        void Update()
        {
            Debug.Log("Update called");
        }

        private void FixedUpdate()
        {
            Debug.Log("FixedUpdate called");
        }
    }
}
