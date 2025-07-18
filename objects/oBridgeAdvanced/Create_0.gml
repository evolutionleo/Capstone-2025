/// @desc 

event_inherited()

expand_speed /= 10

max_xscale = image_xscale
max_yscale = image_yscale

var dir = expand_direction
if (dir == "up" or dir == "left")
	sprite_index = sBridgeUpLeft
else
	sprite_index = sBridgeDownRight


if (!is_reversed) {
	if (dir == "left" or dir == "right") {
		image_xscale = 0.1
	}
	else
		image_yscale = 0.1
}
