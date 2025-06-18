/// @desc 

occluder = new BulbDynamicOccluder(oLightingController.renderer)

occluder.x = x
occluder.y = y

occluder.AddEdge(bbox_left - x, bbox_top - y, bbox_right - x, bbox_top - y)
occluder.AddEdge(bbox_right - x, bbox_top - y, bbox_right - x, bbox_top - y)
occluder.AddEdge(bbox_right - x, bbox_bottom - y, bbox_left - x, bbox_bottom - y)
occluder.AddEdge(bbox_left - x, bbox_bottom - y, bbox_left - x, bbox_top - y)



