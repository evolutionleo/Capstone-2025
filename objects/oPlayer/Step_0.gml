/// @desc 

kup = keyboard_check(ord("W"))
kleft = keyboard_check(ord("A"))
kdown = keyboard_check(ord("S"))
kright = keyboard_check(ord("D"))

kjump = keyboard_check_pressed(vk_space)


on_ground = place_meeting(x, y+1, oWall)


movedir.x = kright - kleft
movedir.y = kdown - kup

if (movedir.x != 0)
	image_xscale = abs(image_xscale) * sign(movedir.x)


if (sign(movedir.x) != sign(spd.x)) {
	spd.x -= sign(spd.x) * decc
	if (abs(spd.x) <= decc)
		spd.x = 0
}
if (sign(movedir.x) != sign(spd.x) || abs(spd.x) < walkspd)
	spd.x += movedir.x * acc


spd.x = clamp(spd.x, -walkspd, walkspd)
//spd.x = movedir.x * walkspd
spd.y += grv

if (kjump and on_ground) {
	spd.y = -jumpspd
}


if (place_meeting(x + spd.x, y, oWall)) {
	while (!place_meeting(x + sign(spd.x), y, oWall)) {
		x += sign(spd.x)
	}
	spd.x = 0
}
x += spd.x

if (place_meeting(x, y + spd.y, oWall)) {
	while (!place_meeting(x, y + sign(spd.y), oWall)) {
		y += sign(spd.y)
	}
	spd.y = 0
}
y += spd.y

