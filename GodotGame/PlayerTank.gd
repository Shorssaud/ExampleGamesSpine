extends RigidBody3D


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	var input_dir = Input.get_vector("ui_left", "ui_right", "ui_up", "ui_down")
	var direction = (Vector3(input_dir.x, 0, input_dir.y)).normalized()
	print_debug(direction);
	move(direction.x, direction.z);


func move(x, y):
	
	if (x == 0 && y == 0):
		linear_velocity = Vector3(0,0,0);
		angular_velocity = Vector3(0,0,0);
		return;
	var angle = rad_to_deg(atan2(x, y)); 
	var moveDirection = Vector3(sin(angle), 0, cos(angle));
	
	linear_velocity = moveDirection * 10;
	rotation.y = Vector2(linear_velocity.x, linear_velocity.z).angle()
	
