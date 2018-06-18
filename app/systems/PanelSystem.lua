local tiny = require('lib.tiny')

---@class PanelSystem : ECS_System


local PanelSystem = tiny.processingSystem(Base:extend())
PanelSystem.isDrawSystem = true

function PanelSystem:new(layer)
    --print(layer)
    self.filter = tiny.requireAll("drawPanel", function(s, e)
        --print(e.layer, e.isChild)
        return e.layer == layer and not e.isChild
    end)
end

function PanelSystem:process(e, dt)
    e:drawPanel(dt)
end

return PanelSystem
