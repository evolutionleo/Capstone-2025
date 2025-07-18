/// @desc 

// Inherit the parent event
event_inherited();


with(instance_place(x, y, oLightBulb)) {
	if (held_by == undefined) {
		held_by = other
		other.holding = id
	}
}

if (!instance_exists(holding))
	holding = undefined
else {
	holding.x = x
	holding.y = y
}

active = (holding != undefined) and (holding.active)