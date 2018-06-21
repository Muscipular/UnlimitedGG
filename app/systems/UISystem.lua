local tiny = require('lib.tiny')

---@class PanelSystem : ECS_System


local UISystem = tiny.processingSystem(Base:extend("UISystem"))
UISystem.isDrawSystem = true

function UISystem:new(layer)
    --print(layer)
    self.filter = tiny.requireAll("draw", "ui", function(s, e)
        return e.layer == layer and not e.isChild
    end)
end

function UISystem:process(e, dt)
    e:draw(dt, 0, 0, 0)
end

return UISystem
