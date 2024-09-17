using Godot;
using System;

public partial class Enemy : Node2D
{
	int SPEED = 65;

	int direction = 1;

	RayCast2D rayCastRight;
	RayCast2D rayCastLeft;
	AnimatedSprite2D animatedSprite2D;
	public override void _Process(double delta)
	{
		rayCastRight = GetNode<RayCast2D>("RayCastRight");
        rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if (rayCastRight.IsColliding())
		{
			direction = -1;
			animatedSprite2D.FlipH = true;
		}
		if (rayCastLeft.IsColliding())
		{
			direction = 1;
			animatedSprite2D.FlipH = false;
		}

        Position = new Vector2(Position.X + SPEED * direction * (float)delta, Position.Y);

		
	}
}
