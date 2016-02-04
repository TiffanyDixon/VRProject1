using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]

    
    public class CarUserControl : MonoBehaviour
    {
        public bool latch = false;

        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            bool brakes = CrossPlatformInputManager.GetButton("Fire1");



            


            float r2 = CrossPlatformInputManager.GetAxis("R2");
            float l2 = CrossPlatformInputManager.GetAxis("L2");

            float throttle = r2 - l2;

            

            float yaw = 0;

            bool r1 = CrossPlatformInputManager.GetButton("R1");
            bool l1 = CrossPlatformInputManager.GetButton("L1");
            if (l1)
                yaw = -1;
            if (r1)
                yaw = 1;

            if (r1 == l1)
                yaw = 0;

   


            //#if !MOBILE_INPUT


            float handbrake = CrossPlatformInputManager.GetAxis("Fire1");

            //throttle = throttle * Time.deltaTime * 850;


            m_Car.Move(h, throttle, throttle, 0);// handbrake);
          

            m_Car.Move(yaw, v, h, throttle, brakes);

            
            if (CrossPlatformInputManager.GetButton("Fire3"))
            {

                if (!latch)
                {
                    m_Car.switchMode();
                    latch = false;
                }
                latch = true;
            }
            else
            {
                latch = false;
            }


            //#else
            //          m_Car.Move(h, v, v, 0f);
            //#endif
        }
    }
}
