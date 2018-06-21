local BASE = 'app.component.'
---@type Component
local Component = require(BASE .. 'base')

---@class UIComponent : Component
local UIComponent = Component:extend()
local deep = require('lib.deep')

function UIComponent:new()
    Component.new(self)
    self.pos = { x = 0, y = 0 }
    self.zIndex = 0;
    self.parent = nil;
    self.position = 0
    self.ui = true
    self.alpha = 1
end

function UIComponent:draw(dt, x, y, zIndex)
    if self.alpha <= 0 then
        return
    end
    local z = self.layer * 100 + self.zIndex + zIndex
    if self.onDraw then
        deep.queue(z, self.onDraw, self, dt, x, y, zIndex);
    end
    for i = 1, #self.children do
        local child = self.children[i];
        local _x, _y = self.pos.x + x, self.pos.y + y
        if child.isDeferDraw then
            child:draw(_x, _y, self.zIndex + zIndex)
        else
            deep.queue(z + (child.zIndex or 0), child.draw, child, dt, _x, _y, self.zIndex + zIndex)
        end
    end
end

function UIComponent:attach(parent)
    --print(tostring(parent))
    self.parent = parent;
end

function UIComponent:detach(parent)
    self.parent = nil
end

return UIComponent