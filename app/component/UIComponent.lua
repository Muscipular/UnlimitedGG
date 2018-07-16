local BASE = 'app.component.'
---@type Component
local Component = require(BASE .. 'base')

---@class UIComponent : Component
local UIComponent = Component:extend()
local deep = require('lib.deep')

function UIComponent:new(opt)
    Component.new(self)
    self.parent = nil;
    if opt then
        self.x = opt.x or 0;
        self.y = opt.y or 0;
        self.zIndex = opt.zIndex or 0;
        self.alpha = opt.alpha or 1
    else
        self.x = 0;
        self.y = 0;
        self.zIndex = 0;
        self.alpha = 1
    end
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
        local _x, _y = self.x + x, self.y + y
        if child.isDeferDraw then
            child:draw(dt, _x, _y, self.zIndex + zIndex)
        else
            deep.queue(z + (child.zIndex or 0), child.draw, child, dt, _x, _y, self.zIndex + zIndex)
        end
    end
end

function UIComponent:attach(parent)
    self.parent = parent;
    self.layer = parent.layer
end

function UIComponent:detach(parent)
    self.parent = nil
end

return UIComponent