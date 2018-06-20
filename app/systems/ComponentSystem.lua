local ComponentSystem = tiny.processingSystem(Base:extend())
ComponentSystem.isDrawSystem = true

function ComponentSystem:new()
    self.filter = tiny.requireAll("drawComponent")
end

function ComponentSystem:process(e, dt)
    e:drawComponent(dt)
end

return ComponentSystem
