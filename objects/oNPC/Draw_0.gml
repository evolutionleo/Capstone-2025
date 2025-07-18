/// @desc 

draw_self()



if (in_dialogue) {

var split_point = string_pos(":", current_text)
var character, line
if (split_point != 0) {
	character = string_trim(string_copy(current_text, 1, split_point-1))
	line = string_trim(string_copy(current_text, split_point+1, string_length(current_text)-split_point))
}
else {
	character = ""
	line = current_text
}

line = string_replace_all(line, "…", "...")

var _x, _y
if (character == "" or character == "гг") {
	_x = oPlayer.x
	_y = oPlayer.bbox_top
}
else {
	_x = (bbox_right + bbox_left) / 2
	_y = bbox_top
}

if (character == "") {
	line = "(" + line + ")"
}

_y -= 10

var f = 1/2

draw_sprite_ext(sDialogueClouds, 0, _x, _y, f, f, 0, c_white, 1)
_x += sprite_get_width(sDialogueClouds)*f + sprite_get_xoffset(sBigDialogueCloud)*f
_y -= sprite_get_height(sDialogueClouds)*f + sprite_get_yoffset(sBigDialogueCloud)*f

draw_sprite_ext(sBigDialogueCloud, 0, _x, _y, f, f, 0, c_white, 1)

_x -= sprite_get_xoffset(sBigDialogueCloud)*f
_x += 20

_y -= 40

var max_w = sprite_get_width(sBigDialogueCloud)*f-30
var max_h = sprite_get_height(sBigDialogueCloud)*f-40
scribble(line).starting_format("fNPC", c_black).fit_to_box(max_w, max_h, true).draw(_x, _y, typist)


}