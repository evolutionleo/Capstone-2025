/// @desc 

draw_self()



if (in_dialogue) {
	
var parts = string_split(current_text, ":")
var character = string_trim(parts[0])
var line = string_trim(parts[1])

if (character == "" or character == "гг") {
	var _x = oPlayer.x
	var _y = oPlayer.y
}
else {
	var _x = x
	var _y = y
}

if (character == "") {
	line = "(" + line + ")"
}

_y -= 100

var f = 1/2

draw_sprite_ext(sDialogueClouds, 0, _x, _y, f, f, 0, c_white, 1)
_x += sprite_get_width(sDialogueClouds)*f + sprite_get_xoffset(sBigDialogueCloud)*f
_y -= sprite_get_height(sDialogueClouds)*f + sprite_get_yoffset(sBigDialogueCloud)*f

draw_sprite_ext(sBigDialogueCloud, 0, _x, _y, f, f, 0, c_white, 1)

_x -= sprite_get_xoffset(sBigDialogueCloud)*f
_x += 20

scribble(line).starting_format("fNPC", c_black).draw(_x, _y, typist)


}