/// @desc find the out door
var my_target = noone
var from = id
var to = to_id

with(oDoorTeleporter) {
	if (from_id == to) {
		my_target = id
		target = from
	}
}

self.target = my_target