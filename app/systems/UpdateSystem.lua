local UpdateSystem = tiny.processingSystem(Base:extend())
UpdateSystem.filter = tiny.requireAll("update")

function UpdateSystem:process(e, dt)
	e:update(dt)
end

return UpdateSystem
