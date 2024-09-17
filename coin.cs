using Godot;
using System;

public partial class coin : Area2D
{
	game_manager gameManager;

	private void _on_body_entered(Node2D body)
	{
			gameManager = GetNode<game_manager>("%GameManager");


			gameManager.AddPoint();
			QueueFree();
	}

}



