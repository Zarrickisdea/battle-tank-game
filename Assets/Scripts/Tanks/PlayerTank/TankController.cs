using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerTank
{
    public class TankController
    {
        private TankView tankView;
        private TankModel tankModel;

        private Vector2 moveVector;

        public TankController(TankView view, TankModel model)
        {
            tankModel = model;
            tankView = GameObject.Instantiate<TankView>(view);
            tankView.SetTankController(this);
        }

        public void InputHandler(InputAction.CallbackContext context)
        {
            moveVector = context.ReadValue<Vector2>();
        }

        public void Move()
        {
            tankView.Rb.velocity = new Vector3(-moveVector.x, 0, -moveVector.y) * tankModel.Speed;
        }

        public void Rotate()
        {
            if (moveVector != Vector2.zero)
            {
                tankView.transform.rotation = Quaternion.LookRotation(new Vector3(-moveVector.x, 0, -moveVector.y));
            }
        }

        public Transform GetTankView()
        {
            return tankView.transform;
        }
    }
}
