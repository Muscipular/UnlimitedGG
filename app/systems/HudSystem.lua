local HudSystem = tiny.processingSystem(Base:extend())
HudSystem.isDrawSystem = true

function HudSystem:new(layerFlag)
	self.filter = tiny.requireAll("drawHud", function(s, e)
		return e.zIndex == layerFlag
	end)
end

function HudSystem:process(e, dt)
	e:drawHud(dt)
end

return HudSystem
