/// @desc find the out door

var other_target = noone
var other_door_id = door_id
var other_id = id

with(oDoorTeleporter) {
	if (door_id == other_door_id and id != other_id) {
		other_target = id
	}
}

target = other_target