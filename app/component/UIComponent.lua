local BASE = 'app.component.'
---@type Component
local Component = require(BASE .. 'base')

---@class UIComponent : Component
local UIComponent = Component:extend()

function UIComponent:new()
    self.pos = { x = 0, y = 0 }
    self.zIndex = 0;
    self.parent = nil;
    self.position = 0
end

function UIComponent:draw(x, y)
    if self.onDraw then
        self:onDraw(x, y)
    end
    self.super.draw(self)
end

function UIComponent:attach(parent)
    self.parent = parent;
end

function UIComponent:detach(parent)
    self.parent = nil
end