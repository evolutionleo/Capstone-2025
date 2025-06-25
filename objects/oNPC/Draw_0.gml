/// @desc 

draw_self()



if (in_dialogue) {
draw_set_font(fNPC)
draw_set_color(c_black)

var _x = x
var _y = y-100

var f = 1/2

draw_sprite_ext(sDialogueClouds, 0, _x, _y, f, f, 0, c_white, 1)
_x += sprite_get_width(sDialogueClouds)*f + sprite_get_xoffset(sBigDialogueCloud)*f
_y -= sprite_get_height(sDialogueClouds)*f + sprite_get_yoffset(sBigDialogueCloud)*f

draw_sprite_ext(sBigDialogueCloud, 0, _x, _y, f, f, 0, c_white, 1)

_x -= sprite_get_xoffset(sBigDialogueCloud)*f
_x += 20

draw_text(_x, _y, current_text)



draw_set_color(c_white)
draw_set_font(-1)
}