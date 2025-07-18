/// @desc find the out door
target = noone

with(oDoorTeleporter) {
	if (self.from_id == other.to_id) {
		other.target = self
	}
}