/// @desc 

if (target != noone and place_meeting(x, y, oPlayer)) {
	if (oPlayer.kup) {
		oPlayer.x = target.x
		oPlayer.y = target.y
	}
}