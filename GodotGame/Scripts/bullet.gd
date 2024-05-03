extends RigidBody2D

var SPEED = 0
var COLLISIONS = 1
var velocity = Vector2.ZERO
var isPrimed = false

func _physics_process(delta):
	if (velocity == Vector2.ZERO):
		velocity = Vector2.UP.rotated(rotation) * SPEED
	var collidedObject = move_and_collide(velocity * delta)
	global_rotation = velocity.normalized().angle() + deg_to_rad(90)

	if (collidedObject && !isPrimed):
		return
	if (!collidedObject && !isPrimed):
		isPrimed = true
		return
	if (collidedObject):
		check_collision(collidedObject.get_collider())
		if (COLLISIONS == 0 && !is_queued_for_deletion()):
			queue_free()
			return
		velocity = velocity.bounce(collidedObject.get_normal())
		COLLISIONS -= 1


func check_collision(object):
	if object.has_method("take_damage") :
		queue_free()
		object.take_damage()
		return
	
func take_damage():
	if !is_queued_for_deletion():
		queue_free()
