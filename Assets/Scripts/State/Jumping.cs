using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : BaseState
{
    protected MovementSM _sm;
    private bool _isGrounded;
    private int _groudLayer = 1 << 6;

    public Jumping(MovementSM stateMachine) : base("Jumping", stateMachine) 
    {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.rend.color = Color.green;

        Vector2 vel = _sm.rb.velocity;
        vel.y += _sm.jumpForce;
        _sm.rb.velocity = vel;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_isGrounded)
        {
            stateMachine.ChangeState(_sm.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        _isGrounded = _sm.rb.velocity.y < Mathf.Epsilon && _sm.rb.IsTouchingLayers(_groudLayer);
    }
}
