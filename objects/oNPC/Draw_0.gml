/// @desc 

draw_self()



if (in_dialogue) {
draw_set_font(fNPC)
draw_set_color(c_black)

draw_text(x, y, current_text)

//draw_sprite(sDialogueClouds, 0, x, y)
//draw_sprite(sBigDialogueCloud, 0, x + sprite_get_width(sDialogueClouds) + sprite_get_xoffset(sBigDialogueCloud), y - sprite_get_height(sDialogueClouds) - sprite_get_yoffset(sBigDialogueCloud))


draw_set_color(c_white)
draw_set_font(-1)
}