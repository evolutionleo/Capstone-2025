/// @desc find the out door
var target = noone
with(oDoorTeleporter) {
	if (self.in_id == other.out_id) {
		target = self
	}
}