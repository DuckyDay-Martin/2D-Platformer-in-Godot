using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 130.0f;
	public const float JumpVelocity = -300.0f;
	public const float DashSpeed = 650.0f;
	public Vector2 dashDirection = new Vector2(1, 0);
	bool canDoubleJump = true;
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();


	AnimatedSprite2D animatedSprite;
	public override void _PhysicsProcess(double delta)
	{
        
        Vector2 velocity = Velocity;
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		
		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{     
            velocity.Y = JumpVelocity;
            canDoubleJump = true;
        }
        if (!IsOnFloor() && Input.IsActionJustPressed("jump") && canDoubleJump)
        {
            canDoubleJump = false;
            velocity.Y = JumpVelocity;
            GD.Print("DoubleJump");
			
        }


        //Gets movement direction: -1 ,0 ,1
        var direction = Input.GetAxis("move_left", "move_right");

		//Change The Sprite
		if (direction > 0)
		{
			animatedSprite.FlipH = false;
		}
		else if(direction < 0)
		{
			animatedSprite.FlipH = true;
		}


		//Player Animation
		if (IsOnFloor())
		{
			if (direction == 0)
			{
				animatedSprite.Play("idle");
			}
			else
			{
				animatedSprite.Play("run");
			}
		}
		else
		{
			animatedSprite.Play("jump");
		}

		if (direction == 0)
		{
			animatedSprite.Play("idle");
		}
		else 
		{
			animatedSprite.Play("run");
		}

		//Handle dash
		//if (Input.IsActionPressed("move_left") && Input.IsActionJustPressed("dash") && direction != 0)
		//{
		//	dashDirection = Vector2.Left;
		//	velocity.X = dashDirection.Normalized() * (Speed + DashSpeed);
		//	GD.Print("DashLeft");
		//}
		//else 
		//{
  //          velocity.X = Mathf.MoveToward(Velocity.X, 0, DashSpeed);
  //      }


        //Apply the movement
        if (direction != 0)
		{
			GD.Print("Move");
			velocity.X = direction * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
