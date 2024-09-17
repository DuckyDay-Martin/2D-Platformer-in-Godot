using Godot;
using System;

public partial class kill_zone : Area2D
{
Timer timer;

private void _on_body_entered(Node2D body)
{
		timer = GetNode<Timer>("Timer");
		GD.Print("Dead");
		Engine.TimeScale = 0.2;
		timer.Start();
	
}
	private void _on_timer_timeout()
	{
		Engine.TimeScale = 1;
		GetTree().ReloadCurrentScene();
	}

}



